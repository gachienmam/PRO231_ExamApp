namespace ManagementApp
{
    partial class GioiThieuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GioiThieuForm));
            foreverForm1 = new ReaLTaiizor.Forms.ForeverForm();
            foreverTextBox1 = new ReaLTaiizor.Controls.ForeverTextBox();
            foreverLabel3 = new ReaLTaiizor.Controls.ForeverLabel();
            foreverLabel2 = new ReaLTaiizor.Controls.ForeverLabel();
            foreverClose1 = new ReaLTaiizor.Controls.ForeverClose();
            foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            foreverForm1.SuspendLayout();
            SuspendLayout();
            // 
            // foreverForm1
            // 
            foreverForm1.BackColor = Color.White;
            foreverForm1.BaseColor = Color.FromArgb(60, 70, 73);
            foreverForm1.BorderColor = Color.DodgerBlue;
            foreverForm1.Controls.Add(foreverTextBox1);
            foreverForm1.Controls.Add(foreverLabel3);
            foreverForm1.Controls.Add(foreverLabel2);
            foreverForm1.Controls.Add(foreverClose1);
            foreverForm1.Controls.Add(foreverLabel1);
            foreverForm1.Dock = DockStyle.Fill;
            foreverForm1.Font = new Font("Segoe UI", 12F);
            foreverForm1.ForeverColor = Color.FromArgb(35, 168, 109);
            foreverForm1.HeaderColor = Color.FromArgb(45, 47, 49);
            foreverForm1.HeaderMaximize = false;
            foreverForm1.HeaderTextFont = new Font("Segoe UI", 12F);
            foreverForm1.Image = null;
            foreverForm1.Location = new Point(0, 0);
            foreverForm1.MinimumSize = new Size(210, 50);
            foreverForm1.Name = "foreverForm1";
            foreverForm1.Padding = new Padding(1, 51, 1, 1);
            foreverForm1.Sizable = true;
            foreverForm1.Size = new Size(501, 277);
            foreverForm1.TabIndex = 0;
            foreverForm1.Text = "Giới thiệu PolyTest";
            foreverForm1.TextColor = Color.FromArgb(234, 234, 234);
            foreverForm1.TextLight = Color.SeaGreen;
            // 
            // foreverTextBox1
            // 
            foreverTextBox1.BackColor = Color.Transparent;
            foreverTextBox1.BaseColor = Color.FromArgb(45, 47, 49);
            foreverTextBox1.BorderColor = Color.FromArgb(35, 168, 109);
            foreverTextBox1.FocusOnHover = false;
            foreverTextBox1.ForeColor = Color.FromArgb(192, 192, 192);
            foreverTextBox1.Location = new Point(21, 141);
            foreverTextBox1.MaxLength = 32767;
            foreverTextBox1.Multiline = true;
            foreverTextBox1.Name = "foreverTextBox1";
            foreverTextBox1.ReadOnly = true;
            foreverTextBox1.Size = new Size(454, 109);
            foreverTextBox1.TabIndex = 15;
            foreverTextBox1.Text = resources.GetString("foreverTextBox1.Text");
            foreverTextBox1.TextAlign = HorizontalAlignment.Left;
            foreverTextBox1.UseSystemPasswordChar = false;
            // 
            // foreverLabel3
            // 
            foreverLabel3.AutoSize = true;
            foreverLabel3.BackColor = Color.Transparent;
            foreverLabel3.Font = new Font("Segoe UI Semilight", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            foreverLabel3.ForeColor = Color.LightGray;
            foreverLabel3.Location = new Point(328, 79);
            foreverLabel3.Name = "foreverLabel3";
            foreverLabel3.Size = new Size(60, 13);
            foreverLabel3.TabIndex = 14;
            foreverLabel3.Text = "v23032025";
            // 
            // foreverLabel2
            // 
            foreverLabel2.AutoSize = true;
            foreverLabel2.BackColor = Color.Transparent;
            foreverLabel2.Font = new Font("Segoe UI", 8F);
            foreverLabel2.ForeColor = Color.LightGray;
            foreverLabel2.Location = new Point(21, 107);
            foreverLabel2.Name = "foreverLabel2";
            foreverLabel2.Size = new Size(251, 13);
            foreverLabel2.TabIndex = 13;
            foreverLabel2.Text = "by Pupu và những người bạn (Nhóm 2, SD1802)";
            // 
            // foreverClose1
            // 
            foreverClose1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            foreverClose1.BackColor = Color.White;
            foreverClose1.BaseColor = Color.FromArgb(45, 47, 49);
            foreverClose1.DefaultLocation = true;
            foreverClose1.DownColor = Color.FromArgb(30, 0, 0, 0);
            foreverClose1.Font = new Font("Marlett", 10F);
            foreverClose1.Location = new Point(471, 16);
            foreverClose1.Name = "foreverClose1";
            foreverClose1.OverColor = Color.FromArgb(30, 255, 255, 255);
            foreverClose1.Size = new Size(18, 18);
            foreverClose1.TabIndex = 12;
            foreverClose1.Text = "foreverClose1";
            foreverClose1.TextColor = Color.FromArgb(243, 243, 243);
            // 
            // foreverLabel1
            // 
            foreverLabel1.AutoSize = true;
            foreverLabel1.BackColor = Color.Transparent;
            foreverLabel1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            foreverLabel1.ForeColor = Color.LightGray;
            foreverLabel1.Location = new Point(21, 66);
            foreverLabel1.Name = "foreverLabel1";
            foreverLabel1.Size = new Size(314, 30);
            foreverLabel1.TabIndex = 11;
            foreverLabel1.Text = "PolyTest EOS Management App";
            // 
            // GioiThieuForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(501, 277);
            Controls.Add(foreverForm1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GioiThieuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GioiThieuForm";
            TransparencyKey = Color.Fuchsia;
            foreverForm1.ResumeLayout(false);
            foreverForm1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm foreverForm1;
        private ReaLTaiizor.Controls.ForeverTextBox foreverTextBox1;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel3;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel2;
        private ReaLTaiizor.Controls.ForeverClose foreverClose1;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
    }
}