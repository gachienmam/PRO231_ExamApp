namespace StudentApp
{
    partial class DangNhapForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            layoutPanel = new TableLayoutPanel();
            parrotGradientPanel1 = new ReaLTaiizor.Controls.ParrotGradientPanel();
            crownSectionPanel2 = new ReaLTaiizor.Controls.CrownSectionPanel();
            buttonSettings = new ReaLTaiizor.Controls.CrownButton();
            crownTitle6 = new ReaLTaiizor.Controls.CrownTitle();
            crownTitle5 = new ReaLTaiizor.Controls.CrownTitle();
            textBoxMatKhauThiSinh = new ReaLTaiizor.Controls.CrownTextBox();
            textBoxThiSinhId = new ReaLTaiizor.Controls.CrownTextBox();
            crownTitle4 = new ReaLTaiizor.Controls.CrownTitle();
            btnDangNhap = new ReaLTaiizor.Controls.CrownButton();
            crownTitle3 = new ReaLTaiizor.Controls.CrownTitle();
            textBoxMatKhauDe = new ReaLTaiizor.Controls.CrownTextBox();
            crownTitle2 = new ReaLTaiizor.Controls.CrownTitle();
            textBoxMaDe = new ReaLTaiizor.Controls.CrownTextBox();
            crownTitle1 = new ReaLTaiizor.Controls.CrownTitle();
            buttonGioiThieu = new ReaLTaiizor.Controls.CrownButton();
            layoutPanel.SuspendLayout();
            crownSectionPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // layoutPanel
            // 
            layoutPanel.ColumnCount = 2;
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutPanel.Controls.Add(parrotGradientPanel1, 0, 0);
            layoutPanel.Controls.Add(crownSectionPanel2, 1, 0);
            layoutPanel.Dock = DockStyle.Fill;
            layoutPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            layoutPanel.Location = new Point(0, 0);
            layoutPanel.Margin = new Padding(0);
            layoutPanel.Name = "layoutPanel";
            layoutPanel.RowCount = 1;
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layoutPanel.Size = new Size(800, 419);
            layoutPanel.TabIndex = 0;
            // 
            // parrotGradientPanel1
            // 
            parrotGradientPanel1.BottomLeft = Color.Black;
            parrotGradientPanel1.BottomRight = Color.Indigo;
            parrotGradientPanel1.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            parrotGradientPanel1.Dock = DockStyle.Fill;
            parrotGradientPanel1.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            parrotGradientPanel1.Location = new Point(0, 0);
            parrotGradientPanel1.Margin = new Padding(0);
            parrotGradientPanel1.Name = "parrotGradientPanel1";
            parrotGradientPanel1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotGradientPanel1.PrimerColor = Color.White;
            parrotGradientPanel1.Size = new Size(400, 419);
            parrotGradientPanel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            parrotGradientPanel1.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Vertical;
            parrotGradientPanel1.TabIndex = 5;
            parrotGradientPanel1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            parrotGradientPanel1.TopLeft = Color.Gray;
            parrotGradientPanel1.TopRight = Color.FromArgb(69, 73, 74);
            // 
            // crownSectionPanel2
            // 
            crownSectionPanel2.Controls.Add(buttonGioiThieu);
            crownSectionPanel2.Controls.Add(buttonSettings);
            crownSectionPanel2.Controls.Add(crownTitle6);
            crownSectionPanel2.Controls.Add(crownTitle5);
            crownSectionPanel2.Controls.Add(textBoxMatKhauThiSinh);
            crownSectionPanel2.Controls.Add(textBoxThiSinhId);
            crownSectionPanel2.Controls.Add(crownTitle4);
            crownSectionPanel2.Controls.Add(btnDangNhap);
            crownSectionPanel2.Controls.Add(crownTitle3);
            crownSectionPanel2.Controls.Add(textBoxMatKhauDe);
            crownSectionPanel2.Controls.Add(crownTitle2);
            crownSectionPanel2.Controls.Add(textBoxMaDe);
            crownSectionPanel2.Controls.Add(crownTitle1);
            crownSectionPanel2.Dock = DockStyle.Fill;
            crownSectionPanel2.Location = new Point(400, 0);
            crownSectionPanel2.Margin = new Padding(0);
            crownSectionPanel2.Name = "crownSectionPanel2";
            crownSectionPanel2.SectionHeader = "Đăng nhập";
            crownSectionPanel2.Size = new Size(400, 419);
            crownSectionPanel2.TabIndex = 2;
            // 
            // buttonSettings
            // 
            buttonSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSettings.ButtonStyle = ReaLTaiizor.Enum.Crown.ButtonStyle.Flat;
            buttonSettings.Location = new Point(324, 2);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Padding = new Padding(5);
            buttonSettings.Size = new Size(75, 23);
            buttonSettings.TabIndex = 10;
            buttonSettings.Text = "Cài đặt";
            buttonSettings.Click += buttonSettings_Click;
            // 
            // crownTitle6
            // 
            crownTitle6.Anchor = AnchorStyles.None;
            crownTitle6.AutoSize = true;
            crownTitle6.Location = new Point(106, 317);
            crownTitle6.Name = "crownTitle6";
            crownTitle6.Size = new Size(102, 15);
            crownTitle6.TabIndex = 9;
            crownTitle6.Text = "Mật khẩu thí sinh:";
            // 
            // crownTitle5
            // 
            crownTitle5.Anchor = AnchorStyles.None;
            crownTitle5.AutoSize = true;
            crownTitle5.Location = new Point(106, 258);
            crownTitle5.Name = "crownTitle5";
            crownTitle5.Size = new Size(70, 15);
            crownTitle5.TabIndex = 8;
            crownTitle5.Text = "Tên thí sinh:";
            // 
            // textBoxMatKhauThiSinh
            // 
            textBoxMatKhauThiSinh.Anchor = AnchorStyles.None;
            textBoxMatKhauThiSinh.BackColor = Color.FromArgb(69, 73, 74);
            textBoxMatKhauThiSinh.BorderStyle = BorderStyle.FixedSingle;
            textBoxMatKhauThiSinh.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxMatKhauThiSinh.Location = new Point(106, 335);
            textBoxMatKhauThiSinh.Name = "textBoxMatKhauThiSinh";
            textBoxMatKhauThiSinh.Size = new Size(193, 23);
            textBoxMatKhauThiSinh.TabIndex = 7;
            // 
            // textBoxThiSinhId
            // 
            textBoxThiSinhId.Anchor = AnchorStyles.None;
            textBoxThiSinhId.BackColor = Color.FromArgb(69, 73, 74);
            textBoxThiSinhId.BorderStyle = BorderStyle.FixedSingle;
            textBoxThiSinhId.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxThiSinhId.Location = new Point(106, 276);
            textBoxThiSinhId.Name = "textBoxThiSinhId";
            textBoxThiSinhId.Size = new Size(193, 23);
            textBoxThiSinhId.TabIndex = 6;
            // 
            // crownTitle4
            // 
            crownTitle4.Anchor = AnchorStyles.None;
            crownTitle4.AutoSize = true;
            crownTitle4.Font = new Font("Segoe UI Semilight", 8.2F);
            crownTitle4.Location = new Point(138, 93);
            crownTitle4.MinimumSize = new Size(0, 16);
            crownTitle4.Name = "crownTitle4";
            crownTitle4.Size = new Size(134, 16);
            crownTitle4.TabIndex = 5;
            crownTitle4.Text = "Hãy điền thông tin của bạn";
            // 
            // btnDangNhap
            // 
            btnDangNhap.Anchor = AnchorStyles.None;
            btnDangNhap.ButtonStyle = ReaLTaiizor.Enum.Crown.ButtonStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDangNhap.ImagePadding = 6;
            btnDangNhap.Location = new Point(153, 369);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Padding = new Padding(5);
            btnDangNhap.Size = new Size(98, 38);
            btnDangNhap.TabIndex = 0;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // crownTitle3
            // 
            crownTitle3.Anchor = AnchorStyles.None;
            crownTitle3.AutoSize = true;
            crownTitle3.Location = new Point(106, 196);
            crownTitle3.Name = "crownTitle3";
            crownTitle3.Size = new Size(76, 15);
            crownTitle3.TabIndex = 4;
            crownTitle3.Text = "Mật khẩu đề:";
            // 
            // textBoxMatKhauDe
            // 
            textBoxMatKhauDe.Anchor = AnchorStyles.None;
            textBoxMatKhauDe.BackColor = Color.FromArgb(69, 73, 74);
            textBoxMatKhauDe.BorderStyle = BorderStyle.FixedSingle;
            textBoxMatKhauDe.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxMatKhauDe.Location = new Point(106, 214);
            textBoxMatKhauDe.Name = "textBoxMatKhauDe";
            textBoxMatKhauDe.Size = new Size(193, 23);
            textBoxMatKhauDe.TabIndex = 3;
            // 
            // crownTitle2
            // 
            crownTitle2.Anchor = AnchorStyles.None;
            crownTitle2.AutoSize = true;
            crownTitle2.Location = new Point(106, 133);
            crownTitle2.Name = "crownTitle2";
            crownTitle2.Size = new Size(43, 15);
            crownTitle2.TabIndex = 2;
            crownTitle2.Text = "Mã đề:";
            // 
            // textBoxMaDe
            // 
            textBoxMaDe.Anchor = AnchorStyles.None;
            textBoxMaDe.BackColor = Color.FromArgb(69, 73, 74);
            textBoxMaDe.BorderStyle = BorderStyle.FixedSingle;
            textBoxMaDe.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxMaDe.Location = new Point(106, 151);
            textBoxMaDe.Name = "textBoxMaDe";
            textBoxMaDe.Size = new Size(193, 23);
            textBoxMaDe.TabIndex = 1;
            // 
            // crownTitle1
            // 
            crownTitle1.Anchor = AnchorStyles.None;
            crownTitle1.AutoSize = true;
            crownTitle1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            crownTitle1.Location = new Point(114, 46);
            crownTitle1.Name = "crownTitle1";
            crownTitle1.Size = new Size(185, 32);
            crownTitle1.TabIndex = 0;
            crownTitle1.Text = "Thi trắc nghiệm";
            // 
            // buttonGioiThieu
            // 
            buttonGioiThieu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonGioiThieu.ButtonStyle = ReaLTaiizor.Enum.Crown.ButtonStyle.Flat;
            buttonGioiThieu.Location = new Point(254, 2);
            buttonGioiThieu.Name = "buttonGioiThieu";
            buttonGioiThieu.Padding = new Padding(5);
            buttonGioiThieu.Size = new Size(75, 23);
            buttonGioiThieu.TabIndex = 11;
            buttonGioiThieu.Text = "Giới thiệu";
            buttonGioiThieu.Click += buttonGioiThieu_Click;
            // 
            // DangNhapForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 419);
            Controls.Add(layoutPanel);
            Name = "DangNhapForm";
            Text = "PolyTest App - Đăng nhập";
            Load += DangNhapForm_Load;
            layoutPanel.ResumeLayout(false);
            crownSectionPanel2.ResumeLayout(false);
            crownSectionPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layoutPanel;
        private ReaLTaiizor.Controls.CrownSectionPanel crownSectionPanel2;
        private ReaLTaiizor.Controls.CrownTextBox textBoxMaDe;
        private ReaLTaiizor.Controls.CrownTitle crownTitle1;
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel1;
        private ReaLTaiizor.Controls.CrownTitle crownTitle3;
        private ReaLTaiizor.Controls.CrownTextBox textBoxMatKhauDe;
        private ReaLTaiizor.Controls.CrownTitle crownTitle2;
        private ReaLTaiizor.Controls.CrownTitle crownTitle4;
        private ReaLTaiizor.Controls.CrownButton btnDangNhap;
        private ReaLTaiizor.Controls.CrownTextBox textBoxMatKhauThiSinh;
        private ReaLTaiizor.Controls.CrownTextBox textBoxThiSinhId;
        private ReaLTaiizor.Controls.CrownTitle crownTitle6;
        private ReaLTaiizor.Controls.CrownTitle crownTitle5;
        private ReaLTaiizor.Controls.CrownButton buttonSettings;
        private ReaLTaiizor.Controls.CrownButton buttonGioiThieu;
    }
}
