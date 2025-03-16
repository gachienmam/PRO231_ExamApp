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
    }
}
