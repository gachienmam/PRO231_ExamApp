using ExamServer;
using ReaLTaiizor.Controls;
using System.Net;
using static ExamServer.AdminService;

namespace ManagementApp
{
    public partial class DangNhapForm : Form
    {
        private readonly AdminServiceClient _client;
        private readonly string _serverAddress;

        public DangNhapForm()
        {
            InitializeComponent();
        }

        public DangNhapForm(string serverAddress)
        {
            InitializeComponent();
            _serverAddress = serverAddress;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = TEXTBOX_EMAIL.Text;
            string password = TEXTBOX_MATKHAU.Text;

            if(email != string.Empty || password != string.Empty)
            {
                try
                {
                    var request = new AuthRequest { Email = email, Password = password };
                    var response = _client.AuthenticateUser(request);

                    if (response.ResponseCode == (int)HttpStatusCode.OK)
                    {
                        // Authentication successful, open the main management form
                        MainForm mainForm = new MainForm(_serverAddress, response.AccessToken); // Pass the server address
                        this.Hide();
                        mainForm.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        CrownMessageBox.ShowError("Tên đăng nhập và mật khẩu không hợp lệ.", "Lỗi đăng nhập vào hệ thống", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    }
                }
                catch (Grpc.Core.RpcException ex)
                {
                    CrownMessageBox.ShowError($"gRPC Error: {ex.Status.Detail}", "Lỗi hệ thống", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
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
