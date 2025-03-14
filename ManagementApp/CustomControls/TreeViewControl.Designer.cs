namespace ManagementApp.CustomControls
{
    partial class TreeViewControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeView = new ReaLTaiizor.Controls.CrownTreeView();
            SuspendLayout();
            // 
            // TreeView
            // 
            TreeView.Dock = DockStyle.Fill;
            TreeView.Location = new Point(0, 25);
            TreeView.MaxDragChange = 20;
            TreeView.Name = "TreeView";
            TreeView.ShowIcons = true;
            TreeView.Size = new Size(275, 472);
            TreeView.TabIndex = 0;
            TreeView.Text = "TreeView";
            // 
            // TreeViewControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(TreeView);
            DockText = "Danh sách đề";
            Icon = Properties.Resources.Collection_16xLG;
            Name = "TreeViewControl";
            Size = new Size(275, 497);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.CrownTreeView TreeView;
    }
}
