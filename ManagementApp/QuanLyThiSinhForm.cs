using ExamLibrary.Enum;
using ManagementApp.AdminProto;
using Newtonsoft.Json;
using ReaLTaiizor.Controls;
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

namespace ManagementApp
{
    public partial class QuanLyThiSinhForm : Form
    {
        private readonly AdminServiceClient _client;
        private readonly string _accessToken;
        private readonly Grpc.Core.Metadata _headers;
        public QuanLyThiSinhForm(AdminServiceClient client, string accessToken)
        {
            InitializeComponent();
            _client = client;
            _accessToken = accessToken;
            _headers = new Grpc.Core.Metadata
                {
                    { "Authorization", $"Bearer {_accessToken}" }
                };
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonThemTS_Click(object sender, EventArgs e)
        {
            textBoxMaTS.Text = null;
            textBoxHoTenTS.Text = null;
            textBoxSDTTS.Text = null;
            textBoxEmailTS.Text = null;
            textBoxMKTS.Text = null;
            radioButtonHDTS.Checked = true;
            radioButtonKhoaTS.Checked = false;

            textBoxMaTS.Enabled = true;
            textBoxHoTenTS.Enabled = true;
            textBoxSDTTS.Enabled = true;
            textBoxEmailTS.Enabled = true;
            textBoxMKTS.Enabled = true;
            radioButtonHDTS.Enabled = true;
            radioButtonKhoaTS.Enabled = false;

            buttonThemTS.Enabled = true;
            buttonLuuTS.Enabled = true;
            buttonThoat.Enabled = true;
            buttonSuaTS.Enabled = false;
            buttonXoaTS.Enabled = false;
        }
        private void LoadGridview_ThiSinh()
        {
            try
            {
                var request = new CommandRequest()
                {
                    RequestCode = (int)RemoteCommandType.SQL,
                    Command = "SELECT * FROM ThiSinh"
                };

                var response = _client.ExecuteRemoteCommand(request, _headers);

                if (response.ResponseCode == (int)HttpStatusCode.OK)
                {
                    DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(response.ResponseMessage);

                    if (dataTable == null || dataTable.Rows.Count == 0)
                    {
                        CrownMessageBox.ShowError("Không có dữ liệu hiển thị.", "Thông báo", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                        return;
                    }

                    dataGridViewTS.DataSource = dataTable;

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
                else
                {
                    CrownMessageBox.ShowError($"Lỗi: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
            }
            catch (Exception ex)
            {
                CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
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
            buttonThoat.Enabled = true;
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

        private void buttonLuuTS_Click(object sender, EventArgs e)
        {
            string email;

            int trangThai = 0; // Mặc định là khóa
            if (radioButtonHDTS.Checked)
            {
                trangThai = 1; // Nếu radioButtonHDTS được chọn, trạng thái là hoạt động
            }

            float intDienThoai;
            bool isInt = float.TryParse(textBoxSDTTS.Text.Trim().ToString(), out intDienThoai);
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
                    var request = new CommandRequest()
                    {
                        RequestCode = (int)RemoteCommandType.SQL,
                        Command = string.Format("EXEC sp_InsertThiSinh N'{0}', N'{1}', N'{2}', N'{3}', '{4}', '{5}', {6}",
                            textBoxMaTS.Text.Trim(),
                            textBoxHoTenTS.Text.Trim(),
                            textBoxEmailTS.Text.Trim(),
                            textBoxMKTS.Text.Trim(),
                            dateTimePickerNgaySinhTS.Value.ToString("yyyy-MM-dd"),
                            textBoxSDTTS.Text.Trim(),
                            trangThai)
                    };

                    var response = _client.ExecuteRemoteCommand(request, _headers);

                    if (response.ResponseCode == (int)HttpStatusCode.OK)
                    {
                        DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(response.ResponseMessage);
                        //DataTable dataTable = ConvertToDataTable(response.ResponseMessage);
                        if (dataTable == null)
                        {
                            CrownMessageBox.ShowError($"Lỗi khi hiển thị bảng: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                        }
                        dataGridViewTS.DataSource = dataTable;
                    }
                    else
                    {
                        CrownMessageBox.ShowError($"Lỗi: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    }
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
                    var request = new CommandRequest()
                    {
                        RequestCode = (int)RemoteCommandType.SQL,
                        Command = string.Format("EXEC sp_DeleteThiSinh @MaThiSinh")
                    };

                    var response = _client.ExecuteRemoteCommand(request, _headers);

                    if (response.ResponseCode == (int)HttpStatusCode.OK)
                    {
                        DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(response.ResponseMessage);
                        //DataTable dataTable = ConvertToDataTable(response.ResponseMessage);
                        if (dataTable == null)
                        {
                            CrownMessageBox.ShowError($"Lỗi khi hiển thị bảng: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                        }
                        dataGridViewTS.DataSource = dataTable;
                    }
                    else
                    {
                        CrownMessageBox.ShowError($"Lỗi: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    }
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
            float intDienThoai;
            bool isInt = float.TryParse(textBoxSDTTS.Text.Trim().ToString(), out intDienThoai);
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
            if (radioButtonKhoaTS.Checked == false && radioButtonKhoaTS.Checked == false)// kiem tra phai check tình trạng
            {
                MessageBox.Show("Bạn phải chon vai trò thí sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHoTenTS.Focus();
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
                    var request = new CommandRequest()
                    {
                        RequestCode = (int)RemoteCommandType.SQL,
                        Command = string.Format("EXEC sp_UpdateThiSinh @MaThiSinh, @HoTen, @Email, @MatKhau, @NgaySinh, @SoDienThoai, @TrangThai")

                    };

                    var response = _client.ExecuteRemoteCommand(request, _headers);

                    if (response.ResponseCode == (int)HttpStatusCode.OK)
                    {
                        DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(response.ResponseMessage);
                        //DataTable dataTable = ConvertToDataTable(response.ResponseMessage);
                        if (dataTable == null)
                        {
                            CrownMessageBox.ShowError($"Lỗi khi hiển thị bảng: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                        }
                        dataGridViewTS.DataSource = dataTable;
                    }
                    else
                    {
                        CrownMessageBox.ShowError($"Lỗi: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    }
                }
                catch (Exception ex)
                {
                    CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
            }
        }

        private void buttonDanhSachTS_Click(object sender, EventArgs e)
        {
            LoadGridview_ThiSinh();
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
                    dv.RowFilter = $"MaSV = '{maSV}'";
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

        private void buttonDanhSachTS_Click_1(object sender, EventArgs e)
        {
            try
            {
                var request = new CommandRequest()
                {
                    RequestCode = (int)RemoteCommandType.SQL,
                    Command = "SELECT * FROM ThiSinh"
                };

                var response = _client.ExecuteRemoteCommand(request, _headers);

                if (response.ResponseCode == (int)HttpStatusCode.OK)
                {
                    DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(response.ResponseMessage);
                    //DataTable dataTable = ConvertToDataTable(response.ResponseMessage);
                    if (dataTable == null)
                    {
                        CrownMessageBox.ShowError($"Lỗi khi hiển thị bảng: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    }
                    dataGridViewTS.DataSource = dataTable;
                }
                else
                {
                    CrownMessageBox.ShowError($"Lỗi: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
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
                textBoxSDTTS.Text = dataGridViewTS.CurrentRow.Cells[2].Value.ToString();
                textBoxEmailTS.Text = dataGridViewTS.CurrentRow.Cells[3].Value.ToString();
                textBoxMKTS.Text = dataGridViewTS.CurrentRow.Cells[4].Value.ToString();
                dateTimePickerNgaySinhTS.Text = dataGridViewTS.CurrentRow.Cells[5].Value.ToString();
                string TrangThai = dataGridViewTS.CurrentRow.Cells[6].Value.ToString();
                if (TrangThai == "Khóa")
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
    }
}
