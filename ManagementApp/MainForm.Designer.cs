namespace ManagementApp
{
    partial class MainForm
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
            mainMenuStrip = new ReaLTaiizor.Controls.CrownMenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            đăngNhậpToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            thoátToolStripMenuItem = new ToolStripMenuItem();
            quảnLýToolStripMenuItem = new ToolStripMenuItem();
            đềThiToolStripMenuItem = new ToolStripMenuItem();
            thíSinhToolStripMenuItem = new ToolStripMenuItem();
            ngườiDùngToolStripMenuItem = new ToolStripMenuItem();
            thốngKêToolStripMenuItem = new ToolStripMenuItem();
            điểmTheoThíSinhToolStripMenuItem = new ToolStripMenuItem();
            giớiThiệuToolStripMenuItem = new ToolStripMenuItem();
            vềPolyTestToolStripMenuItem = new ToolStripMenuItem();
            xemHướngDẫnToolStripMenuItem = new ToolStripMenuItem();
            usernameToolStripMenuItem = new ToolStripMenuItem();
            thôngTinCủaTôiToolStripMenuItem = new ToolStripMenuItem();
            themeToggleToolStripMenuItem = new ToolStripMenuItem();
            formView = new Panel();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.BackColor = Color.FromArgb(60, 63, 65);
            mainMenuStrip.ForeColor = Color.FromArgb(220, 220, 220);
            mainMenuStrip.ImageScalingSize = new Size(28, 28);
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, quảnLýToolStripMenuItem, thốngKêToolStripMenuItem, giớiThiệuToolStripMenuItem, usernameToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Margin = new Padding(0, 4, 0, 4);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new Padding(4, 6, 4, 6);
            mainMenuStrip.Size = new Size(804, 35);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "crownMenuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đăngNhậpToolStripMenuItem, đăngXuấtToolStripMenuItem, thoátToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Padding = new Padding(4, 2, 2, 0);
            fileToolStripMenuItem.Size = new Size(67, 23);
            fileToolStripMenuItem.Text = "&Hệ thống";
            // 
            // đăngNhậpToolStripMenuItem
            // 
            đăngNhậpToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            đăngNhậpToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            đăngNhậpToolStripMenuItem.Name = "đăngNhậpToolStripMenuItem";
            đăngNhậpToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            đăngNhậpToolStripMenuItem.Size = new Size(172, 22);
            đăngNhậpToolStripMenuItem.Text = "Đăng nhập";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            đăngXuấtToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            đăngXuấtToolStripMenuItem.Size = new Size(172, 22);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // thoátToolStripMenuItem
            // 
            thoátToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            thoátToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            thoátToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            thoátToolStripMenuItem.Size = new Size(172, 22);
            thoátToolStripMenuItem.Text = "Thoát";
            // 
            // quảnLýToolStripMenuItem
            // 
            quảnLýToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            quảnLýToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đềThiToolStripMenuItem, thíSinhToolStripMenuItem, ngườiDùngToolStripMenuItem });
            quảnLýToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            quảnLýToolStripMenuItem.Padding = new Padding(4, 2, 4, 2);
            quảnLýToolStripMenuItem.Size = new Size(60, 23);
            quảnLýToolStripMenuItem.Text = "&Quản lý";
            // 
            // đềThiToolStripMenuItem
            // 
            đềThiToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            đềThiToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            đềThiToolStripMenuItem.Image = Properties.Resources.Collection_16xLG;
            đềThiToolStripMenuItem.Name = "đềThiToolStripMenuItem";
            đềThiToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.D;
            đềThiToolStripMenuItem.Size = new Size(213, 22);
            đềThiToolStripMenuItem.Text = "Đề thi";
            đềThiToolStripMenuItem.Click += đềThiToolStripMenuItem_Click;
            // 
            // thíSinhToolStripMenuItem
            // 
            thíSinhToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            thíSinhToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            thíSinhToolStripMenuItem.Image = Properties.Resources.RefactoringLog_12810;
            thíSinhToolStripMenuItem.Name = "thíSinhToolStripMenuItem";
            thíSinhToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.T;
            thíSinhToolStripMenuItem.Size = new Size(213, 22);
            thíSinhToolStripMenuItem.Text = "Thí sinh";
            thíSinhToolStripMenuItem.Click += thíSinhToolStripMenuItem_Click;
            // 
            // ngườiDùngToolStripMenuItem
            // 
            ngườiDùngToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            ngườiDùngToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            ngườiDùngToolStripMenuItem.Image = Properties.Resources.properties_16xLG;
            ngườiDùngToolStripMenuItem.Name = "ngườiDùngToolStripMenuItem";
            ngườiDùngToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.N;
            ngườiDùngToolStripMenuItem.Size = new Size(213, 22);
            ngườiDùngToolStripMenuItem.Text = "Người dùng";
            ngườiDùngToolStripMenuItem.Click += ngườiDùngToolStripMenuItem_Click;
            // 
            // thốngKêToolStripMenuItem
            // 
            thốngKêToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            thốngKêToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { điểmTheoThíSinhToolStripMenuItem });
            thốngKêToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            thốngKêToolStripMenuItem.Padding = new Padding(4, 2, 4, 2);
            thốngKêToolStripMenuItem.Size = new Size(68, 23);
            thốngKêToolStripMenuItem.Text = "&Thống kê";
            // 
            // điểmTheoThíSinhToolStripMenuItem
            // 
            điểmTheoThíSinhToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            điểmTheoThíSinhToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            điểmTheoThíSinhToolStripMenuItem.Image = Properties.Resources.document_16xLG;
            điểmTheoThíSinhToolStripMenuItem.Name = "điểmTheoThíSinhToolStripMenuItem";
            điểmTheoThíSinhToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.P;
            điểmTheoThíSinhToolStripMenuItem.Size = new Size(247, 34);
            điểmTheoThíSinhToolStripMenuItem.Text = "Điểm theo thí sinh";
            điểmTheoThíSinhToolStripMenuItem.Click += điểmTheoThíSinhToolStripMenuItem_Click;
            // 
            // giớiThiệuToolStripMenuItem
            // 
            giớiThiệuToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            giớiThiệuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { vềPolyTestToolStripMenuItem, xemHướngDẫnToolStripMenuItem });
            giớiThiệuToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            giớiThiệuToolStripMenuItem.Name = "giớiThiệuToolStripMenuItem";
            giớiThiệuToolStripMenuItem.Padding = new Padding(4, 2, 4, 2);
            giớiThiệuToolStripMenuItem.Size = new Size(70, 23);
            giớiThiệuToolStripMenuItem.Text = "&Giới thiệu";
            // 
            // vềPolyTestToolStripMenuItem
            // 
            vềPolyTestToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            vềPolyTestToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            vềPolyTestToolStripMenuItem.Name = "vềPolyTestToolStripMenuItem";
            vềPolyTestToolStripMenuItem.Size = new Size(159, 22);
            vềPolyTestToolStripMenuItem.Text = "Về PolyTest";
            // 
            // xemHướngDẫnToolStripMenuItem
            // 
            xemHướngDẫnToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            xemHướngDẫnToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            xemHướngDẫnToolStripMenuItem.Name = "xemHướngDẫnToolStripMenuItem";
            xemHướngDẫnToolStripMenuItem.Size = new Size(159, 22);
            xemHướngDẫnToolStripMenuItem.Text = "Xem hướng dẫn";
            // 
            // usernameToolStripMenuItem
            // 
            usernameToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            usernameToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            usernameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTinCủaTôiToolStripMenuItem, themeToggleToolStripMenuItem });
            usernameToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            usernameToolStripMenuItem.Name = "usernameToolStripMenuItem";
            usernameToolStripMenuItem.Padding = new Padding(4, 2, 4, 2);
            usernameToolStripMenuItem.RightToLeft = RightToLeft.No;
            usernameToolStripMenuItem.Size = new Size(202, 23);
            usernameToolStripMenuItem.Text = "Xin chào, Vũ Thiên Trường (admin)";
            usernameToolStripMenuItem.TextDirection = ToolStripTextDirection.Horizontal;
            // 
            // thôngTinCủaTôiToolStripMenuItem
            // 
            thôngTinCủaTôiToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            thôngTinCủaTôiToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            thôngTinCủaTôiToolStripMenuItem.Name = "thôngTinCủaTôiToolStripMenuItem";
            thôngTinCủaTôiToolStripMenuItem.Size = new Size(180, 22);
            thôngTinCủaTôiToolStripMenuItem.Text = "Thông tin của tôi";
            // 
            // themeToggleToolStripMenuItem
            // 
            themeToggleToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
            themeToggleToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            themeToggleToolStripMenuItem.Name = "themeToggleToolStripMenuItem";
            themeToggleToolStripMenuItem.Size = new Size(180, 22);
            themeToggleToolStripMenuItem.Text = "Chế độ tối";
            themeToggleToolStripMenuItem.Click += themeToggleToolStripMenuItem_Click;
            // 
            // formView
            // 
            formView.Dock = DockStyle.Fill;
            formView.Location = new Point(0, 35);
            formView.MinimumSize = new Size(800, 419);
            formView.Name = "formView";
            formView.Size = new Size(804, 427);
            formView.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 462);
            Controls.Add(formView);
            Controls.Add(mainMenuStrip);
            DoubleBuffered = true;
            MainMenuStrip = mainMenuStrip;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimumSize = new Size(820, 501);
            Name = "MainForm";
            Text = "PolyTest Manager";
            Load += MainForm_Load;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.CrownMenuStrip mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem đăngNhậpToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private ToolStripMenuItem quảnLýToolStripMenuItem;
        private ToolStripMenuItem thốngKêToolStripMenuItem;
        private ToolStripMenuItem giớiThiệuToolStripMenuItem;
        private ToolStripMenuItem usernameToolStripMenuItem;
        private ToolStripMenuItem thôngTinCủaTôiToolStripMenuItem;
        private ToolStripMenuItem đềThiToolStripMenuItem;
        private ToolStripMenuItem thíSinhToolStripMenuItem;
        private ToolStripMenuItem ngườiDùngToolStripMenuItem;
        private ToolStripMenuItem vềPolyTestToolStripMenuItem;
        private ToolStripMenuItem xemHướngDẫnToolStripMenuItem;
        private ToolStripMenuItem điểmTheoThíSinhToolStripMenuItem;
        private ToolStripMenuItem themeToggleToolStripMenuItem;
        private Panel formView;
    }
}
