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
            BUTTON_THOAT = new ReaLTaiizor.Controls.CrownButton();
            BUTTON_XUATDS = new ReaLTaiizor.Controls.CrownButton();
            BUTTON_XEMDS = new ReaLTaiizor.Controls.CrownButton();
            textBoxTimKiem = new ReaLTaiizor.Controls.CrownTextBox();
            buttonTimKiem = new ReaLTaiizor.Controls.CrownButton();
            dataGridViewTKD = new DataGridView();
            crownGroupBox1 = new ReaLTaiizor.Controls.CrownGroupBox();
            crownCheckBox1 = new ReaLTaiizor.Controls.CrownCheckBox();
            crownCheckBox2 = new ReaLTaiizor.Controls.CrownCheckBox();
            crownCheckBox3 = new ReaLTaiizor.Controls.CrownCheckBox();
            crownTextBox1 = new ReaLTaiizor.Controls.CrownTextBox();
            crownSectionPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTKD).BeginInit();
            crownGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // crownSectionPanel1
            // 
            crownSectionPanel1.Controls.Add(crownGroupBox1);
            crownSectionPanel1.Controls.Add(BUTTON_THOAT);
            crownSectionPanel1.Controls.Add(BUTTON_XUATDS);
            crownSectionPanel1.Controls.Add(BUTTON_XEMDS);
            crownSectionPanel1.Controls.Add(textBoxTimKiem);
            crownSectionPanel1.Controls.Add(buttonTimKiem);
            crownSectionPanel1.Controls.Add(dataGridViewTKD);
            crownSectionPanel1.Dock = DockStyle.Fill;
            crownSectionPanel1.Location = new Point(0, 0);
            crownSectionPanel1.Name = "crownSectionPanel1";
            crownSectionPanel1.SectionHeader = null;
            crownSectionPanel1.Size = new Size(800, 450);
            crownSectionPanel1.TabIndex = 0;
            // 
            // BUTTON_THOAT
            // 
            BUTTON_THOAT.Location = new Point(192, 375);
            BUTTON_THOAT.Name = "BUTTON_THOAT";
            BUTTON_THOAT.Padding = new Padding(5);
            BUTTON_THOAT.Size = new Size(91, 27);
            BUTTON_THOAT.TabIndex = 18;
            BUTTON_THOAT.Text = "Thoát";
            BUTTON_THOAT.Click += BUTTON_THOAT_Click;
            // 
            // BUTTON_XUATDS
            // 
            BUTTON_XUATDS.Location = new Point(133, 314);
            BUTTON_XUATDS.Name = "BUTTON_XUATDS";
            BUTTON_XUATDS.Padding = new Padding(5);
            BUTTON_XUATDS.Size = new Size(215, 32);
            BUTTON_XUATDS.TabIndex = 17;
            BUTTON_XUATDS.Text = "Xuất danh sách điểm";
            // 
            // BUTTON_XEMDS
            // 
            BUTTON_XEMDS.Location = new Point(133, 254);
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
            textBoxTimKiem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTimKiem.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxTimKiem.Location = new Point(117, 197);
            textBoxTimKiem.Multiline = true;
            textBoxTimKiem.Name = "textBoxTimKiem";
            textBoxTimKiem.PlaceholderText = "Tìm kiếm theo mã thí sinh";
            textBoxTimKiem.Size = new Size(240, 29);
            textBoxTimKiem.TabIndex = 15;
            // 
            // buttonTimKiem
            // 
            buttonTimKiem.Location = new Point(446, 197);
            buttonTimKiem.Name = "buttonTimKiem";
            buttonTimKiem.Padding = new Padding(5);
            buttonTimKiem.Size = new Size(132, 29);
            buttonTimKiem.TabIndex = 14;
            buttonTimKiem.Text = "Tìm kiếm";
            // 
            // dataGridViewTKD
            // 
            dataGridViewTKD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTKD.Location = new Point(0, 0);
            dataGridViewTKD.Name = "dataGridViewTKD";
            dataGridViewTKD.Size = new Size(802, 182);
            dataGridViewTKD.TabIndex = 8;
            // 
            // crownGroupBox1
            // 
            crownGroupBox1.BorderColor = Color.FromArgb(51, 51, 51);
            crownGroupBox1.Controls.Add(crownTextBox1);
            crownGroupBox1.Controls.Add(crownCheckBox3);
            crownGroupBox1.Controls.Add(crownCheckBox2);
            crownGroupBox1.Controls.Add(crownCheckBox1);
            crownGroupBox1.Location = new Point(446, 265);
            crownGroupBox1.Name = "crownGroupBox1";
            crownGroupBox1.Size = new Size(342, 173);
            crownGroupBox1.TabIndex = 19;
            crownGroupBox1.TabStop = false;
            crownGroupBox1.Enter += crownGroupBox1_Enter;
            // 
            // crownCheckBox1
            // 
            crownCheckBox1.AutoSize = true;
            crownCheckBox1.Location = new Point(33, 34);
            crownCheckBox1.Name = "crownCheckBox1";
            crownCheckBox1.Size = new Size(47, 19);
            crownCheckBox1.TabIndex = 0;
            crownCheckBox1.Text = "Giỏi";
            // 
            // crownCheckBox2
            // 
            crownCheckBox2.AutoSize = true;
            crownCheckBox2.Location = new Point(33, 77);
            crownCheckBox2.Name = "crownCheckBox2";
            crownCheckBox2.Size = new Size(84, 19);
            crownCheckBox2.TabIndex = 1;
            crownCheckBox2.Text = "Hạnh kiểm";
            // 
            // crownCheckBox3
            // 
            crownCheckBox3.AutoSize = true;
            crownCheckBox3.Location = new Point(33, 118);
            crownCheckBox3.Name = "crownCheckBox3";
            crownCheckBox3.Size = new Size(70, 19);
            crownCheckBox3.TabIndex = 2;
            crownCheckBox3.Text = "Đậu/Rớt";
            // 
            // crownTextBox1
            // 
            crownTextBox1.BackColor = Color.FromArgb(69, 73, 74);
            crownTextBox1.BorderStyle = BorderStyle.FixedSingle;
            crownTextBox1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            crownTextBox1.ForeColor = Color.FromArgb(220, 220, 220);
            crownTextBox1.Location = new Point(202, 58);
            crownTextBox1.Name = "crownTextBox1";
            crownTextBox1.Size = new Size(103, 43);
            crownTextBox1.TabIndex = 3;
            crownTextBox1.Text = "LỌC";
            crownTextBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // ThongKeDiemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(crownSectionPanel1);
            Name = "ThongKeDiemForm";
            Text = "Thống kê báo cáo điểm";
            crownSectionPanel1.ResumeLayout(false);
            crownSectionPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTKD).EndInit();
            crownGroupBox1.ResumeLayout(false);
            crownGroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.CrownSectionPanel crownSectionPanel1;
        private ReaLTaiizor.Controls.CrownTextBox textBoxTimKiem;
        private ReaLTaiizor.Controls.CrownButton buttonTimKiem;
        private DataGridView dataGridViewTKD;
       
        private ReaLTaiizor.Controls.CrownButton BUTTON_XUATDS;
        private ReaLTaiizor.Controls.CrownButton BUTTON_XEMDS;
        private ReaLTaiizor.Controls.CrownButton BUTTON_THOAT;
        private ReaLTaiizor.Controls.CrownGroupBox crownGroupBox1;
        private ReaLTaiizor.Controls.CrownCheckBox crownCheckBox3;
        private ReaLTaiizor.Controls.CrownCheckBox crownCheckBox2;
        private ReaLTaiizor.Controls.CrownCheckBox crownCheckBox1;
        private ReaLTaiizor.Controls.CrownTextBox crownTextBox1;
    }
}