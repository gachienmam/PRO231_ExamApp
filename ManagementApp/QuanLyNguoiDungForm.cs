using ExamLibrary.Enum;
using ManagementApp.AdminProto;
using ManagementApp.Database;
using ManagementApp.Helper;
using Newtonsoft.Json;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Enum.Material;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ManagementApp.AdminProto.AdminService;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ManagementApp
{
    public partial class QuanLyNguoiDungForm : Form
    {
        private readonly AdminServiceClient _client;
        private readonly Grpc.Core.Metadata _headers;

        private DataTable _dataTable;
        private GrpcDatabaseHelper _dbHelper;

        // Để kiểm tra có thay đổi mật khẩu không
        private string _originalPassword;

        public QuanLyNguoiDungForm(AdminServiceClient client, Grpc.Core.Metadata headers)
        {
            InitializeComponent();
            _client = client;
            _headers = headers;

            _dbHelper = new GrpcDatabaseHelper(_client, _headers);
        }

        private async void QuanLyNguoiDungForm_Load(object sender, EventArgs e)
        {
            await LoadDataGridViewAsync();
            buttonThemND.PerformClick();
        }

        private void dataGridViewNguoiDung_Click(object sender, EventArgs e)
        {
            if (dataGridViewNguoiDung.Rows.Count > 1)
            {
                buttonLuuND.Enabled = false;
                textBoxMaND.Focus();
                textBoxMaND.Enabled = false;
                textBoxHoTenND.Enabled = true;
                textBoxEmailND.Enabled = true;
                textBoxMKND.Enabled = true;
                radioButtonAdmin.Enabled = true;
                radioButtonGV.Enabled = true;
                buttonSuaND.Enabled = true;
                buttonXoaND.Enabled = true;
                textBoxMaND.Text = dataGridViewNguoiDung.CurrentRow.Cells[0].Value.ToString();
                textBoxHoTenND.Text = dataGridViewNguoiDung.CurrentRow.Cells[1].Value.ToString();
                textBoxEmailND.Text = dataGridViewNguoiDung.CurrentRow.Cells[2].Value.ToString();
                textBoxMKND.Text = dataGridViewNguoiDung.CurrentRow.Cells[3].Value.ToString();
                _originalPassword = textBoxMKND.Text;
                string VaiTro = dataGridViewNguoiDung.CurrentRow.Cells[4].Value.ToString();
                if (VaiTro == "Admin")
                    radioButtonAdmin.Checked = true;
                else
                    radioButtonGV.Checked = true;
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tabControl1.SelectedIndex = 0;
        }

        private void buttonThemND_Click(object sender, EventArgs e)
        {
            textBoxMaND.Enabled = true;
            textBoxHoTenND.Text = string.Empty;
            textBoxHoTenND.Enabled = true;
            textBoxMKND.Text = string.Empty;
            _originalPassword = string.Empty;
            textBoxMKND.Enabled = true;
            textBoxEmailND.Text = string.Empty;
            textBoxHoTenND.Text = string.Empty;
            textBoxHoTenND.Enabled = true;
            textBoxEmailND.Enabled = true;
            radioButtonGV.Enabled = true;
            radioButtonAdmin.Enabled = true;
            buttonLuuND.Enabled = true;
            buttonSuaND.Enabled = false;
            buttonXoaND.Enabled = false;
            radioButtonGV.Checked = false;
            radioButtonAdmin.Checked = false;
            textBoxEmailND.Focus();
        }

        private void buttonLuuND_Click(object sender, EventArgs e)
        {
            string email;
            string VaiTro = "GiangVien";//GV
            if (radioButtonAdmin.Checked)
                VaiTro = "Admin";// Admin

            if (textBoxEmailND.Text.Trim().Length == 0)// kiem tra phai nhap email
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxEmailND.Focus();
                return;
            }
            else if (!IsValid(textBoxEmailND.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập đúng định dang email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxEmailND.Focus();
                return;
            }
            if (textBoxHoTenND.Text.Trim().Length == 0)// kiem tra phai nhap data
            {
                MessageBox.Show("Bạn phải nhập Họ tên người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHoTenND.Focus();
                return;
            }
            if (textBoxMKND.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxMKND.Focus();
                return;
            }

            if (radioButtonAdmin.Checked == false && radioButtonGV.Checked == false)// kiem tra phai check tình trạng
            {
                MessageBox.Show("Bạn phải chọn vai trò người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHoTenND.Focus();
                return;
            }
            else
            {
                try
                {
                    var requestPassword = new CommandRequest
                    {
                        RequestCode = (int)RemoteCommandType.REQUEST_ENCRYPTEDPASSWORD,
                        Command = textBoxMKND.Text
                    };
                    var sql = $"EXEC sp_InsertNguoiDung @MaNguoiDung = '{textBoxMaND.Text.Trim()}', @HoTen = N'{textBoxHoTenND.Text.Trim()}', @Email = '{textBoxEmailND.Text.Trim()}', @MatKhau = '{_client.ExecuteRemoteCommand(requestPassword, _headers).ResponseMessage}', @VaiTro = N'{VaiTro}'";

                    _dbHelper.ExecuteSqlNonQuery(sql);
                    LoadDataGridView();
                    SendMailToNguoiDung(false, textBoxEmailND.Text, textBoxMKND.Text);
                    tabControl1.SelectedIndex = 1;
                    CrownMessageBox.ShowInformation("Đã tạo người dùng mới", "Tạo thành công", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
                catch (Exception ex)
                {
                    CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }

            }
        }

        private void buttonSuaND_Click(object sender, EventArgs e)
        {
            string VaiTro = "GiangVien";//GV
            if (radioButtonAdmin.Checked)
                VaiTro = "Admin";// Admin

            if (textBoxEmailND.Text.Trim().Length == 0)// kiem tra phai nhap email
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxEmailND.Focus();
                return;
            }
            else if (!IsValid(textBoxEmailND.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập đúng định dạng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxEmailND.Focus();
                return;
            }
            if (textBoxHoTenND.Text.Trim().Length == 0)// kiem tra phai nhap data
            {
                MessageBox.Show("Bạn phải nhập Họ tên người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHoTenND.Focus();
                return;
            }
            if (textBoxMKND.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxMKND.Focus();
                return;
            }

            if (radioButtonAdmin.Checked == false && radioButtonGV.Checked == false)// kiem tra phai check tình trạng
            {
                MessageBox.Show("Bạn phải chọn Tình trạng người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHoTenND.Focus();
                return;
            }
            else
            {
                try
                {
                    string sql = string.Empty;
                    // Kiểm tra nếu có cần đổi mật khẩu hay không
                    if(_originalPassword != textBoxMKND.Text)
                    {
                        var requestPassword = new CommandRequest
                        {
                            RequestCode = (int)RemoteCommandType.REQUEST_ENCRYPTEDPASSWORD,
                            Command = textBoxMKND.Text
                        };
                        sql = $"UPDATE NguoiDung SET HoTen = N'{textBoxHoTenND.Text}', Email = '{textBoxEmailND.Text}', MatKhau = '{_client.ExecuteRemoteCommand(requestPassword, _headers).ResponseMessage}', VaiTro = N'{VaiTro}' WHERE MaNguoiDung = '{textBoxMaND.Text}';";
                        _dbHelper.ExecuteSqlNonQuery(sql);
                        SendMailToNguoiDung(false, textBoxEmailND.Text, textBoxMKND.Text);
                    }
                    else
                    {
                        sql = $"UPDATE NguoiDung SET HoTen = N'{textBoxHoTenND.Text}', Email = '{textBoxEmailND.Text}', VaiTro = N'{VaiTro}' WHERE MaNguoiDung = '{textBoxMaND.Text}';";
                        _dbHelper.ExecuteSqlNonQuery(sql);
                    }

                    LoadDataGridView();
                    tabControl1.SelectedIndex = 1;
                    CrownMessageBox.ShowInformation("Đã sửa người dùng", "Sửa thành công", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
                catch (Exception ex)
                {
                    CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
            }
        }

        private void buttonXoaND_Click(object sender, EventArgs e)
        {
            string soDT = textBoxMaND.Text;
            if (CrownMessageBox.ShowInformation("Bạn có chắc muốn xóa dữ liệu người dùng?", "Confirm", ReaLTaiizor.Enum.Crown.DialogButton.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = string.Format("EXEC sp_DeleteNguoiDung " + textBoxMaND.Text);
                    var result = _dbHelper.ExecuteSqlNonQuery(sql);
                    LoadDataGridView();
                    tabControl1.SelectedIndex = 1;
                    CrownMessageBox.ShowInformation("Đã xóa người dùng", "Xóa thành công", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
                catch (Exception ex)
                {
                    CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
            }
            else
            {
                //do something if NO
                ResetValues();
            }
        }

        private void crownButtonTimKiem_Click(object sender, EventArgs e)
        {
            string search = textBoxTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Vui lòng nhập mã người dùng hoặc địa chỉ email hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTimKiem.Focus();
                return;
            }

            DataTable dataTable = new DataTable();
            // Gọi phương thức tìm kiếm
            try
            {
                string sql = $"SELECT * FROM NguoiDung WHERE MaNguoiDung LIKE '%{search}%' OR HoTen LIKE '%{search}%' OR Email LIKE '%{search}%';";
                dataTable = _dbHelper.ExecuteSqlReader(sql);
            }
            catch (Exception ex)
            {
                CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
            }

            if (dataTable.Rows.Count > 0)
            {
                dataGridViewNguoiDung.DataSource = dataTable;
                tabControl1.SelectedIndex = 1;
                // Đặt tiêu đề cho các cột
                dataGridViewNguoiDung.Columns[0].HeaderText = "Mã người dùng";
                dataGridViewNguoiDung.Columns[1].HeaderText = "Họ và tên";
                dataGridViewNguoiDung.Columns[2].HeaderText = "Email";
                dataGridViewNguoiDung.Columns[3].HeaderText = "Mật khẩu";
                dataGridViewNguoiDung.Columns[4].HeaderText = "Số điện Thoại";
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng nào phù hợp tiêu chí tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxTimKiem.Focus();
            }

            // Đặt lại giá trị
            ResetValues();
        }

        private void buttonDanhSachND_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        // Phương thức kiểm tra địa chỉ email hợp lệ
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        #region Function
        private async Task LoadDataGridViewAsync()
        {
            _dataTable = await _dbHelper.ExecuteSqlReaderAsync("SELECT * FROM NguoiDung");
            dataGridViewNguoiDung.DataSource = _dataTable;

            dataGridViewNguoiDung.Columns[0].HeaderText = "Mã";
            dataGridViewNguoiDung.Columns[1].HeaderText = "Họ và tên";
            dataGridViewNguoiDung.Columns[2].HeaderText = "Email";
            dataGridViewNguoiDung.Columns[3].HeaderText = "Mật khẩu";
            dataGridViewNguoiDung.Columns[4].HeaderText = "Vai trò";
        }
        private void LoadDataGridView()
        {
            _dataTable = _dbHelper.ExecuteSqlReader("SELECT * FROM NguoiDung");
            dataGridViewNguoiDung.DataSource = _dataTable;

            dataGridViewNguoiDung.Columns[0].HeaderText = "Mã";
            dataGridViewNguoiDung.Columns[1].HeaderText = "Họ và tên";
            dataGridViewNguoiDung.Columns[2].HeaderText = "Email";
            dataGridViewNguoiDung.Columns[3].HeaderText = "Mật khẩu";
            dataGridViewNguoiDung.Columns[4].HeaderText = "Vai trò";
        }

        private void ResetValues()
        {
            textBoxEmailND.Text = null;
            textBoxHoTenND.Text = null;
            textBoxHoTenND.Text = null;
            textBoxHoTenND.Enabled = false;
            textBoxEmailND.Enabled = false;
            textBoxHoTenND.Enabled = false;
            textBoxMKND.Text = null;
            textBoxMKND.Enabled = false;
            radioButtonAdmin.Enabled = false;
            radioButtonGV.Enabled = false;
            buttonThemND.Enabled = true;
            buttonLuuND.Enabled = false;
            buttonSuaND.Enabled = false;
            buttonXoaND.Enabled = false;
        }
        public bool IsValid(string emailaddress)// check rule email
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void SendMailToNguoiDung(bool isNewUser, string email, string newPass)
        {
            if (isNewUser)
            {
                string emailBody = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>N2 QLBH SOF2051</title>\r\n    <style>\r\n        body {{\r\n            font-family: Segoe UI, sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }}\r\n        .container {{\r\n            width: 100%;\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            background-color: #ffffff;\r\n            padding: 20px;\r\n            border-radius: 8px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }}\r\n        .header {{\r\n            text-align: center;\r\n            padding: 20px 0;\r\n            background-color: #007BFF;\r\n            color: #ffffff;\r\n            border-radius: 8px 8px 0 0;\r\n        }}\r\n        .headerImage {{\r\n            text-align: center\r\n        }}\r\n\t.headerImage img{{\r\n            padding: 20px;            \r\n            border-radius: 128px;\r\n            width: 256px;\r\n\t}}\r\n        .header h1 {{\r\n            margin: 0;\r\n        }}\r\n        .content {{\r\n            padding: 20px;\r\n            color: #333333;\r\n        }}\r\n        .content p {{\r\n            line-height: 1.6;\r\n        }}\r\n        .content .password-block {{\r\n            display: flex;\r\n            justify-content: center;\r\n            align-items: center;\r\n        }}\r\n        .footer {{\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            background-color: #f4f4f4;\r\n            color: #777777;\r\n            border-radius: 0 0 8px 8px;\r\n        }}\r\n        .footer p {{\r\n            margin: 0;\r\n        }}\r\n        .password {{\r\n            display: inline-block;\r\n            padding: 10px 20px;\r\n            margin: 20px 0;\r\n            background-color: #007BFF;\r\n            color: #ffffff;\r\n            text-decoration: none;\r\n            border-radius: 5px;\r\n        }}\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"headerImage\">\r\n           <img class=\"headerImage\" src=\"cid:logoImage\"/>\r\n        </div>\r\n        <div class=\"header\">\r\n            <h1>PolyTest System</h1>\r\n            <h2>By Pupu và những người bạn (Nhóm 2) </h2>\r\n        </div>\r\n        <div class=\"content\">\r\n            <p>Xin chào {email},</p>\r\n            <p>Anh em tôi muốn chào thành viên mới để cai trị hệ thống.</p>\r\n            <p>Ở dưới là mật khẩu mới của bạn:</p>\r\n            <div class=\"password-block\">\r\n              <p class=\"password\">{newPass}</p>\r\n            </div>\r\n            <p>Sau khi đăng nhập, xin mời bạn đổi mật khẩu mới để đảm bảo sự bảo mật khi sử dụng phần mềm siêu múp này.</p>\r\n            <p>Trân trọng,<br>Nhóm 2</p>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p>&copy; 2025 Nhóm 2. Bảo lưu mọi quyền. Trộm thì ra đường gặp nhiều xui xẻo</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>";
                EmailHelper.SendMail(email, $"Chào mừng người dùng mới", emailBody);
            }
            else
            {
                string emailBody = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>N2 QLBH SOF2051</title>\r\n    <style>\r\n        body {{\r\n            font-family: Segoe UI, sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }}\r\n        .container {{\r\n            width: 100%;\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            background-color: #ffffff;\r\n            padding: 20px;\r\n            border-radius: 8px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }}\r\n        .header {{\r\n            text-align: center;\r\n            padding: 20px 0;\r\n            background-color: #007BFF;\r\n            color: #ffffff;\r\n            border-radius: 8px 8px 0 0;\r\n        }}\r\n        .headerImage {{\r\n            text-align: center\r\n        }}\r\n\t.headerImage img{{\r\n            padding: 20px;            \r\n            border-radius: 128px;\r\n            width: 256px;\r\n\t}}\r\n        .header h1 {{\r\n            margin: 0;\r\n        }}\r\n        .content {{\r\n            padding: 20px;\r\n            color: #333333;\r\n        }}\r\n        .content p {{\r\n            line-height: 1.6;\r\n        }}\r\n        .content .password-block {{\r\n            display: flex;\r\n            justify-content: center;\r\n            align-items: center;\r\n        }}\r\n        .footer {{\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            background-color: #f4f4f4;\r\n            color: #777777;\r\n            border-radius: 0 0 8px 8px;\r\n        }}\r\n        .footer p {{\r\n            margin: 0;\r\n        }}\r\n        .password {{\r\n            display: inline-block;\r\n            padding: 10px 20px;\r\n            margin: 20px 0;\r\n            background-color: #007BFF;\r\n            color: #ffffff;\r\n            text-decoration: none;\r\n            border-radius: 5px;\r\n        }}\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"headerImage\">\r\n           <img class=\"headerImage\" src=\"cid:logoImage\"/>\r\n        </div>\r\n        <div class=\"header\">\r\n            <h1>PolyTest System</h1>\r\n            <h2>By Pupu và những người bạn (Nhóm 2) </h2>\r\n        </div>\r\n        <div class=\"content\">\r\n            <p>Xin chào {email},</p>\r\n            <p>Bạn đã được hệ thống đổi mật khẩu mới.</p>\r\n            <p>Ở dưới là mật khẩu mới của bạn:</p>\r\n            <div class=\"password-block\">\r\n              <p class=\"password\">{newPass}</p>\r\n            </div>\r\n            <p>Sau khi đăng nhập, xin mời bạn đổi mật khẩu mới để đảm bảo sự bảo mật khi sử dụng phần mềm siêu múp này.</p>\r\n            <p>Trân trọng,<br>Nhóm 2</p>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p>&copy; 2025 Nhóm 2. Bảo lưu mọi quyền. Trộm thì ra đường gặp nhiều xui xẻo</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>";
                EmailHelper.SendMail(email, $"Đổi mật khẩu", emailBody);
            }
        }
        #endregion
    }
}
