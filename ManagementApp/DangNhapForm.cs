using ReaLTaiizor.Controls;
using static ExamServer.AdminService.AdminService;

namespace ManagementApp
{
    public partial class DangNhapForm : Form
    {
        public DangNhapForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            try
            {
                var request = new AdminServiceClient.AuthRequest { Email = email, Password = password };
                var response = _client.AuthenticateUser(request);

                if (response.IsAuthenticated)
                {
                    // Authentication successful, open the main management form
                    MainForm mainForm = new MainForm(_serverAddress); // Pass the server address
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close(); // Close the login form after the main form is closed
                }
                else
                {
                    CrownMessageBox.ShowError("Tên đăng nhập và mật khẩu không hợp lệ.", "Lỗi đăng nhập", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
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
    }
}
