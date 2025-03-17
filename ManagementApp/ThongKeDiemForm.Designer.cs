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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-1, -1);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(802, 236);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(116, 266);
            button1.Name = "button1";
            button1.Size = new Size(132, 30);
            button1.TabIndex = 1;
            button1.Text = "Tìm kiếm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(116, 361);
            button2.Name = "button2";
            button2.Size = new Size(132, 45);
            button2.TabIndex = 2;
            button2.Text = "Xem danh sách";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(309, 271);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Tìm kiếm theo mã thí sinh";
            textBox1.Size = new Size(305, 23);
            textBox1.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(322, 361);
            button3.Name = "button3";
            button3.Size = new Size(132, 45);
            button3.TabIndex = 6;
            button3.Text = "Xuất danh sách";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(514, 361);
            button4.Name = "button4";
            button4.Size = new Size(91, 45);
            button4.TabIndex = 7;
            button4.Text = "Thoát";
            button4.UseVisualStyleBackColor = true;
            // 
            // ThongKeDiemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "ThongKeDiemForm";
            Text = "Thống kê báo cáo điểm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Button button3;
        private Button button4;
    }
}