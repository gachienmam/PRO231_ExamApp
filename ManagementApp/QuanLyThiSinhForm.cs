using ExamLibrary.Enum;
using ManagementApp.AdminProto;
using ManagementApp.Database;
using ManagementApp.Helper;
using Newtonsoft.Json;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ManagementApp.AdminProto.AdminService;

namespace ManagementApp
{
    public partial class QuanLyThiSinhForm : Form
    {
        private readonly AdminServiceClient _client;
        private readonly Grpc.Core.Metadata _headers;

        private DataTable _dataTable;
        private GrpcDatabaseHelper _dbHelper;

        // Để kiểm tra có thay đổi mật khẩu không
        private string _originalPassword;

        public QuanLyThiSinhForm(AdminServiceClient client, Grpc.Core.Metadata headers)
        {
            InitializeComponent();
            _client = client;
            _headers = headers;

            _dbHelper = new GrpcDatabaseHelper(_client, _headers);
        }

        private async void QuanLyThiSinhForm_Load(object sender, EventArgs e)
        {
            await LoadDataGridViewAsync();
            buttonThemTS.PerformClick();
        }

        private void buttonThemTS_Click(object sender, EventArgs e)
        {
            textBoxMaTS.Text = string.Empty;
            textBoxHoTenTS.Text = string.Empty;
            textBoxSDTTS.Text = string.Empty;
            textBoxEmailTS.Text = string.Empty;
            textBoxMKTS.Text = string.Empty;
            radioButtonHDTS.Checked = true;
            radioButtonKhoaTS.Checked = true;

            textBoxMaTS.Enabled = true;
            textBoxHoTenTS.Enabled = true;
            textBoxSDTTS.Enabled = true;
            textBoxEmailTS.Enabled = true;
            textBoxMKTS.Enabled = true;
            _originalPassword = string.Empty;
            radioButtonHDTS.Enabled = true;
            radioButtonKhoaTS.Enabled = true;

            buttonThemTS.Enabled = true;
            buttonLuuTS.Enabled = true;
            buttonSuaTS.Enabled = false;
            buttonXoaTS.Enabled = false;
        }

