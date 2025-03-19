namespace ManagementApp
{
    partial class ThongKeDiemForm
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
            crownSectionPanel1 = new ReaLTaiizor.Controls.CrownSectionPanel();
            dataGridViewTKD = new DataGridView();
            buttonTimKiem = new ReaLTaiizor.Controls.CrownButton();
            textBoxTimKiem = new ReaLTaiizor.Controls.CrownTextBox();
            BUTTON_XEMDS = new ReaLTaiizor.Controls.CrownButton();
            BUTTON_XUATDS = new ReaLTaiizor.Controls.CrownButton();
            BUTTON_THOAT = new ReaLTaiizor.Controls.CrownButton();
            crownSectionPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTKD).BeginInit();
            SuspendLayout();
            // 
            // crownSectionPanel1
            // 
            crownSectionPanel1.Controls.Add(BUTTON_THOAT);
            crownSectionPanel1.Controls.Add(BUTTON_XUATDS);
            crownSectionPanel1.Controls.Add(BUTTON_XEMDS);
            crownSectionPanel1.Controls.Add(textBoxTimKiem);
            crownSectionPanel1.Controls.Add(buttonTimKiem);
            crownSectionPanel1.Controls.Add(dataGridViewTKD);
            crownSectionPanel1.Dock = DockStyle.Fill;
            crownSectionPanel1.Location = new Point(0, 0);
            crownSectionPanel1.Name = "crownSectionPanel1";
            crownSectionPanel1.SectionHeader = null;
            crownSectionPanel1.Size = new Size(800, 450);
            crownSectionPanel1.TabIndex = 0;
            // 
            // dataGridViewTKD
            // 
            dataGridViewTKD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTKD.Location = new Point(0, 0);
            dataGridViewTKD.Name = "dataGridViewTKD";
            dataGridViewTKD.Size = new Size(802, 236);
            dataGridViewTKD.TabIndex = 8;
            // 
            // buttonTimKiem
            // 
            buttonTimKiem.Location = new Point(117, 267);
            buttonTimKiem.Name = "buttonTimKiem";
            buttonTimKiem.Padding = new Padding(5);
            buttonTimKiem.Size = new Size(132, 29);
            buttonTimKiem.TabIndex = 14;
            buttonTimKiem.Text = "Tìm kiếm";
            // 
            // textBoxTimKiem
            // 
            textBoxTimKiem.BackColor = Color.FromArgb(69, 73, 74);
            textBoxTimKiem.BorderStyle = BorderStyle.FixedSingle;
            textBoxTimKiem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTimKiem.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxTimKiem.Location = new Point(297, 267);
            textBoxTimKiem.Multiline = true;
            textBoxTimKiem.Name = "textBoxTimKiem";
            textBoxTimKiem.PlaceholderText = "Tìm kiếm theo mã thí sinh";
            textBoxTimKiem.Size = new Size(240, 29);
            textBoxTimKiem.TabIndex = 15;
            // 
            // BUTTON_XEMDS
            // 
            BUTTON_XEMDS.Location = new Point(117, 362);
            BUTTON_XEMDS.Name = "BUTTON_XEMDS";
            BUTTON_XEMDS.Padding = new Padding(5);
            BUTTON_XEMDS.Size = new Size(132, 45);
            BUTTON_XEMDS.TabIndex = 16;
            BUTTON_XEMDS.Text = "Xem danh sách";
            // 
            // BUTTON_XUATDS
            // 
            BUTTON_XUATDS.Location = new Point(297, 362);
            BUTTON_XUATDS.Name = "BUTTON_XUATDS";
            BUTTON_XUATDS.Padding = new Padding(5);
            BUTTON_XUATDS.Size = new Size(132, 45);
            BUTTON_XUATDS.TabIndex = 17;
            BUTTON_XUATDS.Text = "Xuất danh sách";
            // 
            // BUTTON_THOAT
            // 
            BUTTON_THOAT.Location = new Point(535, 362);
            BUTTON_THOAT.Name = "BUTTON_THOAT";
            BUTTON_THOAT.Padding = new Padding(5);
            BUTTON_THOAT.Size = new Size(91, 45);
            BUTTON_THOAT.TabIndex = 18;
            BUTTON_THOAT.Text = "Thoát";
            // 
            // ThongKeDiemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(crownSectionPanel1);
            Name = "ThongKeDiemForm";
            Text = "Thống kê báo cáo điểm";
            crownSectionPanel1.ResumeLayout(false);
            crownSectionPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTKD).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.CrownSectionPanel crownSectionPanel1;
        private ReaLTaiizor.Controls.CrownTextBox textBoxTimKiem;
        private ReaLTaiizor.Controls.CrownButton buttonTimKiem;
        private Button BUTTON_THOAT;
        private DataGridView dataGridViewTKD;
        
        private ReaLTaiizor.Controls.CrownButton BUTTON_XUATDS;
        private ReaLTaiizor.Controls.CrownButton BUTTON_XEMDS;
    }
}