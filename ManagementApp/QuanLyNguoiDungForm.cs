using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void buttonSuaND_Click(object sender, EventArgs e)
        {

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
    }
}
