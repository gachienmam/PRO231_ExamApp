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
    public partial class Formnguoidung : Form
    {
        public Formnguoidung()
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
            textBoxMaND.Text = null;
            textBoxMaND.Enabled = true;
            textBoxMKND.Text = null;
            textBoxMKND.Enabled = true;
            textBoxEmailND.Text = null;
            textBoxHoTenND.Text = null;
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
            textBoxTimKiem.Text = "Nhập tên email người dùng";
            textBoxEmailND.Text = null;
            textBoxHoTenND.Text = null;
            textBoxMaND.Text = null;
            textBoxMaND.Enabled = false;
            textBoxEmailND.Enabled = false;
            textBoxHoTenND.Enabled = false;
            textBoxMKND.Text = null;
            textBoxMKND.Enabled = false;
            radioButtonAdmin.Enabled = false;
            radioButtonGV.Enabled = false;
            buttonThemND.Enabled = true;
            buttonLuuND.Enabled = false;
            buttonThoat.Enabled = true;
            buttonSuaND.Enabled = false;
            buttonXoaND.Enabled = false;
            adioButtonGridviewND.Enabled = true;
        }

        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            textBoxTimKiem.Text = null;
            textBoxTimKiem.BackColor = Color.White;
        }
    }
}
