﻿namespace ManagementApp
{
    partial class DoiMatKhauForm
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
            BUTTONTHOAT = new ReaLTaiizor.Controls.CrownButton();
            crownTitle5 = new ReaLTaiizor.Controls.CrownTitle();
            TextBoxXNhapLaiMatKhau = new ReaLTaiizor.Controls.CrownTextBox();
            BUTTONDOIMATKHAU = new ReaLTaiizor.Controls.CrownButton();
            crownTitle3 = new ReaLTaiizor.Controls.CrownTitle();
            TEXTBOXMATKHAUMOI = new ReaLTaiizor.Controls.CrownTextBox();
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
            layoutPanel.Size = new Size(784, 380);
            layoutPanel.TabIndex = 1;
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
            parrotGradientPanel1.Size = new Size(392, 380);
            parrotGradientPanel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            parrotGradientPanel1.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Vertical;
            parrotGradientPanel1.TabIndex = 5;
            parrotGradientPanel1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            parrotGradientPanel1.TopLeft = Color.Gray;
            parrotGradientPanel1.TopRight = Color.FromArgb(69, 73, 74);
            // 
            // crownSectionPanel2
            // 
            crownSectionPanel2.Controls.Add(BUTTONTHOAT);
            crownSectionPanel2.Controls.Add(crownTitle5);
            crownSectionPanel2.Controls.Add(TextBoxXNhapLaiMatKhau);
            crownSectionPanel2.Controls.Add(BUTTONDOIMATKHAU);
            crownSectionPanel2.Controls.Add(crownTitle3);
            crownSectionPanel2.Controls.Add(TEXTBOXMATKHAUMOI);
            crownSectionPanel2.Controls.Add(crownTitle1);
            crownSectionPanel2.Dock = DockStyle.Fill;
            crownSectionPanel2.Location = new Point(392, 0);
            crownSectionPanel2.Margin = new Padding(0);
            crownSectionPanel2.Name = "crownSectionPanel2";
            crownSectionPanel2.SectionHeader = "Đổi mật khẩu";
            crownSectionPanel2.Size = new Size(392, 380);
            crownSectionPanel2.TabIndex = 2;
            // 
            // BUTTONTHOAT
            // 
            BUTTONTHOAT.Anchor = AnchorStyles.None;
            BUTTONTHOAT.ButtonStyle = ReaLTaiizor.Enum.Crown.ButtonStyle.Flat;
            BUTTONTHOAT.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BUTTONTHOAT.ImagePadding = 6;
            BUTTONTHOAT.Location = new Point(200, 267);
            BUTTONTHOAT.Name = "BUTTONTHOAT";
            BUTTONTHOAT.Padding = new Padding(5);
            BUTTONTHOAT.Size = new Size(98, 38);
            BUTTONTHOAT.TabIndex = 20;
            BUTTONTHOAT.Text = "Thoát";
            BUTTONTHOAT.Click += BUTTONTHOAT_Click;
            // 
            // crownTitle5
            // 
            crownTitle5.Anchor = AnchorStyles.None;
            crownTitle5.AutoSize = true;
            crownTitle5.Location = new Point(101, 198);
            crownTitle5.Name = "crownTitle5";
            crownTitle5.Size = new Size(107, 15);
            crownTitle5.TabIndex = 19;
            crownTitle5.Text = "Nhập lại mật khẩu:";
            // 
            // TextBoxXNhapLaiMatKhau
            // 
            TextBoxXNhapLaiMatKhau.Anchor = AnchorStyles.None;
            TextBoxXNhapLaiMatKhau.BackColor = Color.FromArgb(69, 73, 74);
            TextBoxXNhapLaiMatKhau.BorderStyle = BorderStyle.FixedSingle;
            TextBoxXNhapLaiMatKhau.ForeColor = Color.FromArgb(220, 220, 220);
            TextBoxXNhapLaiMatKhau.Location = new Point(101, 216);
            TextBoxXNhapLaiMatKhau.Name = "TextBoxXNhapLaiMatKhau";
            TextBoxXNhapLaiMatKhau.Size = new Size(193, 23);
            TextBoxXNhapLaiMatKhau.TabIndex = 17;
            // 
            // BUTTONDOIMATKHAU
            // 
            BUTTONDOIMATKHAU.Anchor = AnchorStyles.None;
            BUTTONDOIMATKHAU.ButtonStyle = ReaLTaiizor.Enum.Crown.ButtonStyle.Flat;
            BUTTONDOIMATKHAU.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BUTTONDOIMATKHAU.ImagePadding = 6;
            BUTTONDOIMATKHAU.Location = new Point(109, 267);
            BUTTONDOIMATKHAU.Name = "BUTTONDOIMATKHAU";
            BUTTONDOIMATKHAU.Padding = new Padding(5);
            BUTTONDOIMATKHAU.Size = new Size(98, 38);
            BUTTONDOIMATKHAU.TabIndex = 10;
            BUTTONDOIMATKHAU.Text = "Đổi mật khẩu";
            BUTTONDOIMATKHAU.Click += BUTTONDOIMATKHAU_Click;
            // 
            // crownTitle3
            // 
            crownTitle3.Anchor = AnchorStyles.None;
            crownTitle3.AutoSize = true;
            crownTitle3.Location = new Point(101, 136);
            crownTitle3.Name = "crownTitle3";
            crownTitle3.Size = new Size(84, 15);
            crownTitle3.TabIndex = 15;
            crownTitle3.Text = "Mật khẩu mới:";
            // 
            // TEXTBOXMATKHAUMOI
            // 
            TEXTBOXMATKHAUMOI.Anchor = AnchorStyles.None;
            TEXTBOXMATKHAUMOI.BackColor = Color.FromArgb(69, 73, 74);
            TEXTBOXMATKHAUMOI.BorderStyle = BorderStyle.FixedSingle;
            TEXTBOXMATKHAUMOI.ForeColor = Color.FromArgb(220, 220, 220);
            TEXTBOXMATKHAUMOI.Location = new Point(101, 154);
            TEXTBOXMATKHAUMOI.Name = "TEXTBOXMATKHAUMOI";
            TEXTBOXMATKHAUMOI.Size = new Size(193, 23);
            TEXTBOXMATKHAUMOI.TabIndex = 14;
            // 
            // crownTitle1
            // 
            crownTitle1.Anchor = AnchorStyles.None;
            crownTitle1.AutoSize = true;
            crownTitle1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            crownTitle1.Location = new Point(122, 74);
            crownTitle1.Name = "crownTitle1";
            crownTitle1.Size = new Size(162, 32);
            crownTitle1.TabIndex = 11;
            crownTitle1.Text = "Đổi mật khẩu";
            // 
            // DoiMatKhauForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(784, 380);
            Controls.Add(layoutPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimumSize = new Size(800, 419);
            Name = "DoiMatKhauForm";
            Text = "PolyTest Manager - Đổi mật khẩu";
            Load += DoiMatKhauForm_Load;
            layoutPanel.ResumeLayout(false);
            crownSectionPanel2.ResumeLayout(false);
            crownSectionPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layoutPanel;
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel1;
        private ReaLTaiizor.Controls.CrownSectionPanel crownSectionPanel2;
        private ReaLTaiizor.Controls.CrownTitle crownTitle5;
        private ReaLTaiizor.Controls.CrownTextBox TextBoxXNhapLaiMatKhau;
        private ReaLTaiizor.Controls.CrownButton BUTTONDOIMATKHAU;
        private ReaLTaiizor.Controls.CrownTitle crownTitle3;
        private ReaLTaiizor.Controls.CrownTextBox TEXTBOXMATKHAUMOI;
        private ReaLTaiizor.Controls.CrownTitle crownTitle1;
        private ReaLTaiizor.Controls.CrownButton BUTTONTHOAT;
    }
}