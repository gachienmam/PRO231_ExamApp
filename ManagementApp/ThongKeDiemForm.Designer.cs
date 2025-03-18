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
            dataGridViewTKD = new DataGridView();
            buttonTimKiem = new Button();
            BUTTON_XEMDS = new Button();
            textBoxTimKiem = new TextBox();
            BUTTON_XUATDS = new Button();
            BUTTON_THOAT = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTKD).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTKD
            // 
            dataGridViewTKD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTKD.Location = new Point(-1, -1);
            dataGridViewTKD.Name = "dataGridViewTKD";
            dataGridViewTKD.Size = new Size(802, 236);
            dataGridViewTKD.TabIndex = 0;
            // 
            // buttonTimKiem
            // 
            buttonTimKiem.Location = new Point(116, 266);
            buttonTimKiem.Name = "buttonTimKiem";
            buttonTimKiem.Size = new Size(132, 30);
            buttonTimKiem.TabIndex = 1;
            buttonTimKiem.Text = "Tìm kiếm";
            buttonTimKiem.UseVisualStyleBackColor = true;
            buttonTimKiem.Click += button1_Click;
            // 
            // BUTTON_XEMDS
            // 
            BUTTON_XEMDS.Location = new Point(116, 361);
            BUTTON_XEMDS.Name = "BUTTON_XEMDS";
            BUTTON_XEMDS.Size = new Size(132, 45);
            BUTTON_XEMDS.TabIndex = 2;
            BUTTON_XEMDS.Text = "Xem danh sách";
            BUTTON_XEMDS.UseVisualStyleBackColor = true;
            // 
            // textBoxTimKiem
            // 
            textBoxTimKiem.Location = new Point(309, 271);
            textBoxTimKiem.Name = "textBoxTimKiem";
            textBoxTimKiem.PlaceholderText = "Tìm kiếm theo mã thí sinh";
            textBoxTimKiem.Size = new Size(305, 23);
            textBoxTimKiem.TabIndex = 5;
            // 
            // BUTTON_XUATDS
            // 
            BUTTON_XUATDS.Location = new Point(322, 361);
            BUTTON_XUATDS.Name = "BUTTON_XUATDS";
            BUTTON_XUATDS.Size = new Size(132, 45);
            BUTTON_XUATDS.TabIndex = 6;
            BUTTON_XUATDS.Text = "Xuất danh sách";
            BUTTON_XUATDS.UseVisualStyleBackColor = true;
            // 
            // BUTTON_THOAT
            // 
            BUTTON_THOAT.Location = new Point(514, 361);
            BUTTON_THOAT.Name = "BUTTON_THOAT";
            BUTTON_THOAT.Size = new Size(91, 45);
            BUTTON_THOAT.TabIndex = 7;
            BUTTON_THOAT.Text = "Thoát";
            BUTTON_THOAT.UseVisualStyleBackColor = true;
            // 
            // ThongKeDiemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BUTTON_THOAT);
            Controls.Add(BUTTON_XUATDS);
            Controls.Add(textBoxTimKiem);
            Controls.Add(BUTTON_XEMDS);
            Controls.Add(buttonTimKiem);
            Controls.Add(dataGridViewTKD);
            Name = "ThongKeDiemForm";
            Text = "Thống kê báo cáo điểm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTKD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTKD;
        private Button buttonTimKiem;
        private Button BUTTON_XEMDS;
        private TextBox textBoxTimKiem;
        private Button BUTTON_XUATDS;
        private Button BUTTON_THOAT;
    }
}