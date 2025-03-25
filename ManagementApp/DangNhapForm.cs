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
        private readonly AdminServiceClient _client;
        private readonly string _serverAddress;

        #region Constructor
        public DangNhapForm()
        {
            InitializeComponent();
        }

        public DangNhapForm(string serverAddress)
        {
            InitializeComponent();
            _serverAddress = serverAddress;

            var handler = new HttpClientHandler();
            //handler.ServerCertificateCustomValidationCallback =
            //    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var channel = GrpcChannel.ForAddress(ConfigurationManager.AppSettings["ServerAddress"] ?? "https://localhost:50052",
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
                        MainForm mainForm = new MainForm(_client, headers); // Pass the server address
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
                        CrownMessageBox.ShowError("Tên đăng nhập và mật khẩu không hợp lệ.", "Lỗi đăng nhập vào hệ thống", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    }
                }
                catch (Grpc.Core.RpcException ex)
                {
                    CrownMessageBox.ShowError($"Server Error: {ex.Status.Detail}", "Lỗi hệ thống", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
                catch (Exception ex)
                {
                    CrownMessageBox.ShowError($"Error: {ex.Message}", "Lỗi hệ thống", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
            }
            else
            {
                CrownMessageBox.ShowError("Tên đăng nhập và mật khẩu không hợp lệ.", "Lỗi đăng nhập", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
            }
        }
    }
}
