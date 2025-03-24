using Grpc.Net.Client;
using ManagementApp.CustomControls;
using Newtonsoft.Json.Linq;
using ReaLTaiizor.Docking.Crown;
using ReaLTaiizor.Native;
using System.Configuration;
using System.Windows.Forms;
using System.Xml.Linq;
using static ManagementApp.AdminProto.AdminService;

//using static ExamServer.AdminService;
using static ReaLTaiizor.Helper.CrownHelper;

namespace ManagementApp
{
    public partial class MainForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private Control? _currentForm = null;

        private readonly string DefaultFormText = "PolyTest Manager";

        // Lưu trữ thông tin máy chủ
        private AdminServiceClient _client;
        private readonly string _serverAddress;
        private readonly string _accessToken;

        private QuanLyDeThiForm quanLyDeThiForm;
        private QuanLyThiSinhForm quanLyThiSinhForm;
        private QuanLyNguoiDungForm quanLyNguoiDungForm;
        private ThongKeDiemForm thongKeDiemForm;

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            // Thêm code dưới để chuột tự động tập trung vào ô hiện tại khi lăn chuột
            Application.AddMessageFilter(new ControlScrollFilter());
        }

        public MainForm(AdminServiceClient client, string accessToken)
        {
            InitializeComponent();

            // Đăng nhập vào máy chủ dùng thông tin đăng nhập từ cái DangNhapForm
            _client = client;
            _accessToken = accessToken;

            //quanLyDeThiForm = new QuanLyDeThiForm(_client, _accessToken);
            //quanLyNguoiDungForm = new QuanLyNguoiDungForm(_client, _accessToken);
            //quanLyThiSinhForm = new QuanLyThiSinhForm(_client, _accessToken);
            thongKeDiemForm = new ThongKeDiemForm(_client, _accessToken);

            // Thêm code dưới để chuột tự động tập trung vào ô hiện tại khi lăn chuột
            Application.AddMessageFilter(new ControlScrollFilter());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = DefaultFormText;
            if (ConfigurationManager.AppSettings["AppTheme"] == "light")
            {
                themeToggleToolStripMenuItem.Checked = true;
                // Checked => Light, Unchecked => Dark
                ChangeTheme(themeToggleToolStripMenuItem.Checked);
            }
            else
            {
                themeToggleToolStripMenuItem.Checked = false;
                // Checked => Light, Unchecked => Dark
                ChangeTheme(themeToggleToolStripMenuItem.Checked);
            }
        }
        #endregion

        #region Main Menu Strip
        private void đềThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checked => is open
            đềThiToolStripMenuItem.Checked = !đềThiToolStripMenuItem.Checked;
            ClearAllCheckedAndChangeToForm(quanLyDeThiForm, đềThiToolStripMenuItem);
        }

        private void thíSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thíSinhToolStripMenuItem.Checked = !thíSinhToolStripMenuItem.Checked;
            ClearAllCheckedAndChangeToForm(quanLyThiSinhForm, thíSinhToolStripMenuItem);
        }

        private void ngườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ngườiDùngToolStripMenuItem.Checked = !ngườiDùngToolStripMenuItem.Checked;
            ClearAllCheckedAndChangeToForm(quanLyNguoiDungForm, ngườiDùngToolStripMenuItem);
        }

        private void điểmTheoThíSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            điểmTheoThíSinhToolStripMenuItem.Checked = !điểmTheoThíSinhToolStripMenuItem.Checked;
            ClearAllCheckedAndChangeToForm(thongKeDiemForm, điểmTheoThíSinhToolStripMenuItem);
        }

        private void themeToggleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checked => Light, Unchecked => Dark
            themeToggleToolStripMenuItem.Checked = !themeToggleToolStripMenuItem.Checked;
            ChangeTheme(themeToggleToolStripMenuItem.Checked);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(true);
            this.Close();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(true);

            // TODO: Cho lệnh log out ở giữa
            Shared.IsExiting = true;
            this.Close();
        }
        #endregion

        #region Functions
        private void ChangeTheme(bool isChangingToLightTheme)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (isChangingToLightTheme)
            {
                // Checking
                ThemeProvider.Theme = new LightTheme();
                themeToggleToolStripMenuItem.Text = "Chế độ sáng";
                config.AppSettings.Settings["AppTheme"].Value = "light";
            }
            else
            {
                // Unchecking
                ThemeProvider.Theme = new DarkTheme();
                themeToggleToolStripMenuItem.Text = "Chế độ tối";
                config.AppSettings.Settings["AppTheme"].Value = "dark";
            }
            config.Save(ConfigurationSaveMode.Modified);
            this.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
            foreach (ToolStripMenuItem Control in mainMenuStrip.Items)
            {
                Control.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
                foreach (ToolStripMenuItem childControl in Control.DropDownItems)
                {
                    childControl.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
                }
            }
            Invalidate();
            Refresh();
        }

        private void ClearAllCheckedAndChangeToForm(Form form, ToolStripMenuItem itemToBeChecked)
        {
            // Tắt hết tất cả dấu tick
            foreach (ToolStripMenuItem tool in mainMenuStrip.Items)
            {
                foreach (ToolStripMenuItem dropdowntool in tool.DropDownItems)
                {
                    // Kiểm tra có phải nút đổi chủ đề để không đụng tới
                    if (dropdowntool.Name != "themeToggleToolStripMenuItem")
                    {
                        dropdowntool.Checked = false;
                    }
                }
            }

            // Nếu form đang bật thì bật dấu tick của ToolStripMenuItem mở form
            if (ToggleChangeToForm(form))
            {
                itemToBeChecked.Checked = true;
            }
        }

        private void ClearAllCheckedAndChangeToForm(Form form)
        {
            // Tắt hết tất cả dấu tick
            foreach (ToolStripMenuItem tool in mainMenuStrip.Items)
            {
                foreach (ToolStripMenuItem dropdowntool in tool.DropDownItems)
                {
                    // Kiểm tra có phải nút đổi chủ đề để không đụng tới
                    if (dropdowntool.Name != "themeToggleToolStripMenuItem")
                    {
                        dropdowntool.Checked = false;
                    }
                }
            }

            ToggleChangeToForm(form);
        }

        private bool ToggleChangeToForm(Form form)
        {
            // false -> is closing, true -> is opening
            // false -> đang đóng form, true -> mở form
            if (_currentForm == form)
            {
                formView.Controls.Clear();
                _currentForm = null;
                this.Text = DefaultFormText;
                return false;
            }
            else
            {
                formView.Controls.Clear();
                form.TopLevel = false;
                formView.Controls.Add(form);
                form.Show();
                this.Text = DefaultFormText + " - " + form.Text;
                form.Dock = DockStyle.Fill;
                _currentForm = form;
                return true;
            }
        }

        private void CloseAllForms(bool clearAllForms)
        {
            if (clearAllForms)
            {
                quanLyDeThiForm = new();
                quanLyNguoiDungForm = new();
                quanLyThiSinhForm = new();

                formView.Controls.Clear();
                _currentForm = null;
            }
            else
            {
                formView.Controls.Clear();
                _currentForm = null;
            }
        }
        #endregion

        private void vềPolyTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GioiThieuForm gioiThieuForm = new GioiThieuForm();
            gioiThieuForm.ShowDialog();
        }
    }
}
