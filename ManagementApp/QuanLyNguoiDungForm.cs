using ReaLTaiizor.Enum.Material;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ManagementApp
{
    public partial class QuanLyNguoiDungForm : Form
    {
        public QuanLyNguoiDungForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvThiSinh_Click(object sender, EventArgs e)
        {
            if (dataGridViewND.Rows.Count > 1)
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
                textBoxMaND.Text = dataGridViewND.CurrentRow.Cells[0].Value.ToString();
                textBoxHoTenND.Text = dataGridViewND.CurrentRow.Cells[1].Value.ToString();
                textBoxEmailND.Text = dataGridViewND.CurrentRow.Cells[3].Value.ToString();
                textBoxMKND.Text = dataGridViewND.CurrentRow.Cells[4].Value.ToString();
                string VaiTro = dataGridViewND.CurrentRow.Cells[5].Value.ToString();
                if (VaiTro == "Admin")
                    radioButtonAdmin.Checked = true;
                else
                    radioButtonGV.Checked = true;
                string TrangThai = dataGridViewND.CurrentRow.Cells[6].Value.ToString();
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
            dataGridViewND.Columns[0].HeaderText = "Mã";
            dataGridViewND.Columns[1].HeaderText = "Họ và tên";
            dataGridViewND.Columns[2].HeaderText = "Email";
            dataGridViewND.Columns[3].HeaderText = "Mật khẩu";
            dataGridViewND.Columns[4].HeaderText = "Trạng thái";
            dataGridViewND.Columns[5].HeaderText = "Vai trò";
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

        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            textBoxTimKiem.Text = null;
            textBoxTimKiem.BackColor = Color.White;
        }

        private void crownSectionPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void crownTitle1_Click(object sender, EventArgs e)
        {

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

        private void buttonSuaND_Click_1(object sender, EventArgs e)
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
            string Email = textBoxTimKiem.Text;
            DataTable ds = busND.SearchKhach(Email);
            if (ds.Rows.Count > 0)
            {
                dataGridViewND.DataSource = ds;
                dataGridViewND.Columns[0].HeaderText = "Mã người dùng";
                dataGridViewND.Columns[1].HeaderText = "Họ và tên";
                dataGridViewND.Columns[2].HeaderText = "Email";
                dataGridViewND.Columns[3].HeaderText = "Mật khẩu";
                dataGridViewND.Columns[4].HeaderText = "Số điện Thoại";
                dataGridViewND.Columns[5].HeaderText = "Trạng thái";
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng nào phù hợp tiêu chí tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxTimKiem.Focus();
            }
            textBoxTimKiem.Text = "Nhập Email người dùng";
            textBoxTimKiem.BackColor = Color.LightGray;
            ResetValues();
        }
    }
}
