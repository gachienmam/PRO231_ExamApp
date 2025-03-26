using static ReaLTaiizor.Helper.CrownHelper;
using System.Configuration;
using Grpc.Net.Client;
using StudentApp.ExamProto;
using ReaLTaiizor.Controls;
using System.Net;
using Google.Protobuf.WellKnownTypes;
using System.Security.Principal;

namespace StudentApp
{
    public partial class DangNhapForm : Form
    {
        private readonly ExamService.ExamServiceClient _client;
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
            handler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var channel = GrpcChannel.ForAddress(serverAddress,
                new GrpcChannelOptions { HttpHandler = handler });
            _client = new ExamService.ExamServiceClient(channel);
        }

        private void DangNhapForm_Load(object sender, EventArgs e)
        {
            //if (!IsAdministrator())
            //{
            //    CrownMessageBox.ShowError($"Phần mềm thi chưa được chạy bằng Admin. Xin hãy liên lạc với giám thị.", "Lỗi", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
            //    Application.Exit();
            //}
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


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textBoxMatKhauEmail.Text;
            string examid = textBoxMaDe.Text;
            string exampass = textBoxMatKhauDe.Text;

            if (email != string.Empty || password != string.Empty || examid != string.Empty || exampass != string.Empty)
            {
                try
                {
                    // Bước 1: Đăng nhập để lấy token
                    var authRequest = new AuthRequest { ThiSinhId = email, Password = password, ExamCode = examid, Timestamp = Timestamp.FromDateTime(DateTime.UtcNow) };
                    var authResponse = _client.ExamAuthenticateUser(authRequest);

                    if (authResponse.ResponseCode == (int)HttpStatusCode.OK)
                    {
                        // Bước 2: Lấy dữ liệu thi sau khi đăng nhập
                        var examRequest = new ExamRequest { ExamId = examid };
                        var headers = new Grpc.Core.Metadata
                        {
                            { "Authorization", $"Bearer {authResponse.AccessToken}" }
                        };
                        var examResponse = _client.GetExamData(examRequest, headers);
                        if (examResponse.ResponseCode == (int)HttpStatusCode.OK)
                        {
                            ExamForm examForm = new ExamForm(_client, headers, examResponse); // Pass the server address
                            this.Hide();
                            examForm.Show();
                            this.Close();
                        }
                        else
                        {
                            CrownMessageBox.ShowError("Không thể lấy đề thi từ hệ thống. Xin hãy liên lạc với giám thị.", "Lỗi hệ thống", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
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

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
            Invalidate();
            Refresh();
        }


        #region Function
        private bool IsAdministrator()
        {
            WindowsIdentity current = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        #endregion
    }
}
