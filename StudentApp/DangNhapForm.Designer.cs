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
            crownTitle6 = new ReaLTaiizor.Controls.CrownTitle();
            crownTitle5 = new ReaLTaiizor.Controls.CrownTitle();
            crownTextBoxMKEmail = new ReaLTaiizor.Controls.CrownTextBox();
            TEXTBOXEMAIL = new ReaLTaiizor.Controls.CrownTextBox();
            crownTitle4 = new ReaLTaiizor.Controls.CrownTitle();
            BUTTONDANGNHAP = new ReaLTaiizor.Controls.CrownButton();
            crownTitle3 = new ReaLTaiizor.Controls.CrownTitle();
            TEXTBOXMATKHAUDE = new ReaLTaiizor.Controls.CrownTextBox();
            crownTitle2 = new ReaLTaiizor.Controls.CrownTitle();
            TEXTBOXMADE = new ReaLTaiizor.Controls.CrownTextBox();
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
            crownSectionPanel2.Controls.Add(crownTitle6);
            crownSectionPanel2.Controls.Add(crownTitle5);
            crownSectionPanel2.Controls.Add(crownTextBoxMKEmail);
            crownSectionPanel2.Controls.Add(TEXTBOXEMAIL);
            crownSectionPanel2.Controls.Add(crownTitle4);
            crownSectionPanel2.Controls.Add(BUTTONDANGNHAP);
            crownSectionPanel2.Controls.Add(crownTitle3);
            crownSectionPanel2.Controls.Add(TEXTBOXMATKHAUDE);
            crownSectionPanel2.Controls.Add(crownTitle2);
            crownSectionPanel2.Controls.Add(TEXTBOXMADE);
            crownSectionPanel2.Controls.Add(crownTitle1);
            crownSectionPanel2.Dock = DockStyle.Fill;
            crownSectionPanel2.Location = new Point(400, 0);
            crownSectionPanel2.Margin = new Padding(0);
            crownSectionPanel2.Name = "crownSectionPanel2";
            crownSectionPanel2.SectionHeader = "Đăng nhập";
            crownSectionPanel2.Size = new Size(400, 419);
            crownSectionPanel2.TabIndex = 2;
            // 
            // crownTitle6
            // 
            crownTitle6.Anchor = AnchorStyles.None;
            crownTitle6.AutoSize = true;
            crownTitle6.Location = new Point(106, 317);
            crownTitle6.Name = "crownTitle6";
            crownTitle6.Size = new Size(92, 15);
            crownTitle6.TabIndex = 9;
            crownTitle6.Text = "Mật khẩu email:";
            // 
            // crownTitle5
            // 
            crownTitle5.Anchor = AnchorStyles.None;
            crownTitle5.AutoSize = true;
            crownTitle5.Location = new Point(106, 258);
            crownTitle5.Name = "crownTitle5";
            crownTitle5.Size = new Size(39, 15);
            crownTitle5.TabIndex = 8;
            crownTitle5.Text = "Email:";
            // 
            // crownTextBoxMKEmail
            // 
            crownTextBoxMKEmail.Anchor = AnchorStyles.None;
            crownTextBoxMKEmail.BackColor = Color.FromArgb(69, 73, 74);
            crownTextBoxMKEmail.BorderStyle = BorderStyle.FixedSingle;
            crownTextBoxMKEmail.ForeColor = Color.FromArgb(220, 220, 220);
            crownTextBoxMKEmail.Location = new Point(106, 335);
            crownTextBoxMKEmail.Name = "crownTextBoxMKEmail";
            crownTextBoxMKEmail.Size = new Size(193, 23);
            crownTextBoxMKEmail.TabIndex = 7;
            // 
            // TEXTBOXEMAIL
            // 
            TEXTBOXEMAIL.Anchor = AnchorStyles.None;
            TEXTBOXEMAIL.BackColor = Color.FromArgb(69, 73, 74);
            TEXTBOXEMAIL.BorderStyle = BorderStyle.FixedSingle;
            TEXTBOXEMAIL.ForeColor = Color.FromArgb(220, 220, 220);
            TEXTBOXEMAIL.Location = new Point(106, 276);
            TEXTBOXEMAIL.Name = "TEXTBOXEMAIL";
            TEXTBOXEMAIL.Size = new Size(193, 23);
            TEXTBOXEMAIL.TabIndex = 6;
            // 
            // crownTitle4
            // 
            crownTitle4.Anchor = AnchorStyles.None;
            crownTitle4.AutoSize = true;
            crownTitle4.Font = new Font("Segoe UI Semilight", 8.2F);
            crownTitle4.Location = new Point(123, 96);
            crownTitle4.MinimumSize = new Size(163, 15);
            crownTitle4.Name = "crownTitle4";
            crownTitle4.Size = new Size(163, 15);
            crownTitle4.TabIndex = 5;
            crownTitle4.Text = "Hãy điền thông tin của bạn";
            // 
            // BUTTONDANGNHAP
            // 
            BUTTONDANGNHAP.Anchor = AnchorStyles.None;
            BUTTONDANGNHAP.ButtonStyle = ReaLTaiizor.Enum.Crown.ButtonStyle.Flat;
            BUTTONDANGNHAP.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BUTTONDANGNHAP.ImagePadding = 6;
            BUTTONDANGNHAP.Location = new Point(157, 381);
            BUTTONDANGNHAP.Name = "BUTTONDANGNHAP";
            BUTTONDANGNHAP.Padding = new Padding(5);
            BUTTONDANGNHAP.Size = new Size(98, 38);
            BUTTONDANGNHAP.TabIndex = 0;
            BUTTONDANGNHAP.Text = "Đăng nhập";
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
            crownTitle3.Click += crownTitle3_Click;
            // 
            // TEXTBOXMATKHAUDE
            // 
            TEXTBOXMATKHAUDE.Anchor = AnchorStyles.None;
            TEXTBOXMATKHAUDE.BackColor = Color.FromArgb(69, 73, 74);
            TEXTBOXMATKHAUDE.BorderStyle = BorderStyle.FixedSingle;
            TEXTBOXMATKHAUDE.ForeColor = Color.FromArgb(220, 220, 220);
            TEXTBOXMATKHAUDE.Location = new Point(106, 214);
            TEXTBOXMATKHAUDE.Name = "TEXTBOXMATKHAUDE";
            TEXTBOXMATKHAUDE.Size = new Size(193, 23);
            TEXTBOXMATKHAUDE.TabIndex = 3;
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
            // TEXTBOXMADE
            // 
            TEXTBOXMADE.Anchor = AnchorStyles.None;
            TEXTBOXMADE.BackColor = Color.FromArgb(69, 73, 74);
            TEXTBOXMADE.BorderStyle = BorderStyle.FixedSingle;
            TEXTBOXMADE.ForeColor = Color.FromArgb(220, 220, 220);
            TEXTBOXMADE.Location = new Point(106, 151);
            TEXTBOXMADE.Name = "TEXTBOXMADE";
            TEXTBOXMADE.Size = new Size(193, 23);
            TEXTBOXMADE.TabIndex = 1;
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
            crownTitle1.Click += crownTitle1_Click;
            // 
            // DangNhapForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 419);
            Controls.Add(layoutPanel);
            Name = "DangNhapForm";
            Text = "PolyTest App - Đăng nhập";
            layoutPanel.ResumeLayout(false);
            crownSectionPanel2.ResumeLayout(false);
            crownSectionPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layoutPanel;
        private ReaLTaiizor.Controls.CrownSectionPanel crownSectionPanel2;
        private ReaLTaiizor.Controls.CrownTextBox TEXTBOXMADE;
        private ReaLTaiizor.Controls.CrownTitle crownTitle1;
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel1;
        private ReaLTaiizor.Controls.CrownTitle crownTitle3;
        private ReaLTaiizor.Controls.CrownTextBox TEXTBOXMATKHAUDE;
        private ReaLTaiizor.Controls.CrownTitle crownTitle2;
        private ReaLTaiizor.Controls.CrownTitle crownTitle4;
        private ReaLTaiizor.Controls.CrownButton BUTTONDANGNHAP;
        private ReaLTaiizor.Controls.CrownTextBox crownTextBoxMKEmail;
        private ReaLTaiizor.Controls.CrownTextBox TEXTBOXEMAIL;
        private ReaLTaiizor.Controls.CrownTitle crownTitle6;
        private ReaLTaiizor.Controls.CrownTitle crownTitle5;
    }
}
