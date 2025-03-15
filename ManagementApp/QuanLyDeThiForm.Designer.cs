namespace ManagementApp
{
    partial class QuanLyDeThiForm
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
            statusLabel = new ToolStripStatusLabel();
            stripProgressBar = new ToolStripProgressBar();
            statusStrip = new ReaLTaiizor.Controls.CrownStatusStrip();
            dockPanel = new ReaLTaiizor.Docking.Crown.CrownDockPanel();
            examTreeView = new ReaLTaiizor.Controls.CrownTreeView();
            splitter1 = new Splitter();
            crownTitle1 = new ReaLTaiizor.Controls.CrownTitle();
            parrotGradientPanel1 = new ReaLTaiizor.Controls.ParrotGradientPanel();
            crownTitle2 = new ReaLTaiizor.Controls.CrownTitle();
            crownTextBox1 = new ReaLTaiizor.Controls.CrownTextBox();
            crownTextBox2 = new ReaLTaiizor.Controls.CrownTextBox();
            crownTitle3 = new ReaLTaiizor.Controls.CrownTitle();
            crownTextBox3 = new ReaLTaiizor.Controls.CrownTextBox();
            crownTitle4 = new ReaLTaiizor.Controls.CrownTitle();
            crownTitle5 = new ReaLTaiizor.Controls.CrownTitle();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            crownTitle6 = new ReaLTaiizor.Controls.CrownTitle();
            crownDropDownList1 = new ReaLTaiizor.Controls.CrownDropDownList();
            crownTitle7 = new ReaLTaiizor.Controls.CrownTitle();
            parrotGradientPanel2 = new ReaLTaiizor.Controls.ParrotGradientPanel();
            crownTitle8 = new ReaLTaiizor.Controls.CrownTitle();
            crownTextBox4 = new ReaLTaiizor.Controls.CrownTextBox();
            crownTitle9 = new ReaLTaiizor.Controls.CrownTitle();
            crownTextBox5 = new ReaLTaiizor.Controls.CrownTextBox();
            crownTitle10 = new ReaLTaiizor.Controls.CrownTitle();
            crownButton3 = new ReaLTaiizor.Controls.CrownButton();
            crownButton1 = new ReaLTaiizor.Controls.CrownButton();
            crownButton2 = new ReaLTaiizor.Controls.CrownButton();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // statusLabel
            // 
            statusLabel.Font = new Font("Segoe UI", 8F);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(55, 13);
            statusLabel.Text = "Đang đợi";
            // 
            // stripProgressBar
            // 
            stripProgressBar.Name = "stripProgressBar";
            stripProgressBar.Size = new Size(150, 12);
            // 
            // statusStrip
            // 
            statusStrip.AutoSize = false;
            statusStrip.BackColor = Color.FromArgb(60, 63, 65);
            statusStrip.ForeColor = Color.FromArgb(220, 220, 220);
            statusStrip.ImageScalingSize = new Size(28, 28);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel, stripProgressBar });
            statusStrip.Location = new Point(0, 393);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(0, 5, 0, 3);
            statusStrip.Size = new Size(800, 26);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip";
            // 
            // dockPanel
            // 
            dockPanel.BackColor = Color.FromArgb(60, 63, 65);
            dockPanel.Dock = DockStyle.Fill;
            dockPanel.Location = new Point(143, 0);
            dockPanel.Name = "dockPanel";
            dockPanel.Size = new Size(657, 393);
            dockPanel.TabIndex = 6;
            // 
            // examTreeView
            // 
            examTreeView.Dock = DockStyle.Left;
            examTreeView.Location = new Point(0, 0);
            examTreeView.MaxDragChange = 20;
            examTreeView.MinimumSize = new Size(140, 0);
            examTreeView.Name = "examTreeView";
            examTreeView.ShowIcons = true;
            examTreeView.Size = new Size(140, 393);
            examTreeView.TabIndex = 3;
            examTreeView.Text = "crownTreeView1";
            // 
            // splitter1
            // 
            splitter1.Location = new Point(140, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 393);
            splitter1.TabIndex = 5;
            splitter1.TabStop = false;
            // 
            // crownTitle1
            // 
            crownTitle1.AutoSize = true;
            crownTitle1.Font = new Font("Segoe UI", 16F);
            crownTitle1.Location = new Point(169, 19);
            crownTitle1.Name = "crownTitle1";
            crownTitle1.Size = new Size(136, 30);
            crownTitle1.TabIndex = 7;
            crownTitle1.Text = "Thông tin đề";
            // 
            // parrotGradientPanel1
            // 
            parrotGradientPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            parrotGradientPanel1.BottomLeft = Color.Black;
            parrotGradientPanel1.BottomRight = Color.Fuchsia;
            parrotGradientPanel1.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            parrotGradientPanel1.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            parrotGradientPanel1.Location = new Point(316, 33);
            parrotGradientPanel1.Name = "parrotGradientPanel1";
            parrotGradientPanel1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotGradientPanel1.PrimerColor = Color.White;
            parrotGradientPanel1.Size = new Size(450, 4);
            parrotGradientPanel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            parrotGradientPanel1.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Corners;
            parrotGradientPanel1.TabIndex = 8;
            parrotGradientPanel1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            parrotGradientPanel1.TopLeft = Color.DeepSkyBlue;
            parrotGradientPanel1.TopRight = Color.Fuchsia;
            // 
            // crownTitle2
            // 
            crownTitle2.AutoSize = true;
            crownTitle2.Font = new Font("Segoe UI", 9F);
            crownTitle2.Location = new Point(207, 66);
            crownTitle2.Name = "crownTitle2";
            crownTitle2.Size = new Size(40, 15);
            crownTitle2.TabIndex = 9;
            crownTitle2.Text = "Mã đề";
            // 
            // crownTextBox1
            // 
            crownTextBox1.BackColor = Color.FromArgb(69, 73, 74);
            crownTextBox1.BorderStyle = BorderStyle.FixedSingle;
            crownTextBox1.ForeColor = Color.FromArgb(220, 220, 220);
            crownTextBox1.Location = new Point(253, 64);
            crownTextBox1.Name = "crownTextBox1";
            crownTextBox1.Size = new Size(100, 23);
            crownTextBox1.TabIndex = 10;
            // 
            // crownTextBox2
            // 
            crownTextBox2.BackColor = Color.FromArgb(69, 73, 74);
            crownTextBox2.BorderStyle = BorderStyle.FixedSingle;
            crownTextBox2.ForeColor = Color.FromArgb(220, 220, 220);
            crownTextBox2.Location = new Point(253, 93);
            crownTextBox2.Name = "crownTextBox2";
            crownTextBox2.Size = new Size(100, 23);
            crownTextBox2.TabIndex = 12;
            // 
            // crownTitle3
            // 
            crownTitle3.AutoSize = true;
            crownTitle3.Font = new Font("Segoe UI", 9F);
            crownTitle3.Location = new Point(169, 95);
            crownTitle3.Name = "crownTitle3";
            crownTitle3.Size = new Size(78, 15);
            crownTitle3.TabIndex = 11;
            crownTitle3.Text = "Mã người tạo";
            // 
            // crownTextBox3
            // 
            crownTextBox3.BackColor = Color.FromArgb(69, 73, 74);
            crownTextBox3.BorderStyle = BorderStyle.FixedSingle;
            crownTextBox3.ForeColor = Color.FromArgb(220, 220, 220);
            crownTextBox3.Location = new Point(253, 122);
            crownTextBox3.Name = "crownTextBox3";
            crownTextBox3.Size = new Size(100, 23);
            crownTextBox3.TabIndex = 14;
            // 
            // crownTitle4
            // 
            crownTitle4.AutoSize = true;
            crownTitle4.Font = new Font("Segoe UI", 9F);
            crownTitle4.Location = new Point(174, 124);
            crownTitle4.Name = "crownTitle4";
            crownTitle4.Size = new Size(73, 15);
            crownTitle4.TabIndex = 13;
            crownTitle4.Text = "Mật khẩu đề";
            // 
            // crownTitle5
            // 
            crownTitle5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            crownTitle5.AutoSize = true;
            crownTitle5.Font = new Font("Segoe UI", 9F);
            crownTitle5.Location = new Point(463, 66);
            crownTitle5.Name = "crownTitle5";
            crownTitle5.Size = new Size(99, 15);
            crownTitle5.TabIndex = 15;
            crownTitle5.Text = "Thời gian bất đầu";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimePicker1.CustomFormat = "yyyy/mm/dd hh:mm:ss tt";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(568, 64);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(199, 23);
            dateTimePicker1.TabIndex = 16;
            dateTimePicker1.Value = new DateTime(2025, 3, 15, 15, 1, 0, 0);
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimePicker2.CustomFormat = "yyyy/mm/dd hh:mm:ss tt";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(568, 93);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(199, 23);
            dateTimePicker2.TabIndex = 18;
            dateTimePicker2.Value = new DateTime(2025, 3, 15, 15, 1, 0, 0);
            // 
            // crownTitle6
            // 
            crownTitle6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            crownTitle6.AutoSize = true;
            crownTitle6.Font = new Font("Segoe UI", 9F);
            crownTitle6.Location = new Point(460, 95);
            crownTitle6.Name = "crownTitle6";
            crownTitle6.Size = new Size(102, 15);
            crownTitle6.TabIndex = 17;
            crownTitle6.Text = "Thời gian kết thúc";
            // 
            // crownDropDownList1
            // 
            crownDropDownList1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            crownDropDownList1.Location = new Point(568, 122);
            crownDropDownList1.Name = "crownDropDownList1";
            crownDropDownList1.Size = new Size(200, 23);
            crownDropDownList1.TabIndex = 19;
            crownDropDownList1.Text = "crownDropDownList1";
            // 
            // crownTitle7
            // 
            crownTitle7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            crownTitle7.AutoSize = true;
            crownTitle7.Font = new Font("Segoe UI", 9F);
            crownTitle7.Location = new Point(503, 124);
            crownTitle7.Name = "crownTitle7";
            crownTitle7.Size = new Size(59, 15);
            crownTitle7.TabIndex = 20;
            crownTitle7.Text = "Trạng thái";
            // 
            // parrotGradientPanel2
            // 
            parrotGradientPanel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            parrotGradientPanel2.BottomLeft = Color.Black;
            parrotGradientPanel2.BottomRight = Color.Fuchsia;
            parrotGradientPanel2.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            parrotGradientPanel2.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            parrotGradientPanel2.Location = new Point(316, 273);
            parrotGradientPanel2.Name = "parrotGradientPanel2";
            parrotGradientPanel2.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotGradientPanel2.PrimerColor = Color.White;
            parrotGradientPanel2.Size = new Size(450, 4);
            parrotGradientPanel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            parrotGradientPanel2.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Corners;
            parrotGradientPanel2.TabIndex = 22;
            parrotGradientPanel2.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            parrotGradientPanel2.TopLeft = Color.DeepSkyBlue;
            parrotGradientPanel2.TopRight = Color.Fuchsia;
            // 
            // crownTitle8
            // 
            crownTitle8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            crownTitle8.AutoSize = true;
            crownTitle8.Font = new Font("Segoe UI", 16F);
            crownTitle8.Location = new Point(169, 259);
            crownTitle8.Name = "crownTitle8";
            crownTitle8.Size = new Size(77, 30);
            crownTitle8.TabIndex = 21;
            crownTitle8.Text = "File đề";
            // 
            // crownTextBox4
            // 
            crownTextBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            crownTextBox4.BackColor = Color.FromArgb(69, 73, 74);
            crownTextBox4.BorderStyle = BorderStyle.FixedSingle;
            crownTextBox4.ForeColor = Color.FromArgb(220, 220, 220);
            crownTextBox4.Location = new Point(253, 305);
            crownTextBox4.Name = "crownTextBox4";
            crownTextBox4.Size = new Size(100, 23);
            crownTextBox4.TabIndex = 24;
            // 
            // crownTitle9
            // 
            crownTitle9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            crownTitle9.AutoSize = true;
            crownTitle9.Font = new Font("Segoe UI", 9F);
            crownTitle9.Location = new Point(200, 307);
            crownTitle9.Name = "crownTitle9";
            crownTitle9.Size = new Size(47, 15);
            crownTitle9.TabIndex = 23;
            crownTitle9.Text = "Vị trí đề";
            // 
            // crownTextBox5
            // 
            crownTextBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            crownTextBox5.BackColor = Color.FromArgb(69, 73, 74);
            crownTextBox5.BorderStyle = BorderStyle.FixedSingle;
            crownTextBox5.ForeColor = Color.FromArgb(220, 220, 220);
            crownTextBox5.Location = new Point(253, 334);
            crownTextBox5.Name = "crownTextBox5";
            crownTextBox5.Size = new Size(100, 23);
            crownTextBox5.TabIndex = 26;
            // 
            // crownTitle10
            // 
            crownTitle10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            crownTitle10.AutoSize = true;
            crownTitle10.Font = new Font("Segoe UI", 9F);
            crownTitle10.Location = new Point(185, 336);
            crownTitle10.Name = "crownTitle10";
            crownTitle10.Size = new Size(62, 15);
            crownTitle10.TabIndex = 25;
            crownTitle10.Text = "Đề hợp lệ?";
            // 
            // crownButton3
            // 
            crownButton3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            crownButton3.Location = new Point(691, 299);
            crownButton3.Name = "crownButton3";
            crownButton3.Padding = new Padding(5, 5, 5, 5);
            crownButton3.Size = new Size(75, 23);
            crownButton3.TabIndex = 29;
            crownButton3.Text = "Chọn đề";
            // 
            // crownButton1
            // 
            crownButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            crownButton1.Location = new Point(682, 332);
            crownButton1.Name = "crownButton1";
            crownButton1.Padding = new Padding(5, 5, 5, 5);
            crownButton1.Size = new Size(84, 23);
            crownButton1.TabIndex = 30;
            crownButton1.Text = "Lưu thay đổi";
            // 
            // crownButton2
            // 
            crownButton2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            crownButton2.Location = new Point(592, 332);
            crownButton2.Name = "crownButton2";
            crownButton2.Padding = new Padding(5, 5, 5, 5);
            crownButton2.Size = new Size(84, 23);
            crownButton2.TabIndex = 31;
            crownButton2.Text = "Xóa đề thi";
            // 
            // QuanLyDeThiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 419);
            Controls.Add(crownButton2);
            Controls.Add(crownButton1);
            Controls.Add(crownButton3);
            Controls.Add(crownTextBox5);
            Controls.Add(crownTitle10);
            Controls.Add(crownTextBox4);
            Controls.Add(crownTitle9);
            Controls.Add(parrotGradientPanel2);
            Controls.Add(crownTitle8);
            Controls.Add(crownTitle7);
            Controls.Add(crownDropDownList1);
            Controls.Add(dateTimePicker2);
            Controls.Add(crownTitle6);
            Controls.Add(dateTimePicker1);
            Controls.Add(crownTitle5);
            Controls.Add(crownTextBox3);
            Controls.Add(crownTitle4);
            Controls.Add(crownTextBox2);
            Controls.Add(crownTitle3);
            Controls.Add(crownTextBox1);
            Controls.Add(crownTitle2);
            Controls.Add(parrotGradientPanel1);
            Controls.Add(crownTitle1);
            Controls.Add(dockPanel);
            Controls.Add(splitter1);
            Controls.Add(examTreeView);
            Controls.Add(statusStrip);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimumSize = new Size(800, 419);
            Name = "QuanLyDeThiForm";
            Text = "Quản lý đề thi";
            Load += QuanLyDeThiForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripStatusLabel statusLabel;
        private ToolStripProgressBar stripProgressBar;
        private ReaLTaiizor.Controls.CrownStatusStrip statusStrip;
        private ReaLTaiizor.Docking.Crown.CrownDockPanel dockPanel;
        private ReaLTaiizor.Controls.CrownTreeView examTreeView;
        private Splitter splitter1;
        private ReaLTaiizor.Controls.CrownTitle crownTitle1;
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel1;
        private ReaLTaiizor.Controls.CrownTitle crownTitle2;
        private ReaLTaiizor.Controls.CrownTextBox crownTextBox1;
        private ReaLTaiizor.Controls.CrownTextBox crownTextBox2;
        private ReaLTaiizor.Controls.CrownTitle crownTitle3;
        private ReaLTaiizor.Controls.CrownTextBox crownTextBox3;
        private ReaLTaiizor.Controls.CrownTitle crownTitle4;
        private ReaLTaiizor.Controls.CrownTitle crownTitle5;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private ReaLTaiizor.Controls.CrownTitle crownTitle6;
        private ReaLTaiizor.Controls.CrownDropDownList crownDropDownList1;
        private ReaLTaiizor.Controls.CrownTitle crownTitle7;
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel2;
        private ReaLTaiizor.Controls.CrownTitle crownTitle8;
        private ReaLTaiizor.Controls.CrownTextBox crownTextBox4;
        private ReaLTaiizor.Controls.CrownTitle crownTitle9;
        private ReaLTaiizor.Controls.CrownTextBox crownTextBox5;
        private ReaLTaiizor.Controls.CrownTitle crownTitle10;
        private ReaLTaiizor.Controls.CrownButton crownButton3;
        private ReaLTaiizor.Controls.CrownButton crownButton1;
        private ReaLTaiizor.Controls.CrownButton crownButton2;
    }
}