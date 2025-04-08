using Accessibility;
using Grpc.Net.Client;
using ManagementApp.AdminProto;
using ReaLTaiizor.Controls;
using System.Configuration;
using System.Net;
using static ManagementApp.AdminProto.AdminService;
using static ReaLTaiizor.Helper.CrownHelper;

namespace ManagementApp
{
    public partial class DangNhapForm : Form
    {
        private AdminServiceClient _client;
        private string _serverAddress;

        #region Constructor
        public DangNhapForm()
        {
            InitializeComponent();
            textBoxIPAddress.Text = ConfigurationManager.AppSettings["ServerAddress"] ?? "https://localhost:50052";
        }

        public DangNhapForm(string serverAddress)
        {
            InitializeComponent();
            _serverAddress = serverAddress;

            var handler = new HttpClientHandler();
            //handler.ServerCertificateCustomValidationCallback =
            //    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            textBoxIPAddress.Text = _serverAddress;

            var channel = GrpcChannel.ForAddress(_serverAddress,
                new GrpcChannelOptions { HttpHandler = handler });
            _client = new AdminServiceClient(channel);
        }

        private void DangNhapForm_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["AppTheme"] == "light")
            {
                ThemeProvider.Theme = new LightTheme();
                Invalidate();
                Refresh();
            }
            else
            {
                ThemeProvider.Theme = new DarkTheme();
                Invalidate();
                Refresh();
            }
            this.Text += $" (Máy chủ: {_serverAddress})";
        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = TEXTBOX_EMAIL.Text;
            string password = TEXTBOX_MATKHAU.Text;
            string role = "Admin";

            if (email != string.Empty || password != string.Empty)
            {
                try
                {
                    var request = new AuthRequest { Email = email, Password = password };
                    var response = _client.AdminAuthenticateUser(request);

                    if (response.ResponseCode == (int)HttpStatusCode.OK)
                    {
                        Shared.AccessToken = response.AccessToken;
                        // Authentication successful, open the main management form
                        Grpc.Core.Metadata headers = new Grpc.Core.Metadata
                            {
                                { "Authorization", $"Bearer {Shared.AccessToken}" }
                            };
                        role = response.ResponseMessage;

                        MainForm mainForm = new MainForm(_client, headers, TEXTBOX_EMAIL.Text, role); // Pass the server address
                        this.Hide();
                        mainForm.ShowDialog();
                        if (!Shared.IsExiting)
                        {
                            this.Show();
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập và mật khẩu không hợp lệ.", "Lỗi đăng nhập vào hệ thống", MessageBoxButtons.OK);
                    }
                }
                catch (Grpc.Core.RpcException ex)
                {
                    MessageBox.Show($"Server Error: {ex.Status.Detail}", "Lỗi hệ thống", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không hợp lệ.", "Lỗi đăng nhập", MessageBoxButtons.OK);
            }
        }

        private void buttonChangeIP_Click(object sender, EventArgs e)
        {
            string serverAddress = textBoxIPAddress.Text;
            try
            {
                var handler = new HttpClientHandler();
                var channel = GrpcChannel.ForAddress(serverAddress,
                    new GrpcChannelOptions { HttpHandler = handler });
                _client = new AdminServiceClient(channel);
                _serverAddress = serverAddress;
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["ServerAddress"].Value = serverAddress;
                config.Save(ConfigurationSaveMode.Modified);

                MessageBox.Show("Đã sửa địa chỉ thành công!", "Đổi thành công", MessageBoxButtons.OK);

                textBoxIPAddress.Text = serverAddress;
                this.Text = $"PolyTest Manager - Đăng nhập (Máy chủ: {serverAddress})";
            }
            catch
            {
                MessageBox.Show("Địa chỉ không hợp lệ!", "Đổi thất bại", MessageBoxButtons.OK);
            }
        }
    }
}
