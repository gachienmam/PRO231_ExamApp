namespace ManagementApp
{
    partial class DangNhapForm
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
            layoutPanel = new TableLayoutPanel();
            parrotGradientPanel1 = new ReaLTaiizor.Controls.ParrotGradientPanel();
            crownSectionPanel2 = new ReaLTaiizor.Controls.CrownSectionPanel();
            crownTitle4 = new ReaLTaiizor.Controls.CrownTitle();
            btnLogin = new ReaLTaiizor.Controls.CrownButton();
            crownTitle3 = new ReaLTaiizor.Controls.CrownTitle();
            txtPassword = new ReaLTaiizor.Controls.CrownTextBox();
            crownTitle2 = new ReaLTaiizor.Controls.CrownTitle();
            txtEmail = new ReaLTaiizor.Controls.CrownTextBox();
            crownTitle1 = new ReaLTaiizor.Controls.CrownTitle();
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
            crownSectionPanel2.Controls.Add(crownTitle4);
            crownSectionPanel2.Controls.Add(btnLogin);
            crownSectionPanel2.Controls.Add(crownTitle3);
            crownSectionPanel2.Controls.Add(txtPassword);
            crownSectionPanel2.Controls.Add(crownTitle2);
            crownSectionPanel2.Controls.Add(txtEmail);
            crownSectionPanel2.Controls.Add(crownTitle1);
            crownSectionPanel2.Dock = DockStyle.Fill;
            crownSectionPanel2.Location = new Point(400, 0);
            crownSectionPanel2.Margin = new Padding(0);
            crownSectionPanel2.Name = "crownSectionPanel2";
            crownSectionPanel2.SectionHeader = "Đăng nhập";
            crownSectionPanel2.Size = new Size(400, 419);
            crownSectionPanel2.TabIndex = 2;
            // 
            // crownTitle4
            // 
            crownTitle4.Anchor = AnchorStyles.None;
            crownTitle4.AutoSize = true;
            crownTitle4.Font = new Font("Segoe UI Semilight", 8.2F);
            crownTitle4.Location = new Point(123, 126);
            crownTitle4.MinimumSize = new Size(163, 15);
            crownTitle4.Name = "crownTitle4";
            crownTitle4.Size = new Size(163, 15);
            crownTitle4.TabIndex = 5;
            crownTitle4.Text = "Nhập email và mật khẩu của bạn";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.ButtonStyle = ReaLTaiizor.Enum.Crown.ButtonStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ImagePadding = 6;
            btnLogin.Location = new Point(146, 287);
            btnLogin.Name = "btnLogin";
            btnLogin.Padding = new Padding(5);
            btnLogin.Size = new Size(113, 28);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Đăng nhập";
            btnLogin.Click += btnLogin_Click;
            // 
            // crownTitle3
            // 
            crownTitle3.Anchor = AnchorStyles.None;
            crownTitle3.AutoSize = true;
            crownTitle3.Location = new Point(106, 216);
            crownTitle3.Name = "crownTitle3";
            crownTitle3.Size = new Size(57, 15);
            crownTitle3.TabIndex = 4;
            crownTitle3.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.BackColor = Color.FromArgb(69, 73, 74);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.ForeColor = Color.FromArgb(220, 220, 220);
            txtPassword.Location = new Point(106, 234);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Email";
            txtPassword.Size = new Size(193, 23);
            txtPassword.TabIndex = 3;
            // 
            // crownTitle2
            // 
            crownTitle2.Anchor = AnchorStyles.None;
            crownTitle2.AutoSize = true;
            crownTitle2.Location = new Point(106, 154);
            crownTitle2.Name = "crownTitle2";
            crownTitle2.Size = new Size(36, 15);
            crownTitle2.TabIndex = 2;
            crownTitle2.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.None;
            txtEmail.BackColor = Color.FromArgb(69, 73, 74);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.ForeColor = Color.FromArgb(220, 220, 220);
            txtEmail.Location = new Point(106, 172);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(193, 23);
            txtEmail.TabIndex = 1;
            // 
            // crownTitle1
            // 
            crownTitle1.Anchor = AnchorStyles.None;
            crownTitle1.AutoSize = true;
            crownTitle1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            crownTitle1.Location = new Point(157, 85);
            crownTitle1.Name = "crownTitle1";
            crownTitle1.Size = new Size(98, 32);
            crownTitle1.TabIndex = 0;
            crownTitle1.Text = "Quản lý";
            // 
            // DangNhapForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 419);
            Controls.Add(layoutPanel);
            Name = "DangNhapForm";
            Text = "PolyTest Manager - Đăng nhập";
            layoutPanel.ResumeLayout(false);
            crownSectionPanel2.ResumeLayout(false);
            crownSectionPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layoutPanel;
        private ReaLTaiizor.Controls.CrownSectionPanel crownSectionPanel2;
        private ReaLTaiizor.Controls.CrownTextBox txtEmail;
        private ReaLTaiizor.Controls.CrownTitle crownTitle1;
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel1;
        private ReaLTaiizor.Controls.CrownTitle crownTitle3;
        private ReaLTaiizor.Controls.CrownTextBox txtPassword;
        private ReaLTaiizor.Controls.CrownTitle crownTitle2;
        private ReaLTaiizor.Controls.CrownTitle crownTitle4;
        private ReaLTaiizor.Controls.CrownButton btnLogin;
    }
}