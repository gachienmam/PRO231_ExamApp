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
            examTreeView = new ReaLTaiizor.Controls.CrownTreeView();
            DockPanel = new ReaLTaiizor.Docking.Crown.CrownDockPanel();
            splitter1 = new Splitter();
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
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel, stripProgressBar });
            statusStrip.Location = new Point(0, 424);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(0, 5, 0, 3);
            statusStrip.Size = new Size(800, 26);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip";
            // 
            // examTreeView
            // 
            examTreeView.Dock = DockStyle.Left;
            examTreeView.Location = new Point(0, 0);
            examTreeView.MaxDragChange = 20;
            examTreeView.MinimumSize = new Size(140, 0);
            examTreeView.Name = "examTreeView";
            examTreeView.Size = new Size(140, 424);
            examTreeView.TabIndex = 3;
            examTreeView.Text = "crownTreeView1";
            // 
            // DockPanel
            // 
            DockPanel.BackColor = Color.FromArgb(60, 63, 65);
            DockPanel.Dock = DockStyle.Fill;
            DockPanel.Location = new Point(140, 0);
            DockPanel.Name = "DockPanel";
            DockPanel.Size = new Size(660, 424);
            DockPanel.TabIndex = 4;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(140, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 424);
            splitter1.TabIndex = 5;
            splitter1.TabStop = false;
            // 
            // QuanLyDeThiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitter1);
            Controls.Add(DockPanel);
            Controls.Add(examTreeView);
            Controls.Add(statusStrip);
            FormBorderStyle = FormBorderStyle.None;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "QuanLyDeThiForm";
            Text = "QuanLyDeThiForm";
            WindowState = FormWindowState.Maximized;
            Load += QuanLyDeThiForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripStatusLabel statusLabel;
        private ToolStripProgressBar stripProgressBar;
        private ReaLTaiizor.Controls.CrownStatusStrip statusStrip;
        private ReaLTaiizor.Controls.CrownTreeView examTreeView;
        private ReaLTaiizor.Docking.Crown.CrownDockPanel DockPanel;
        private Splitter splitter1;
    }
}