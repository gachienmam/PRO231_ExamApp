using ExamLibrary.Enum;
using ManagementApp.AdminProto;
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
        private readonly string _accessToken;
        private readonly Grpc.Core.Metadata _headers;

        public QuanLyNguoiDungForm(AdminServiceClient client, string accessToken)
        {
            InitializeComponent();
            _client = client;
            _accessToken = accessToken;
            _headers = new Grpc.Core.Metadata
                {
                    { "Authorization", $"Bearer {_accessToken}" }
                };
        }

        private void dataGridViewNguoiDung_Click(object sender, EventArgs e)
        {
            if (dataGridViewNguoiDung.Rows.Count > 1)
            {
                buttonLuuND.Enabled = false;
                textBoxMaND.Focus();
                textBoxHoTenND.Enabled = true;
                textBoxEmailND.Enabled = true;
                textBoxMKND.Enabled = true;
                radioButtonAdmin.Enabled = true;
                radioButtonGV.Enabled = true;
                radioButtonHD.Enabled = true;
                radioButtonKHD.Enabled = true;
                buttonSuaND.Enabled = true;
                buttonXoaND.Enabled = true;
                textBoxMaND.Text = dataGridViewNguoiDung.CurrentRow.Cells[0].Value.ToString();
                textBoxHoTenND.Text = dataGridViewNguoiDung.CurrentRow.Cells[1].Value.ToString();
                textBoxEmailND.Text = dataGridViewNguoiDung.CurrentRow.Cells[3].Value.ToString();
                textBoxMKND.Text = dataGridViewNguoiDung.CurrentRow.Cells[4].Value.ToString();
                string VaiTro = dataGridViewNguoiDung.CurrentRow.Cells[5].Value.ToString();
                if (VaiTro == "Admin")
                    radioButtonAdmin.Checked = true;
                else
                    radioButtonGV.Checked = true;
                string TrangThai = dataGridViewNguoiDung.CurrentRow.Cells[6].Value.ToString();
                if (TrangThai == "Hoạt động")
                    radioButtonHD.Checked = true;
                else
                    radioButtonKHD.Checked = true;
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void buttonThemND_Click(object sender, EventArgs e)
        {
            textBoxHoTenND.Text = string.Empty;
            textBoxHoTenND.Enabled = true;
            textBoxMKND.Text = string.Empty;
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
        private void LoadGridview_NguoiDung()
        {
            //dgvThiSinh.DataSource = busThisinh.getKhach();
            dataGridViewNguoiDung.Columns[0].HeaderText = "Mã";
            dataGridViewNguoiDung.Columns[1].HeaderText = "Họ và tên";
            dataGridViewNguoiDung.Columns[2].HeaderText = "Email";
            dataGridViewNguoiDung.Columns[3].HeaderText = "Mật khẩu";
            dataGridViewNguoiDung.Columns[4].HeaderText = "Trạng thái";
            dataGridViewNguoiDung.Columns[5].HeaderText = "Vai trò";
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
            radioButtonHD.Enabled = true;
            radioButtonKHD.Enabled = true;
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

        private void buttonLuuND_Click(object sender, EventArgs e)
        {
            string email;

            int TrangThai = 0;//Không hoạt đọng
            if (radioButtonHD.Checked)
                TrangThai = 1;// hoạt đọng
            int VaiTro = 0;//GV
            if (radioButtonAdmin.Checked)
                VaiTro = 1;// Admin

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

            if (radioButtonKHD.Checked == false && radioButtonHD.Checked == false)// kiem tra phai check tình trạng
            {
                MessageBox.Show("Bạn phải chon vai trò người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHoTenND.Focus();
                return;
            }

            if (radioButtonAdmin.Checked == false && radioButtonGV.Checked == false)// kiem tra phai check tình trạng
            {
                MessageBox.Show("Bạn phải chon tình trạng người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHoTenND.Focus();
                return;
            }
            else
            {
				try
				{
					var request = new CommandRequest()
					{
						RequestCode = (int)RemoteCommandType.SQL,
						Command = ""
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
						dataGridViewNguoiDung.DataSource = dataTable;
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

        private void buttonSuaND_Click(object sender, EventArgs e)
        {
            string email;

            int TrangThai = 0;//Không hoạt đọng
            if (radioButtonHD.Checked)
                TrangThai = 1;// hoạt đọng
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
                MessageBox.Show("Bạn phải nhập Mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxMKND.Focus();
                return;
            }
            
            if (radioButtonKHD.Checked == false && radioButtonHD.Checked == false)// kiem tra phai check tình trạng
            {
                MessageBox.Show("Bạn phải chon vai trò người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHoTenND.Focus();
                return;
            }

            if (radioButtonAdmin.Checked == false && radioButtonGV.Checked == false)// kiem tra phai check tình trạng
            {
                MessageBox.Show("Bạn phải chon tình trạng người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxHoTenND.Focus();
                return;
            }
            else
            {
				try
				{
					var request = new CommandRequest()
					{
						RequestCode = (int)RemoteCommandType.SQL,
						Command = $"UPDATE NguoiDung SET HoTen = '{textBoxHoTenND.Text}', Email = '{textBoxEmailND.Text}', MatKhau = '{textBoxMKND.Text}', VaiTro = '{VaiTro}', WHERE MaNguoiDung = '{textBoxMaND.Text}';"
					};

					var response = _client.ExecuteRemoteCommand(request, _headers);

					if (response.ResponseCode == (int)HttpStatusCode.OK)
					{
						DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(response.ResponseMessage);
						//DataTable dataTable = ConvertToDataTable(response.ResponseMessage);
						if (dataTable == null)
						{
							CrownMessageBox.ShowError($"Lỗi khi chạy: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
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
        }

        private void buttonXoaND_Click(object sender, EventArgs e)
        {
            string soDT = textBoxMaND.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu người dùng", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //do something if YES
                //if (busKhach.DeleteKhach(soDT))
                //{
                //    MessageBox.Show("Xóa dữ liệu khách hàng thành công");
                //    ResetValues();
                //    LoadGridview_Khach(); // refresh datagridview
                //}
                //else
                //{
                //    MessageBox.Show("Xóa dữ liệu khách hàng không thành công");
                //}
            }
            else
            {
                //do something if NO
                ResetValues();
            }
        }

        private void buttonDanhSachND_Click(object sender, EventArgs e)
        {
            LoadGridview_NguoiDung();
        }

		private void crownButtonTimKiem_Click(object sender, EventArgs e)
		{
			string email = textBoxTimKiem.Text.Trim();

			// Kiểm tra tính hợp lệ của địa chỉ email
			if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
			{
				MessageBox.Show("Vui lòng nhập địa chỉ email hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBoxTimKiem.Focus();
				return;
			}

            DataTable dataTable = new DataTable();
			// Gọi phương thức tìm kiếm
			try
			{
				var request = new CommandRequest()
				{
					RequestCode = (int)RemoteCommandType.SQL,
					Command = $"SELECT * FROM NguoiDung WHERE MaNguoiDung = '{textBoxMaND.Text}';"
				};

				var response = _client.ExecuteRemoteCommand(request, _headers);

				if (response.ResponseCode == (int)HttpStatusCode.OK)
				{
					dataTable = JsonConvert.DeserializeObject<DataTable>(response.ResponseMessage);
					//DataTable dataTable = ConvertToDataTable(response.ResponseMessage);
					if (dataTable == null)
					{
						CrownMessageBox.ShowError($"Lỗi khi chạy: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
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

			if (dataTable.Rows.Count > 0)
			{
				dataGridViewNguoiDung.DataSource = dataTable;
				// Đặt tiêu đề cho các cột
				dataGridViewNguoiDung.Columns[0].HeaderText = "Mã người dùng";
				dataGridViewNguoiDung.Columns[1].HeaderText = "Họ và tên";
				dataGridViewNguoiDung.Columns[2].HeaderText = "Email";
				dataGridViewNguoiDung.Columns[3].HeaderText = "Mật khẩu";
				dataGridViewNguoiDung.Columns[4].HeaderText = "Số điện Thoại";
				dataGridViewNguoiDung.Columns[5].HeaderText = "Trạng thái";
			}
			else
			{
				MessageBox.Show("Không tìm thấy người dùng nào phù hợp tiêu chí tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				textBoxTimKiem.Focus();
			}

			// Đặt lại giá trị
			ResetValues();
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
	}
}
