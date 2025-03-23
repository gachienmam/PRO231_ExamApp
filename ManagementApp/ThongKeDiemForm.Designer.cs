namespace ManagementApp
{
    partial class ThongKeDiemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            crownSectionPanel1 = new ReaLTaiizor.Controls.CrownSectionPanel();
            crownGroupBox1 = new ReaLTaiizor.Controls.CrownGroupBox();
            BUTTON_XUATDS = new ReaLTaiizor.Controls.CrownButton();
            BUTTON_XEMDS = new ReaLTaiizor.Controls.CrownButton();
            textBoxTimKiem = new ReaLTaiizor.Controls.CrownTextBox();
            buttonTimKiem = new ReaLTaiizor.Controls.CrownButton();
            dataGridViewTKD = new DataGridView();
            crownCheckBox3 = new ReaLTaiizor.Controls.CrownCheckBox();
            crownCheckBox2 = new ReaLTaiizor.Controls.CrownCheckBox();
            btnLocDuLieu = new ReaLTaiizor.Controls.CrownButton();
            crownSectionPanel1.SuspendLayout();
            crownGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTKD).BeginInit();
            SuspendLayout();
            // 
            // crownSectionPanel1
            // 
            crownSectionPanel1.Controls.Add(crownGroupBox1);
            crownSectionPanel1.Controls.Add(BUTTON_XUATDS);
            crownSectionPanel1.Controls.Add(BUTTON_XEMDS);
            crownSectionPanel1.Controls.Add(textBoxTimKiem);
            crownSectionPanel1.Controls.Add(buttonTimKiem);
            crownSectionPanel1.Controls.Add(dataGridViewTKD);
            crownSectionPanel1.Dock = DockStyle.Fill;
            crownSectionPanel1.Location = new Point(0, 0);
            crownSectionPanel1.Name = "crownSectionPanel1";
            crownSectionPanel1.SectionHeader = "Thống kê";
            crownSectionPanel1.Size = new Size(800, 450);
            crownSectionPanel1.TabIndex = 0;
            // 
            // crownGroupBox1
            // 
            crownGroupBox1.BorderColor = Color.FromArgb(51, 51, 51);
            crownGroupBox1.Controls.Add(btnLocDuLieu);
            crownGroupBox1.Controls.Add(crownCheckBox3);
            crownGroupBox1.Controls.Add(crownCheckBox2);
            crownGroupBox1.Location = new Point(675, 28);
            crownGroupBox1.Name = "crownGroupBox1";
            crownGroupBox1.Size = new Size(121, 81);
            crownGroupBox1.TabIndex = 19;
            crownGroupBox1.TabStop = false;
            crownGroupBox1.Text = "Lọc dữ liệu";
            crownGroupBox1.Enter += crownGroupBox1_Enter;
            // 
            // BUTTON_XUATDS
            // 
            BUTTON_XUATDS.Location = new Point(454, 28);
            BUTTON_XUATDS.Name = "BUTTON_XUATDS";
            BUTTON_XUATDS.Padding = new Padding(5);
            BUTTON_XUATDS.Size = new Size(215, 32);
            BUTTON_XUATDS.TabIndex = 17;
            BUTTON_XUATDS.Text = "Xuất danh sách điểm";
            // 
            // BUTTON_XEMDS
            // 
            BUTTON_XEMDS.Location = new Point(12, 28);
            BUTTON_XEMDS.Name = "BUTTON_XEMDS";
            BUTTON_XEMDS.Padding = new Padding(5);
            BUTTON_XEMDS.Size = new Size(215, 33);
            BUTTON_XEMDS.TabIndex = 16;
            BUTTON_XEMDS.Text = "Xem danh sách điểm";
            // 
            // textBoxTimKiem
            // 
            textBoxTimKiem.BackColor = Color.FromArgb(69, 73, 74);
            textBoxTimKiem.BorderStyle = BorderStyle.FixedSingle;
            textBoxTimKiem.Font = new Font("Segoe UI", 9F);
            textBoxTimKiem.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxTimKiem.Location = new Point(12, 79);
            textBoxTimKiem.Multiline = true;
            textBoxTimKiem.Name = "textBoxTimKiem";
            textBoxTimKiem.PlaceholderText = "Tìm kiếm theo mã thí sinh";
            textBoxTimKiem.Size = new Size(519, 29);
            textBoxTimKiem.TabIndex = 15;
            // 
            // buttonTimKiem
            // 
            buttonTimKiem.Location = new Point(537, 79);
            buttonTimKiem.Name = "buttonTimKiem";
            buttonTimKiem.Padding = new Padding(5);
            buttonTimKiem.Size = new Size(132, 29);
            buttonTimKiem.TabIndex = 14;
            buttonTimKiem.Text = "Tìm kiếm";
            // 
            // dataGridViewTKD
            // 
            dataGridViewTKD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTKD.Location = new Point(-1, 115);
            dataGridViewTKD.Name = "dataGridViewTKD";
            dataGridViewTKD.Size = new Size(802, 336);
            dataGridViewTKD.TabIndex = 8;
            // 
            // crownCheckBox3
            // 
            crownCheckBox3.AutoSize = true;
            crownCheckBox3.Location = new Point(69, 22);
            crownCheckBox3.Name = "crownCheckBox3";
            crownCheckBox3.Size = new Size(44, 19);
            crownCheckBox3.TabIndex = 6;
            crownCheckBox3.Text = "Rớt";
            // 
            // crownCheckBox2
            // 
            crownCheckBox2.AutoSize = true;
            crownCheckBox2.Location = new Point(16, 22);
            crownCheckBox2.Name = "crownCheckBox2";
            crownCheckBox2.Size = new Size(47, 19);
            crownCheckBox2.TabIndex = 5;
            crownCheckBox2.Text = "Đậu";
            // 
            // btnLocDuLieu
            // 
            btnLocDuLieu.Location = new Point(9, 46);
            btnLocDuLieu.Name = "btnLocDuLieu";
            btnLocDuLieu.Padding = new Padding(5);
            btnLocDuLieu.Size = new Size(106, 29);
            btnLocDuLieu.TabIndex = 20;
            btnLocDuLieu.Text = "Lọc";
            // 
            // ThongKeDiemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(crownSectionPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ThongKeDiemForm";
            Text = "Thống kê báo cáo điểm";
            crownSectionPanel1.ResumeLayout(false);
            crownSectionPanel1.PerformLayout();
            crownGroupBox1.ResumeLayout(false);
            crownGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTKD).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.CrownSectionPanel crownSectionPanel1;
        private ReaLTaiizor.Controls.CrownTextBox textBoxTimKiem;
        private ReaLTaiizor.Controls.CrownButton buttonTimKiem;
        private DataGridView dataGridViewTKD;
        private ReaLTaiizor.Controls.CrownButton BUTTON_XUATDS;
        private ReaLTaiizor.Controls.CrownButton BUTTON_XEMDS;
        private ReaLTaiizor.Controls.CrownGroupBox crownGroupBox1;
        private ReaLTaiizor.Controls.CrownButton btnLocDuLieu;
        private ReaLTaiizor.Controls.CrownCheckBox crownCheckBox3;
        private ReaLTaiizor.Controls.CrownCheckBox crownCheckBox2;
    }
}