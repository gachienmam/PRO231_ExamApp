
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
            buttonGuiMail = new ReaLTaiizor.Controls.CrownButton();
            ButtonTimKiemTheoDe = new ReaLTaiizor.Controls.CrownButton();
            textBoxTimKiemTheoMaDe = new ReaLTaiizor.Controls.CrownTextBox();
            crownGroupBox1 = new ReaLTaiizor.Controls.CrownGroupBox();
            btnLocDuLieu = new ReaLTaiizor.Controls.CrownButton();
            CheckBoxRot = new ReaLTaiizor.Controls.CrownCheckBox();
            CheckBoxDau = new ReaLTaiizor.Controls.CrownCheckBox();
            BUTTON_XUATDS = new ReaLTaiizor.Controls.CrownButton();
            BUTTON_XEMDS = new ReaLTaiizor.Controls.CrownButton();
            textBoxTimKiemTheoMaThiSinh = new ReaLTaiizor.Controls.CrownTextBox();
            buttonTimKiem = new ReaLTaiizor.Controls.CrownButton();
            dataGridView1 = new DataGridView();
            crownSectionPanel1.SuspendLayout();
            crownGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // crownSectionPanel1
            // 
            crownSectionPanel1.Controls.Add(buttonGuiMail);
            crownSectionPanel1.Controls.Add(ButtonTimKiemTheoDe);
            crownSectionPanel1.Controls.Add(textBoxTimKiemTheoMaDe);
            crownSectionPanel1.Controls.Add(crownGroupBox1);
            crownSectionPanel1.Controls.Add(BUTTON_XUATDS);
            crownSectionPanel1.Controls.Add(BUTTON_XEMDS);
            crownSectionPanel1.Controls.Add(textBoxTimKiemTheoMaThiSinh);
            crownSectionPanel1.Controls.Add(buttonTimKiem);
            crownSectionPanel1.Dock = DockStyle.Top;
            crownSectionPanel1.Location = new Point(0, 0);
            crownSectionPanel1.Name = "crownSectionPanel1";
            crownSectionPanel1.SectionHeader = "Thống kê";
            crownSectionPanel1.Size = new Size(800, 135);
            crownSectionPanel1.TabIndex = 0;
            crownSectionPanel1.Paint += crownSectionPanel1_Paint;
            // 
            // buttonGuiMail
            // 
            buttonGuiMail.Anchor = AnchorStyles.None;
            buttonGuiMail.Location = new Point(384, 28);
            buttonGuiMail.Name = "buttonGuiMail";
            buttonGuiMail.Padding = new Padding(5);
            buttonGuiMail.Size = new Size(139, 32);
            buttonGuiMail.TabIndex = 22;
            buttonGuiMail.Text = "Gửi mail cho thí sinh";
            buttonGuiMail.Click += buttonGuiMail_Click;
            // 
            // ButtonTimKiemTheoDe
            // 
            ButtonTimKiemTheoDe.Anchor = AnchorStyles.None;
            ButtonTimKiemTheoDe.Location = new Point(529, 100);
            ButtonTimKiemTheoDe.Name = "ButtonTimKiemTheoDe";
            ButtonTimKiemTheoDe.Padding = new Padding(5);
            ButtonTimKiemTheoDe.Size = new Size(132, 29);
            ButtonTimKiemTheoDe.TabIndex = 21;
            ButtonTimKiemTheoDe.Text = "Tìm kiếm";
            ButtonTimKiemTheoDe.Click += ButtonTimKiemTheoDe_Click;
            // 
            // textBoxTimKiemTheoMaDe
            // 
            textBoxTimKiemTheoMaDe.Anchor = AnchorStyles.None;
            textBoxTimKiemTheoMaDe.BackColor = Color.FromArgb(69, 73, 74);
            textBoxTimKiemTheoMaDe.BorderStyle = BorderStyle.FixedSingle;
            textBoxTimKiemTheoMaDe.Font = new Font("Segoe UI", 9F);
            textBoxTimKiemTheoMaDe.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxTimKiemTheoMaDe.Location = new Point(13, 100);
            textBoxTimKiemTheoMaDe.Multiline = true;
            textBoxTimKiemTheoMaDe.Name = "textBoxTimKiemTheoMaDe";
            textBoxTimKiemTheoMaDe.PlaceholderText = "Tìm kiếm theo mã đề";
            textBoxTimKiemTheoMaDe.Size = new Size(510, 29);
            textBoxTimKiemTheoMaDe.TabIndex = 20;
            // 
            // crownGroupBox1
            // 
            crownGroupBox1.Anchor = AnchorStyles.None;
            crownGroupBox1.BorderColor = Color.FromArgb(51, 51, 51);
            crownGroupBox1.Controls.Add(btnLocDuLieu);
            crownGroupBox1.Controls.Add(CheckBoxRot);
            crownGroupBox1.Controls.Add(CheckBoxDau);
            crownGroupBox1.Location = new Point(667, 28);
            crownGroupBox1.Name = "crownGroupBox1";
            crownGroupBox1.Size = new Size(121, 99);
            crownGroupBox1.TabIndex = 19;
            crownGroupBox1.TabStop = false;
            crownGroupBox1.Text = "Lọc dữ liệu";
            // 
            // btnLocDuLieu
            // 
            btnLocDuLieu.Location = new Point(9, 64);
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
            BUTTON_XUATDS.Anchor = AnchorStyles.None;
            BUTTON_XUATDS.Location = new Point(529, 28);
            BUTTON_XUATDS.Name = "BUTTON_XUATDS";
            BUTTON_XUATDS.Padding = new Padding(5);
            BUTTON_XUATDS.Size = new Size(132, 32);
            BUTTON_XUATDS.TabIndex = 17;
            BUTTON_XUATDS.Text = "Xuất danh sách điểm";
            BUTTON_XUATDS.Click += BUTTON_XUATDS_Click;
            // 
            // BUTTON_XEMDS
            // 
            BUTTON_XEMDS.Anchor = AnchorStyles.None;
            BUTTON_XEMDS.Location = new Point(13, 27);
            BUTTON_XEMDS.Name = "BUTTON_XEMDS";
            BUTTON_XEMDS.Padding = new Padding(5);
            BUTTON_XEMDS.Size = new Size(215, 33);
            BUTTON_XEMDS.TabIndex = 16;
            BUTTON_XEMDS.Text = "Xem danh sách điểm";
            BUTTON_XEMDS.Click += BUTTON_XEMDS_Click;
            // 
            // textBoxTimKiemTheoMaThiSinh
            // 
            textBoxTimKiemTheoMaThiSinh.Anchor = AnchorStyles.None;
            textBoxTimKiemTheoMaThiSinh.BackColor = Color.FromArgb(69, 73, 74);
            textBoxTimKiemTheoMaThiSinh.BorderStyle = BorderStyle.FixedSingle;
            textBoxTimKiemTheoMaThiSinh.Font = new Font("Segoe UI", 9F);
            textBoxTimKiemTheoMaThiSinh.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxTimKiemTheoMaThiSinh.Location = new Point(13, 65);
            textBoxTimKiemTheoMaThiSinh.Multiline = true;
            textBoxTimKiemTheoMaThiSinh.Name = "textBoxTimKiemTheoMaThiSinh";
            textBoxTimKiemTheoMaThiSinh.PlaceholderText = "Tìm kiếm theo mã thí sinh";
            textBoxTimKiemTheoMaThiSinh.Size = new Size(510, 29);
            textBoxTimKiemTheoMaThiSinh.TabIndex = 15;
            // 
            // buttonTimKiem
            // 
            buttonTimKiem.Anchor = AnchorStyles.None;
            buttonTimKiem.Location = new Point(529, 65);
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
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.Size = new Size(800, 315);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ThongKeDiemForm
            // 
            AutoScaleMode = AutoScaleMode.None;
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
        private ReaLTaiizor.Controls.CrownTextBox textBoxTimKiemTheoMaThiSinh;
        private ReaLTaiizor.Controls.CrownButton buttonTimKiem;
        private ReaLTaiizor.Controls.CrownButton BUTTON_XUATDS;
        private ReaLTaiizor.Controls.CrownButton BUTTON_XEMDS;
        private ReaLTaiizor.Controls.CrownGroupBox crownGroupBox1;
        private ReaLTaiizor.Controls.CrownButton btnLocDuLieu;
        private ReaLTaiizor.Controls.CrownCheckBox CheckBoxRot;
        private ReaLTaiizor.Controls.CrownCheckBox CheckBoxDau;
        private DataGridView dataGridView1;
        private ReaLTaiizor.Controls.CrownTextBox textBoxTimKiemTheoMaDe;
        private ReaLTaiizor.Controls.CrownButton ButtonTimKiemTheoDe;
        private ReaLTaiizor.Controls.CrownButton buttonGuiMail;
    }
}