using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementApp
{
    public partial class QuanLyThiSinhForm : Form
    {
        public QuanLyThiSinhForm()
        {
            InitializeComponent();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvThiSinh_Click(object sender, EventArgs e)
        {
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
                if (TrangThai == "Khoa")
                    radioButtonKhoaTS.Checked = true;
                else
                    radioButtonHDTS.Checked = true;
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            //dgvThiSinh.DataSource = busThisinh.getKhach();
            dataGridViewTS.Columns[0].HeaderText = "Mã thí sinh";
            dataGridViewTS.Columns[1].HeaderText = "Họ và tên";
            dataGridViewTS.Columns[2].HeaderText = "Email";
            dataGridViewTS.Columns[3].HeaderText = "Mật khẩu";
            dataGridViewTS.Columns[4].HeaderText = "Ngày sinh";
            dataGridViewTS.Columns[5].HeaderText = "Số điện Thoại";
            dataGridViewTS.Columns[6].HeaderText = "Trạng thái";
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

            int TrangThai = 0;//khoa
            if (radioButtonHDTS.Checked)
                TrangThai = 1;// hoạt đọng
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
                if ()
                { }
                // Tạo DTo
                //d nv = new DTO_NhanVien(txtEmail.Text, txtTennv.Text, txtDiachi.Text, role, tinhtrang); // Vì ID tự tăng nên để ID số gì cũng dc
                //if (busNhanVien.insertNhanVien(nv))
                //{
                //    MessageBox.Show("Thêm thành công");
                //    ResetValues();
                //    LoadGridview_NhanVien(); // refresh datagridview
                //    email = txtEmail.Text;
                //    SendMail(nv.EmailNV);
                //}
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
        }

        private void buttonXoaTS_Click(object sender, EventArgs e)
        {
            string soDT = textBoxMaTS.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu thí sinh", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void buttonSuaTS_Click(object sender, EventArgs e)
        {
            string email;

            int TrangThai = 0;//khoa
            if (radioButtonHDTS.Checked)
                TrangThai = 1;// hoạt đọng
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
                if ()
                { }
                // Tạo DTo
                //d nv = new DTO_NhanVien(txtEmail.Text, txtTennv.Text, txtDiachi.Text, role, tinhtrang); // Vì ID tự tăng nên để ID số gì cũng dc
                //if (busNhanVien.insertNhanVien(nv))
                //{
                //    MessageBox.Show("Thêm thành công");
                //    ResetValues();
                //    LoadGridview_NhanVien(); // refresh datagridview
                //    email = txtEmail.Text;
                //    SendMail(nv.EmailNV);
                //}
                else
                {
                    MessageBox.Show("Sửa không thành công");
                }
            }
        }

        private void buttonDanhSachTS_Click(object sender, EventArgs e)
        {
            LoadGridview_ThiSinh();
        }

        

        private void crownButtonTimKiem_Click(object sender, EventArgs e)
        {
            string Email = textBoxTimKiem.Text;
            DataTable ds = busKhach.SearchKhach(Email);
            if (ds.Rows.Count > 0)
            {
                dataGridViewTS.DataSource = ds;
                dataGridViewTS.Columns[0].HeaderText = "Mã thí sinh";
                dataGridViewTS.Columns[1].HeaderText = "Họ và tên";
                dataGridViewTS.Columns[2].HeaderText = "Email";
                dataGridViewTS.Columns[3].HeaderText = "Mật khẩu";
                dataGridViewTS.Columns[4].HeaderText = "Ngày sinh";
                dataGridViewTS.Columns[5].HeaderText = "Số điện Thoại";
                dataGridViewTS.Columns[6].HeaderText = "Trạng thái";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thí sinh nào phù hợp tiêu chí tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxTimKiem.Focus();
            }
            textBoxTimKiem.Text = "Nhập Email thí sinh";
            textBoxTimKiem.BackColor = Color.LightGray;
            ResetValues();
        }
    }
}
