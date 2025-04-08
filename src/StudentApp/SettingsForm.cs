using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ReaLTaiizor.Helper.CrownHelper;

namespace StudentApp
{
    public partial class SettingsForm : Form
    {
        #region Constructor
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["AppTheme"] == "light")
            {
                radioLightTheme.Checked = true;
                radioDarkTheme.Checked = false;
                ChangeThemeGlobal(true);
            }
            else
            {
                radioLightTheme.Checked = false;
                radioDarkTheme.Checked = true;
                ChangeThemeGlobal(false);
            }
            Invalidate();
            Refresh();

            textBoxServerAddress.Text = ConfigurationManager.AppSettings["ServerAddress"] ?? "http://localhost:50051";
        }
        #endregion

        #region Function
        private void ChangeThemeGlobal(bool isChangingToLightTheme)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (isChangingToLightTheme)
            {
                // Checking
                ThemeProvider.Theme = new LightTheme();
                config.AppSettings.Settings["AppTheme"].Value = "light";
            }
            else
            {
                // Unchecking
                ThemeProvider.Theme = new DarkTheme();
                config.AppSettings.Settings["AppTheme"].Value = "dark";
            }
            config.Save(ConfigurationSaveMode.Modified);
            this.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
            //foreach (ToolStripMenuItem Control in mainMenuStrip.Items)
            //{
            //    Control.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
            //    foreach (ToolStripMenuItem childControl in Control.DropDownItems)
            //    {
            //        childControl.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
            //    }
            //}
            Invalidate();
            Refresh();
        }
        #endregion

        #region Control Function
        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonChangeIP_Click(object sender, EventArgs e)
        {
            string serverAddress = textBoxServerAddress.Text;
            try
            {
                var handler = new HttpClientHandler();
                var channel = GrpcChannel.ForAddress(serverAddress,
                    new GrpcChannelOptions { HttpHandler = handler });
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["ServerAddress"].Value = serverAddress;
                config.Save(ConfigurationSaveMode.Modified);
                MessageBox.Show("Đã sửa địa chỉ thành công!", "Đổi thành công", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Địa chỉ không hợp lệ!", "Đổi thất bại", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region Events
        private void radioLightTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLightTheme.Checked)
            {
                ChangeThemeGlobal(true);
            }
            else
            {
                ChangeThemeGlobal(false);
            }
            Invalidate();
            Refresh();
        }
        #endregion
    }
}
