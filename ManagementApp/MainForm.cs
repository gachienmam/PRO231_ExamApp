using ExamServer.AdminService;
using Grpc.Net.Client;
using ManagementApp.CustomControls;
using Newtonsoft.Json.Linq;
using ReaLTaiizor.Docking.Crown;
using ReaLTaiizor.Native;
using System.Windows.Forms;
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
        private readonly AdminService.AdminServiceClient _client;
        private readonly string _serverAddress;
        private readonly string _accessToken;

        private DangNhapForm dangNhapForm = new DangNhapForm();

        private QuanLyDeThiForm quanLyDeThiForm = new QuanLyDeThiForm();
        private QuanLyThiSinhForm quanLyThiSinhForm = new QuanLyThiSinhForm();
        private QuanLyNguoiDungForm quanLyNguoiDungForm = new QuanLyNguoiDungForm();

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            // Thêm code dưới để chuột tự động tập trung vào ô hiện tại khi lăn chuột
            Application.AddMessageFilter(new ControlScrollFilter());
        }

        public MainForm(string serverAddress, string accessToken)
        {
            InitializeComponent();

            // Đăng nhập vào máy chủ dùng thông tin đăng nhập từ cái DangNhapForm
            _serverAddress = serverAddress;
            _accessToken = accessToken;
            var channel = GrpcChannel.ForAddress(_serverAddress);
            _client = new AdminService.AdminServiceClient(channel);

            // Thêm code dưới để chuột tự động tập trung vào ô hiện tại khi lăn chuột
            Application.AddMessageFilter(new ControlScrollFilter());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChangeTheme(false);
            this.Text = DefaultFormText;
        }
        #endregion

        #region Main Menu Strip

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAllCheckedAndChangeToForm(dangNhapForm);
        }
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

        }

        private void themeToggleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeToggleToolStripMenuItem.Checked = !themeToggleToolStripMenuItem.Checked;
            // Checked => Light, Unchecked => Dark
            ChangeTheme(themeToggleToolStripMenuItem.Checked);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(true);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(true);

            // TODO: Cho lệnh log out ở giữa

            Application.Exit();
        }
        #endregion

        #region Functions
        private void ChangeTheme(bool isChangingToLightTheme)
        {
            if (isChangingToLightTheme)
            {
                // Checking
                ThemeProvider.Theme = new LightTheme();
                BackColor = ThemeProvider.Theme.Colors.GreyBackground;

                foreach (ToolStripMenuItem Control in mainMenuStrip.Items)
                {
                    Control.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
                    foreach (ToolStripMenuItem childControl in Control.DropDownItems)
                    {
                        childControl.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
                    }
                }
                themeToggleToolStripMenuItem.Text = "Chế độ sáng";

                Invalidate();
                Refresh();
            }
            else
            {
                // Unchecking
                ThemeProvider.Theme = new DarkTheme();
                BackColor = ThemeProvider.Theme.Colors.GreyBackground;

                foreach (ToolStripMenuItem Control in mainMenuStrip.Items)
                {
                    Control.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
                    foreach (ToolStripMenuItem childControl in Control.DropDownItems)
                    {
                        childControl.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
                    }
                }
                themeToggleToolStripMenuItem.Text = "Chế độ tối";

                Invalidate();
                Refresh();
            }
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
    }
}
