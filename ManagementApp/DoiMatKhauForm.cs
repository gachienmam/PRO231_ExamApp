using ExamLibrary.Enum;
using ManagementApp.AdminProto;
using ManagementApp.Database;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ManagementApp.AdminProto.AdminService;

namespace ManagementApp
{
    public partial class DoiMatKhauForm : Form
    {
        private readonly AdminServiceClient _client;
        private readonly Grpc.Core.Metadata _headers;

        private string _currentUserEmail;

        private GrpcDatabaseHelper _dbHelper;

        public DoiMatKhauForm(AdminServiceClient client, Grpc.Core.Metadata headers, string currentUserEmail)
        {
            InitializeComponent();

            _client = client;
            _headers = headers;

            _currentUserEmail = currentUserEmail;

            _dbHelper = new GrpcDatabaseHelper(_client, _headers);
        }

        private void DoiMatKhauForm_Load(object sender, EventArgs e)
        {
            
        }

        private void BUTTONDOIMATKHAU_Click(object sender, EventArgs e)
        {
            if (TEXTBOXMATKHAUHIENTAI.Text.Trim().Length == 0)// kiem tra phai nhap data
            {
                MessageBox.Show("Bạn phải nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TEXTBOXMATKHAUHIENTAI.Focus();
                return;
            }
            else if (TEXTBOXMATKHAUMOI.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TEXTBOXMATKHAUMOI.Focus();
                return;
            }
            else if (TextBoxXNhapLaiMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lại mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TextBoxXNhapLaiMatKhau.Focus();
                return;
            }
            else if (TextBoxXNhapLaiMatKhau.Text.Trim() != TEXTBOXMATKHAUMOI.Text.Trim())
            {
                MessageBox.Show("Bạn phải nhập mật khẩu và nhập lại mật khẩu giống nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TEXTBOXMATKHAUMOI.Focus();
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn cập nhật mật khẩu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var requestPassword = new CommandRequest
                        {
                            RequestCode = (int)RemoteCommandType.REQUEST_ENCRYPTEDPASSWORD,
                            Command = TEXTBOXMATKHAUMOI.Text
                        };
                        string sql = $"UPDATE NguoiDung SET MatKhau = '{_client.ExecuteRemoteCommand(requestPassword, _headers).ResponseMessage}' WHERE Email = '{_currentUserEmail}';";
                        _dbHelper.ExecuteSqlNonQuery(sql);
                        CrownMessageBox.ShowInformation("Đã sửa người dùng", "Sửa thành công", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    }
                    catch (Exception ex)
                    {
                        CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    }
                }
                else
                {
                    //do something if NO
                    TEXTBOXMATKHAUHIENTAI.Text = null;
                    TEXTBOXMATKHAUMOI.Text = null;
                    TextBoxXNhapLaiMatKhau.Text = null;
                }
            }
        }

        private void BUTTONTHOAT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OpenNewForm()
        {
            //Application.Exit();
            Application.Run(new MainForm());
        }
    }
}
