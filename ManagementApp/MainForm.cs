using ManagementApp.CustomControls;
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

        private readonly List<Control> _openedForms = new();

        private QuanLyDeThiForm quanLyDeThiForm = new QuanLyDeThiForm();
        private int _pos_QuanLyDeThiForm = -1;


        public MainForm()
        {
            InitializeComponent();

            // Add the control scroll message filter to re-route all mousewheel events
            // to the control the user is currently hovering over with their cursor.
            Application.AddMessageFilter(new ControlScrollFilter());
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChangeTheme(false);
        }

        private void đềThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checked => is open
            đềThiToolStripMenuItem.Checked = !đềThiToolStripMenuItem.Checked;
            ChangeToForm(quanLyDeThiForm);
        }

        private void themeToggleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeToggleToolStripMenuItem.Checked = !themeToggleToolStripMenuItem.Checked;
            // Checked => Light, Unchecked => Dark
            ChangeTheme(themeToggleToolStripMenuItem.Checked);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms();
        }


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

        private void ChangeToForm(Form form)
        {
            if (_openedForms.Count == 0)
            {
                form.TopLevel = false;
                formView.Controls.Add(form);
                form.Show();
                form.Dock = DockStyle.Fill;
                _openedForms.Add(form);
            }
            else
            {
                formView.Controls.Remove(form);
                _openedForms.Clear();
            }
        }

        private void CloseAllForms()
        {
            formView.Controls.Clear();
            _openedForms.Clear();
        }
        #endregion
    }
}
