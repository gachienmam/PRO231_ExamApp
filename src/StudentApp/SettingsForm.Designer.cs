namespace StudentApp
{
    partial class SettingsForm
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
            crownGroupBox1 = new ReaLTaiizor.Controls.CrownGroupBox();
            radioDarkTheme = new ReaLTaiizor.Controls.CrownRadioButton();
            radioLightTheme = new ReaLTaiizor.Controls.CrownRadioButton();
            crownTitle1 = new ReaLTaiizor.Controls.CrownTitle();
            parrotGradientPanel1 = new ReaLTaiizor.Controls.ParrotGradientPanel();
            btnSaveSettings = new ReaLTaiizor.Controls.CrownButton();
            crownGroupBox2 = new ReaLTaiizor.Controls.CrownGroupBox();
            buttonChangeIP = new ReaLTaiizor.Controls.CrownButton();
            textBoxServerAddress = new ReaLTaiizor.Controls.CrownTextBox();
            crownGroupBox1.SuspendLayout();
            crownGroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // crownGroupBox1
            // 
            crownGroupBox1.BorderColor = Color.FromArgb(51, 51, 51);
            crownGroupBox1.Controls.Add(radioDarkTheme);
            crownGroupBox1.Controls.Add(radioLightTheme);
            crownGroupBox1.Location = new Point(12, 52);
            crownGroupBox1.Name = "crownGroupBox1";
            crownGroupBox1.Size = new Size(234, 77);
            crownGroupBox1.TabIndex = 0;
            crownGroupBox1.TabStop = false;
            crownGroupBox1.Text = "Giao diện";
            // 
            // radioDarkTheme
            // 
            radioDarkTheme.AutoSize = true;
            radioDarkTheme.Location = new Point(72, 43);
            radioDarkTheme.Name = "radioDarkTheme";
            radioDarkTheme.Size = new Size(80, 19);
            radioDarkTheme.TabIndex = 1;
            radioDarkTheme.TabStop = true;
            radioDarkTheme.Text = "Chế độ tối";
            // 
            // radioLightTheme
            // 
            radioLightTheme.AutoSize = true;
            radioLightTheme.Location = new Point(72, 22);
            radioLightTheme.Name = "radioLightTheme";
            radioLightTheme.Size = new Size(91, 19);
            radioLightTheme.TabIndex = 0;
            radioLightTheme.TabStop = true;
            radioLightTheme.Text = "Chế độ sáng";
            radioLightTheme.CheckedChanged += radioLightTheme_CheckedChanged;
            // 
            // crownTitle1
            // 
            crownTitle1.AutoSize = true;
            crownTitle1.Font = new Font("Segoe UI", 16F);
            crownTitle1.Location = new Point(12, 9);
            crownTitle1.Name = "crownTitle1";
            crownTitle1.Size = new Size(80, 30);
            crownTitle1.TabIndex = 1;
            crownTitle1.Text = "Cài đặt";
            // 
            // parrotGradientPanel1
            // 
            parrotGradientPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            parrotGradientPanel1.BottomLeft = Color.Black;
            parrotGradientPanel1.BottomRight = Color.Fuchsia;
            parrotGradientPanel1.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            parrotGradientPanel1.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            parrotGradientPanel1.Location = new Point(98, 23);
            parrotGradientPanel1.Name = "parrotGradientPanel1";
            parrotGradientPanel1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotGradientPanel1.PrimerColor = Color.White;
            parrotGradientPanel1.Size = new Size(150, 4);
            parrotGradientPanel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            parrotGradientPanel1.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Corners;
            parrotGradientPanel1.TabIndex = 103;
            parrotGradientPanel1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            parrotGradientPanel1.TopLeft = Color.DeepSkyBlue;
            parrotGradientPanel1.TopRight = Color.Fuchsia;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveSettings.Location = new Point(171, 194);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Padding = new Padding(5);
            btnSaveSettings.Size = new Size(75, 23);
            btnSaveSettings.TabIndex = 104;
            btnSaveSettings.Text = "Lưu";
            btnSaveSettings.Click += buttonSaveSettings_Click;
            // 
            // crownGroupBox2
            // 
            crownGroupBox2.BorderColor = Color.FromArgb(51, 51, 51);
            crownGroupBox2.Controls.Add(buttonChangeIP);
            crownGroupBox2.Controls.Add(textBoxServerAddress);
            crownGroupBox2.Location = new Point(12, 135);
            crownGroupBox2.Name = "crownGroupBox2";
            crownGroupBox2.Size = new Size(234, 53);
            crownGroupBox2.TabIndex = 105;
            crownGroupBox2.TabStop = false;
            crownGroupBox2.Text = "Địa chỉ Server";
            // 
            // buttonChangeIP
            // 
            buttonChangeIP.Location = new Point(176, 22);
            buttonChangeIP.Name = "buttonChangeIP";
            buttonChangeIP.Padding = new Padding(5);
            buttonChangeIP.Size = new Size(52, 23);
            buttonChangeIP.TabIndex = 107;
            buttonChangeIP.Text = "Đổi";
            buttonChangeIP.Click += buttonChangeIP_Click;
            // 
            // textBoxServerAddress
            // 
            textBoxServerAddress.BackColor = Color.FromArgb(69, 73, 74);
            textBoxServerAddress.BorderStyle = BorderStyle.FixedSingle;
            textBoxServerAddress.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxServerAddress.Location = new Point(6, 22);
            textBoxServerAddress.Name = "textBoxServerAddress";
            textBoxServerAddress.PlaceholderText = "IP";
            textBoxServerAddress.Size = new Size(164, 23);
            textBoxServerAddress.TabIndex = 106;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(258, 229);
            Controls.Add(crownGroupBox2);
            Controls.Add(btnSaveSettings);
            Controls.Add(parrotGradientPanel1);
            Controls.Add(crownTitle1);
            Controls.Add(crownGroupBox1);
            Name = "SettingsForm";
            Text = "Cài đặt PolyTest";
            Load += SettingsForm_Load;
            crownGroupBox1.ResumeLayout(false);
            crownGroupBox1.PerformLayout();
            crownGroupBox2.ResumeLayout(false);
            crownGroupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.CrownGroupBox crownGroupBox1;
        private ReaLTaiizor.Controls.CrownTitle crownTitle1;
        private ReaLTaiizor.Controls.CrownRadioButton radioLightTheme;
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel1;
        private ReaLTaiizor.Controls.CrownRadioButton radioDarkTheme;
        private ReaLTaiizor.Controls.CrownButton btnSaveSettings;
        private ReaLTaiizor.Controls.CrownGroupBox crownGroupBox2;
        private ReaLTaiizor.Controls.CrownButton buttonChangeIP;
        private ReaLTaiizor.Controls.CrownTextBox textBoxServerAddress;
    }
}