
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
            btnLocDuLieu = new ReaLTaiizor.Controls.CrownButton();
            CheckBoxRot = new ReaLTaiizor.Controls.CrownCheckBox();
            CheckBoxDau = new ReaLTaiizor.Controls.CrownCheckBox();
            BUTTON_XUATDS = new ReaLTaiizor.Controls.CrownButton();
            BUTTON_XEMDS = new ReaLTaiizor.Controls.CrownButton();
            textBoxTimKiem = new ReaLTaiizor.Controls.CrownTextBox();
            buttonTimKiem = new ReaLTaiizor.Controls.CrownButton();
            dataGridView1 = new DataGridView();
            TextBoxTimKimTheoDe = new ReaLTaiizor.Controls.CrownTextBox();
            ButtonTimKiemTheoDe = new ReaLTaiizor.Controls.CrownButton();
            crownSectionPanel1.SuspendLayout();
            crownGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // crownSectionPanel1
            // 
            crownSectionPanel1.Controls.Add(ButtonTimKiemTheoDe);
            crownSectionPanel1.Controls.Add(TextBoxTimKimTheoDe);
            crownSectionPanel1.Controls.Add(crownGroupBox1);
            crownSectionPanel1.Controls.Add(BUTTON_XUATDS);
            crownSectionPanel1.Controls.Add(BUTTON_XEMDS);
            crownSectionPanel1.Controls.Add(textBoxTimKiem);
            crownSectionPanel1.Controls.Add(buttonTimKiem);
            crownSectionPanel1.Dock = DockStyle.Top;
            crownSectionPanel1.Location = new Point(0, 0);
            crownSectionPanel1.Name = "crownSectionPanel1";
            crownSectionPanel1.SectionHeader = "Thống kê";
            crownSectionPanel1.Size = new Size(800, 135);
            crownSectionPanel1.TabIndex = 0;
            crownSectionPanel1.Paint += crownSectionPanel1_Paint;
            // 
            // crownGroupBox1
            // 
            crownGroupBox1.BorderColor = Color.FromArgb(51, 51, 51);
            crownGroupBox1.Controls.Add(btnLocDuLieu);
            crownGroupBox1.Controls.Add(CheckBoxRot);
            crownGroupBox1.Controls.Add(CheckBoxDau);
            crownGroupBox1.Location = new Point(679, 28);
            crownGroupBox1.Name = "crownGroupBox1";
            crownGroupBox1.Size = new Size(121, 81);
            crownGroupBox1.TabIndex = 19;
            crownGroupBox1.TabStop = false;
            crownGroupBox1.Text = "Lọc dữ liệu";
            // 
            // btnLocDuLieu
            // 
            btnLocDuLieu.Location = new Point(9, 46);
            btnLocDuLieu.Name = "btnLocDuLieu";
            btnLocDuLieu.Padding = new Padding(5);
            btnLocDuLieu.Size = new Size(106, 29);
            btnLocDuLieu.TabIndex = 20;
            btnLocDuLieu.Text = "Lọc";
            btnLocDuLieu.Click += btnLocDuLieu_Click;
            // 
            // CheckBoxRot
            // 
            CheckBoxRot.AutoSize = true;
            CheckBoxRot.Location = new Point(69, 22);
            CheckBoxRot.Name = "CheckBoxRot";
            CheckBoxRot.Size = new Size(44, 19);
            CheckBoxRot.TabIndex = 6;
            CheckBoxRot.Text = "Rớt";
            // 
            // CheckBoxDau
            // 
            CheckBoxDau.AutoSize = true;
            CheckBoxDau.Location = new Point(16, 22);
            CheckBoxDau.Name = "CheckBoxDau";
            CheckBoxDau.Size = new Size(47, 19);
            CheckBoxDau.TabIndex = 5;
            CheckBoxDau.Text = "Đậu";
            // 
            // BUTTON_XUATDS
            // 
            BUTTON_XUATDS.Location = new Point(454, 26);
            BUTTON_XUATDS.Name = "BUTTON_XUATDS";
            BUTTON_XUATDS.Padding = new Padding(5);
            BUTTON_XUATDS.Size = new Size(215, 32);
            BUTTON_XUATDS.TabIndex = 17;
            BUTTON_XUATDS.Text = "Xuất danh sách điểm";
            BUTTON_XUATDS.Click += BUTTON_XUATDS_Click;
            // 
            // BUTTON_XEMDS
            // 
            BUTTON_XEMDS.Location = new Point(12, 25);
            BUTTON_XEMDS.Name = "BUTTON_XEMDS";
            BUTTON_XEMDS.Padding = new Padding(5);
            BUTTON_XEMDS.Size = new Size(215, 33);
            BUTTON_XEMDS.TabIndex = 16;
            BUTTON_XEMDS.Text = "Xem danh sách điểm";
            BUTTON_XEMDS.Click += BUTTON_XEMDS_Click;
            // 
            // textBoxTimKiem
            // 
            textBoxTimKiem.BackColor = Color.FromArgb(69, 73, 74);
            textBoxTimKiem.BorderStyle = BorderStyle.FixedSingle;
            textBoxTimKiem.Font = new Font("Segoe UI", 9F);
            textBoxTimKiem.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxTimKiem.Location = new Point(12, 63);
            textBoxTimKiem.Multiline = true;
            textBoxTimKiem.Name = "textBoxTimKiem";
            textBoxTimKiem.PlaceholderText = "Tìm kiếm theo mã thí sinh";
            textBoxTimKiem.Size = new Size(519, 29);
            textBoxTimKiem.TabIndex = 15;
            textBoxTimKiem.TextChanged += textBoxTimKiem_TextChanged;
            // 
            // buttonTimKiem
            // 
            buttonTimKiem.Location = new Point(537, 62);
            buttonTimKiem.Name = "buttonTimKiem";
            buttonTimKiem.Padding = new Padding(5);
            buttonTimKiem.Size = new Size(132, 29);
            buttonTimKiem.TabIndex = 14;
            buttonTimKiem.Text = "Tìm kiếm";
            buttonTimKiem.Click += buttonTimKiem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 135);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.Size = new Size(800, 315);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // TextBoxTimKimTheoDe
            // 
            TextBoxTimKimTheoDe.BackColor = Color.FromArgb(69, 73, 74);
            TextBoxTimKimTheoDe.BorderStyle = BorderStyle.FixedSingle;
            TextBoxTimKimTheoDe.Font = new Font("Segoe UI", 9F);
            TextBoxTimKimTheoDe.ForeColor = Color.FromArgb(220, 220, 220);
            TextBoxTimKimTheoDe.Location = new Point(12, 98);
            TextBoxTimKimTheoDe.Multiline = true;
            TextBoxTimKimTheoDe.Name = "TextBoxTimKimTheoDe";
            TextBoxTimKimTheoDe.PlaceholderText = "Tìm kiếm theo mã thí sinh";
            TextBoxTimKimTheoDe.Size = new Size(519, 29);
            TextBoxTimKimTheoDe.TabIndex = 20;
            // 
            // ButtonTimKiemTheoDe
            // 
            ButtonTimKiemTheoDe.Location = new Point(537, 100);
            ButtonTimKiemTheoDe.Name = "ButtonTimKiemTheoDe";
            ButtonTimKiemTheoDe.Padding = new Padding(5);
            ButtonTimKiemTheoDe.Size = new Size(132, 29);
            ButtonTimKiemTheoDe.TabIndex = 21;
            ButtonTimKiemTheoDe.Text = "Tìm kiếm";
            ButtonTimKiemTheoDe.Click += ButtonTimKiemTheoDe_Click;
            // 
            // ThongKeDiemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(crownSectionPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ThongKeDiemForm";
            Text = "Thống kê báo cáo điểm";
            Load += ThongKeDiemForm_Load;
            crownSectionPanel1.ResumeLayout(false);
            crownSectionPanel1.PerformLayout();
            crownGroupBox1.ResumeLayout(false);
            crownGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.CrownSectionPanel crownSectionPanel1;
        private ReaLTaiizor.Controls.CrownTextBox textBoxTimKiem;
        private ReaLTaiizor.Controls.CrownButton buttonTimKiem;
        private ReaLTaiizor.Controls.CrownButton BUTTON_XUATDS;
        private ReaLTaiizor.Controls.CrownButton BUTTON_XEMDS;
        private ReaLTaiizor.Controls.CrownGroupBox crownGroupBox1;
        private ReaLTaiizor.Controls.CrownButton btnLocDuLieu;
        private ReaLTaiizor.Controls.CrownCheckBox CheckBoxRot;
        private ReaLTaiizor.Controls.CrownCheckBox CheckBoxDau;
        private DataGridView dataGridView1;
        private ReaLTaiizor.Controls.CrownTextBox TextBoxTimKimTheoDe;
        private ReaLTaiizor.Controls.CrownButton ButtonTimKiemTheoDe;
    }
}