        private void buttonLuuTS_Click(object sender, EventArgs e)
        {
            string email;

            int trangThai = 0; // Mặc định là khóa
            if (radioButtonHDTS.Checked)
            {
                trangThai = 1; // Nếu radioButtonHDTS được chọn, trạng thái là hoạt động
            }

            int intDienThoai;
            bool isInt = int.TryParse(textBoxSDTTS.Text.Trim().ToString(), out intDienThoai);
            if (isInt == false)
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
            }
            if (textBoxEmailTS.Text.Trim().Length == 0)// kiem tra phai nhap email
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxEmailTS.Focus();
                return;
            }
            else if (!IsValid(textBoxEmailTS.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập đúng định dang email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxEmailTS.Focus();
                return;
            }
            if (textBoxHoTenTS.Text.Trim().Length == 0)// kiem tra phai nhap data
            {
                MessageBox.Show("Bạn phải nhập Họ tên thí sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHoTenTS.Focus();
                return;
            }
            if (textBoxMKTS.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxMKTS.Focus();
                return;
            }
            if (!isInt || float.Parse(textBoxSDTTS.Text) <= 0)// kiem tra so điện thoại
            {
                MessageBox.Show("Bạn phải nhập số điện thoại >=0,chỉ số", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxSDTTS.Focus();
                return;
            }

            if (dateTimePickerNgaySinhTS.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("Bạn phải chọn ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePickerNgaySinhTS.Focus();
                return;
            }
            if (radioButtonKhoaTS.Checked == false && radioButtonHDTS.Checked == false)// kiem tra phai check tình trạng
            {
                MessageBox.Show("Bạn phải chon trạng thái thí sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHoTenTS.Focus();
                return;
            }


            else
            {
                try
                {
                    var requestPassword = new CommandRequest
                    {
                        RequestCode = (int)RemoteCommandType.REQUEST_ENCRYPTEDPASSWORD,
                        Command = textBoxMKTS.Text
                    };
                    var sql = string.Format("EXEC sp_InsertThiSinh @MaThiSinh = N'{0}', @HoTen = N'{1}', @Email = N'{2}', @MatKhau = N'{3}', @NgaySinh = '{4}', @SoDienThoai = '{5}', @TrangThai = {6}",
                            textBoxMaTS.Text.Trim(),
                            textBoxHoTenTS.Text.Trim(),
                            textBoxEmailTS.Text.Trim(),
                            _client.ExecuteRemoteCommand(requestPassword, _headers).ResponseMessage,
                            dateTimePickerNgaySinhTS.Value.ToString("yyyy-MM-dd"),
                            textBoxSDTTS.Text.Trim(),
                            trangThai);
                    _dbHelper.ExecuteSqlNonQuery(sql);
                    LoadDataGridView();
                    SendMailToThiSinh(true, textBoxEmailTS.Text, textBoxMKTS.Text);
                    tabControl1.SelectedIndex = 1;
                    CrownMessageBox.ShowInformation("Đã tạo thí sính mới", "Tạo thành công", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
                catch (Exception ex)
                {
                    CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
            }
        }

        private void buttonXoaTS_Click(object sender, EventArgs e)
        {
            int trangThai = 0; // Mặc định là khóa
            if (radioButtonHDTS.Checked)
            {
                trangThai = 1; // Nếu radioButtonHDTS được chọn, trạng thái là hoạt động
            }
            string soDT = textBoxMaTS.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu thí sinh", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = string.Format("EXEC sp_DeleteThiSinh " + textBoxMaTS.Text);
                    var result = _dbHelper.ExecuteSqlNonQuery(sql);
                    LoadDataGridView();
                    tabControl1.SelectedIndex = 1;
                    CrownMessageBox.ShowInformation("Đã xóa thí sính", "Xóa thành công", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
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

        private void buttonSuaTS_Click(object sender, EventArgs e)
        {
            string email;

            int trangThai = 0; // Mặc định là khóa
            if (radioButtonHDTS.Checked)
            {
                trangThai = 1; // Nếu radioButtonHDTS được chọn, trạng thái là hoạt động
            }
            int intDienThoai;
            bool isInt = int.TryParse(textBoxSDTTS.Text.Trim().ToString(), out intDienThoai);
            if (textBoxEmailTS.Text.Trim().Length == 0)// kiem tra phai nhap email
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxEmailTS.Focus();
                return;
            }
            else if (!IsValid(textBoxEmailTS.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập đúng định dang email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxEmailTS.Focus();
                return;
            }
            if (textBoxHoTenTS.Text.Trim().Length == 0)// kiem tra phai nhap data
            {
                MessageBox.Show("Bạn phải nhập Họ tên thí sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHoTenTS.Focus();
                return;
            }
            if (textBoxMKTS.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxMKTS.Focus();
                return;
            }
            if (!isInt || float.Parse(textBoxSDTTS.Text) <= 0)// kiem tra so điện thoại
            {
                MessageBox.Show("Bạn phải nhập số điện thoại >=0,chỉ số", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxSDTTS.Focus();
                return;
            }

            if (dateTimePickerNgaySinhTS.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("Bạn phải chọn ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePickerNgaySinhTS.Focus();
                return;
            }


            if (radioButtonHDTS.Checked == false && radioButtonKhoaTS.Checked == false)// kiem tra phai check tình trạng
            {
                MessageBox.Show("Bạn phải chon tình trạng thí sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHoTenTS.Focus();
                return;
            }
            else
            {
                try
                {
                    string sql = string.Empty;
                    if(_originalPassword != textBoxMKTS.Text)
                    {
                        var requestPassword = new CommandRequest
                        {
                            RequestCode = (int)RemoteCommandType.REQUEST_ENCRYPTEDPASSWORD,
                            Command = textBoxMKTS.Text
                        };
                        sql = $"EXEC sp_UpdateThiSinh @MaThiSinh = N'{textBoxMaTS.Text.Trim()}', @HoTen = N'{textBoxHoTenTS.Text.Trim()}', @Email = N'{textBoxEmailTS.Text.Trim()}', @MatKhau = N'{_client.ExecuteRemoteCommand(requestPassword, _headers).ResponseMessage}', @NgaySinh '{dateTimePickerNgaySinhTS.Value.ToString("yyyy-MM-dd")}', @SoDienThoai = N'{textBoxSDTTS.Text.Trim()}', @TrangThai = {trangThai}";
                        SendMailToThiSinh(false, textBoxEmailTS.Text, textBoxMKTS.Text);
                    }
                    else
                    {
                        sql = $"UPDATE ThiSinh SET HoTen = N'{textBoxHoTenTS.Text.Trim()}', Email = N'{textBoxEmailTS.Text.Trim()}', NgaySinh = '{dateTimePickerNgaySinhTS.Value.ToString("yyyy-MM-dd")}', SoDienThoai = N'{textBoxSDTTS.Text.Trim()}', TrangThai = {trangThai} WHERE MaThiSinh = N'{textBoxMaTS.Text.Trim()}'";
                    }
                    _dbHelper.ExecuteSqlNonQuery(sql);
                    LoadDataGridView();
                    tabControl1.SelectedIndex = 1;
                    CrownMessageBox.ShowInformation("Đã sửa thí sính", "Sửa thành công", ReaLTaiizor.Enum.Crown.DialogButton.Ok);

                }
                catch (Exception ex)
                {
                    CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
            }
        }

        private void buttonDanhSachTS_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }



        private void crownButtonTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = textBoxTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(maSV))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên để tìm kiếm.");
                    return;
                }

                DataTable dt = (DataTable)dataGridViewTS.DataSource;
                if (dt != null)
                {
                    DataView dv = new DataView(dt);
                    dv.RowFilter = $"MaThiSinh = '{maSV}'";
                    dataGridViewTS.DataSource = dv;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để tìm kiếm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }


            ResetValues();
        }

        private async void buttonDanhSachTS_Click_1(object sender, EventArgs e)
        {
            try
            {
                await LoadDataGridViewAsync();
            }
            catch (Exception ex)
            {
                CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
            }
        }

        private void dataGridViewTS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra số lượng cột trước khi đặt HeaderText
            if (dataGridViewTS.Columns.Count >= 7)
            {
                dataGridViewTS.Columns[0].HeaderText = "Mã thí sinh";
                dataGridViewTS.Columns[1].HeaderText = "Họ và tên";
                dataGridViewTS.Columns[2].HeaderText = "Email";
                dataGridViewTS.Columns[3].HeaderText = "Mật khẩu";
                dataGridViewTS.Columns[4].HeaderText = "Ngày sinh";
                dataGridViewTS.Columns[5].HeaderText = "Số điện thoại";
                dataGridViewTS.Columns[6].HeaderText = "Trạng thái";
            }

            if (dataGridViewTS.Rows.Count > 1)
            {
                buttonLuuTS.Enabled = false;
                textBoxMaTS.Focus();
                textBoxMaTS.Enabled = false;
                textBoxHoTenTS.Enabled = true;
                textBoxSDTTS.Enabled = true;
                textBoxEmailTS.Enabled = true;
                textBoxMKTS.Enabled = true;
                dateTimePickerNgaySinhTS.Enabled = true;
                radioButtonKhoaTS.Enabled = true;
                radioButtonHDTS.Enabled = true;
                buttonSuaTS.Enabled = true;
                buttonXoaTS.Enabled = true;
                textBoxMaTS.Text = dataGridViewTS.CurrentRow.Cells[0].Value.ToString();
                textBoxHoTenTS.Text = dataGridViewTS.CurrentRow.Cells[1].Value.ToString();
                textBoxEmailTS.Text = dataGridViewTS.CurrentRow.Cells[2].Value.ToString();
                textBoxMKTS.Text = dataGridViewTS.CurrentRow.Cells[3].Value.ToString();
                _originalPassword = textBoxMKTS.Text;
                dateTimePickerNgaySinhTS.Text = dataGridViewTS.CurrentRow.Cells[4].Value.ToString();
                textBoxSDTTS.Text = dataGridViewTS.CurrentRow.Cells[5].Value.ToString();
                string TrangThai = dataGridViewTS.CurrentRow.Cells[6].Value.ToString();
                if (TrangThai == "0")
                    radioButtonKhoaTS.Checked = true;
                else
                    radioButtonHDTS.Checked = true;
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tabControl1.SelectedIndex = 0;
        }

        #region Function
        private async Task LoadDataGridViewAsync()
        {
            try
            {
                _dataTable = await _dbHelper.ExecuteSqlReaderAsync("SELECT * FROM ThiSinh");
                dataGridViewTS.DataSource = _dataTable;

                // Kiểm tra số lượng cột trước khi đặt HeaderText
                if (dataGridViewTS.Columns.Count >= 7)
                {
                    dataGridViewTS.Columns[0].HeaderText = "Mã thí sinh";
                    dataGridViewTS.Columns[1].HeaderText = "Họ và tên";
                    dataGridViewTS.Columns[2].HeaderText = "Email";
                    dataGridViewTS.Columns[3].HeaderText = "Mật khẩu";
                    dataGridViewTS.Columns[4].HeaderText = "Ngày sinh";
                    dataGridViewTS.Columns[5].HeaderText = "Số điện thoại";
                    dataGridViewTS.Columns[6].HeaderText = "Trạng thái";
                }
            }
            catch (Exception ex)
            {
                CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi dữ liệu", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
            }
        }

        private void LoadDataGridView()
        {
            try
            {
                _dataTable = _dbHelper.ExecuteSqlReader("SELECT * FROM ThiSinh");
                dataGridViewTS.DataSource = _dataTable;

                // Kiểm tra số lượng cột trước khi đặt HeaderText
                if (dataGridViewTS.Columns.Count >= 7)
                {
                    dataGridViewTS.Columns[0].HeaderText = "Mã thí sinh";
                    dataGridViewTS.Columns[1].HeaderText = "Họ và tên";
                    dataGridViewTS.Columns[2].HeaderText = "Email";
                    dataGridViewTS.Columns[3].HeaderText = "Mật khẩu";
                    dataGridViewTS.Columns[4].HeaderText = "Ngày sinh";
                    dataGridViewTS.Columns[5].HeaderText = "Số điện thoại";
                    dataGridViewTS.Columns[6].HeaderText = "Trạng thái";
                }
            }
            catch (Exception ex)
            {
                CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi dữ liệu", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
            }
        }
        private void ResetValues()
        {
            textBoxMaTS.Text = null;
            textBoxHoTenTS.Text = null;
            textBoxSDTTS.Text = null;
            textBoxEmailTS.Text = null;
            textBoxMKTS.Text = null;
            radioButtonHDTS.Checked = false;
            radioButtonKhoaTS.Checked = false;

            textBoxMaTS.Enabled = false;
            textBoxHoTenTS.Enabled = false;
            textBoxSDTTS.Enabled = false;
            textBoxEmailTS.Enabled = false;
            textBoxMKTS.Enabled = false;
            radioButtonHDTS.Enabled = false;
            radioButtonKhoaTS.Enabled = false;
            dataGridViewTS.Enabled = true;

            buttonThemTS.Enabled = true;
            buttonLuuTS.Enabled = false;
            buttonSuaTS.Enabled = false;
            buttonXoaTS.Enabled = false;

            textBoxEmailTS.Focus();
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

        private void SendMailToThiSinh(bool isNewUser, string email, string newPass)
        {
            if (isNewUser)
            {
                string emailBody = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>N2 PolyTest PRO231</title>\r\n    <style>\r\n        body {{\r\n            font-family: Segoe UI, sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }}\r\n        .container {{\r\n            width: 100%;\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            background-color: #ffffff;\r\n            padding: 20px;\r\n            border-radius: 8px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }}\r\n        .header {{\r\n            text-align: center;\r\n            padding: 20px 0;\r\n            background-color: #007BFF;\r\n            color: #ffffff;\r\n            border-radius: 8px 8px 0 0;\r\n        }}\r\n        .headerImage {{\r\n            text-align: center\r\n        }}\r\n\t.headerImage img{{\r\n            padding: 20px;            \r\n            border-radius: 128px;\r\n            width: 256px;\r\n\t}}\r\n        .header h1 {{\r\n            margin: 0;\r\n        }}\r\n        .content {{\r\n            padding: 20px;\r\n            color: #333333;\r\n        }}\r\n        .content p {{\r\n            line-height: 1.6;\r\n        }}\r\n        .content .password-block {{\r\n            display: flex;\r\n            justify-content: center;\r\n            align-items: center;\r\n        }}\r\n        .footer {{\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            background-color: #f4f4f4;\r\n            color: #777777;\r\n            border-radius: 0 0 8px 8px;\r\n        }}\r\n        .footer p {{\r\n            margin: 0;\r\n        }}\r\n        .password {{\r\n            display: inline-block;\r\n            padding: 10px 20px;\r\n            margin: 20px 0;\r\n            background-color: #007BFF;\r\n            color: #ffffff;\r\n            text-decoration: none;\r\n            border-radius: 5px;\r\n        }}\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"headerImage\">\r\n           <img class=\"headerImage\" src=\"cid:logoImage\"/>\r\n        </div>\r\n        <div class=\"header\">\r\n            <h1>PolyTest System</h1>\r\n            <h2>By Pupu và những người bạn (Nhóm 2) </h2>\r\n        </div>\r\n        <div class=\"content\">\r\n            <p>Xin chào {email},</p>\r\n            <p>Bạn đã được đăng ký một tài khoản mới vào hệ thống PolyTest.</p>\r\n            <p>Ở dưới là mật khẩu mới của bạn:</p>\r\n            <div class=\"password-block\">\r\n              <p class=\"password\">{newPass}</p>\r\n            </div>\r\n            <p>Bạn sẽ sử dụng email của mình và mật khẩu trên để đăng nhập cho những lần thi sắp tới.</p>\r\n            <p>Trân trọng,<br>PolyTest</p>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p>&copy; 2025 Nhóm 2. Bảo lưu mọi quyền. Trộm thì ra đường gặp nhiều xui xẻo</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>";
                EmailHelper.SendMail(email, $"Chào mừng thí sinh mới", emailBody);
            }
            else
            {
                string emailBody = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>N2 PolyTest PRO231</title>\r\n    <style>\r\n        body {{\r\n            font-family: Segoe UI, sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }}\r\n        .container {{\r\n            width: 100%;\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            background-color: #ffffff;\r\n            padding: 20px;\r\n            border-radius: 8px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }}\r\n        .header {{\r\n            text-align: center;\r\n            padding: 20px 0;\r\n            background-color: #007BFF;\r\n            color: #ffffff;\r\n            border-radius: 8px 8px 0 0;\r\n        }}\r\n        .headerImage {{\r\n            text-align: center\r\n        }}\r\n\t.headerImage img{{\r\n            padding: 20px;            \r\n            border-radius: 128px;\r\n            width: 256px;\r\n\t}}\r\n        .header h1 {{\r\n            margin: 0;\r\n        }}\r\n        .content {{\r\n            padding: 20px;\r\n            color: #333333;\r\n        }}\r\n        .content p {{\r\n            line-height: 1.6;\r\n        }}\r\n        .content .password-block {{\r\n            display: flex;\r\n            justify-content: center;\r\n            align-items: center;\r\n        }}\r\n        .footer {{\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            background-color: #f4f4f4;\r\n            color: #777777;\r\n            border-radius: 0 0 8px 8px;\r\n        }}\r\n        .footer p {{\r\n            margin: 0;\r\n        }}\r\n        .password {{\r\n            display: inline-block;\r\n            padding: 10px 20px;\r\n            margin: 20px 0;\r\n            background-color: #007BFF;\r\n            color: #ffffff;\r\n            text-decoration: none;\r\n            border-radius: 5px;\r\n        }}\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"headerImage\">\r\n           <img class=\"headerImage\" src=\"cid:logoImage\"/>\r\n        </div>\r\n        <div class=\"header\">\r\n            <h1>PolyTest System</h1>\r\n            <h2>By Pupu và những người bạn (Nhóm 2) </h2>\r\n        </div>\r\n        <div class=\"content\">\r\n            <p>Xin chào {email},</p>\r\n            <p>Bạn đã được cấp mật khẩu mới cho tài khoản thí sinh của bạn.</p>\r\n            <p>Ở dưới là mật khẩu mới của bạn:</p>\r\n            <div class=\"password-block\">\r\n              <p class=\"password\">{newPass}</p>\r\n            </div>\r\n            <p>Hãy sử dụng mật khẩu trên cho lần thi tiếp theo của mình.</p>\r\n            <p>Trân trọng,<br>PolyTest</p>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p>&copy; 2025 Nhóm 2. Bảo lưu mọi quyền. Trộm thì ra đường gặp nhiều xui xẻo</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>";
                EmailHelper.SendMail(email, $"Bạn đã được đổi mật khẩu", emailBody);
            }
        }
        #endregion
    }
}
