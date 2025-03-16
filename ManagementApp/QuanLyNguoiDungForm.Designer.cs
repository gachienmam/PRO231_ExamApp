namespace ManagementApp
{
    partial class QuanLyNguoiDungForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            radioButtonGV = new RadioButton();
            radioButtonAdmin = new RadioButton();
            textBoxMaND = new TextBox();
            textBoxMKND = new TextBox();
            textBoxHoTenND = new TextBox();
            textBoxEmailND = new TextBox();
            adioButtonGridviewND = new DataGridView();
            textBoxTimKiem = new TextBox();
            buttonTimKiem = new Button();
            buttonThemND = new Button();
            buttonSuaND = new Button();
            buttonXoaND = new Button();
            buttonThoat = new Button();
            buttonDanhSachND = new Button();
            buttonLuuND = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)adioButtonGridviewND).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F);
            label1.Location = new Point(77, 131);
            label1.Name = "label1";
            label1.Size = new Size(42, 22);
            label1.TabIndex = 0;
            label1.Text = "Quản lý người dùng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 256);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 1;
            label2.Text = "Vai trò:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F);
            label3.Location = new Point(77, 192);
            label3.Name = "label3";
            label3.Size = new Size(92, 22);
            label3.TabIndex = 2;
            label3.Text = "Họ và tên:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F);
            label4.Location = new Point(504, 131);
            label4.Name = "label4";
            label4.Size = new Size(63, 22);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(315, 32);
            label5.Name = "label5";
            label5.Size = new Size(309, 38);
            label5.TabIndex = 4;
            label5.Text = "Quản lý người dùng";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F);
            label6.Location = new Point(504, 192);
            label6.Name = "label6";
            label6.Size = new Size(88, 22);
            label6.TabIndex = 5;
            label6.Text = "Mật khẩu:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonGV);
            groupBox1.Controls.Add(radioButtonAdmin);
            groupBox1.Location = new Point(133, 231);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(216, 64);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // radioButtonGV
            // 
            radioButtonGV.AutoSize = true;
            radioButtonGV.Location = new Point(106, 24);
            radioButtonGV.Margin = new Padding(3, 4, 3, 4);
            radioButtonGV.Name = "radioButtonGV";
            radioButtonGV.Size = new Size(92, 24);
            radioButtonGV.TabIndex = 7;
            radioButtonGV.TabStop = true;
            radioButtonGV.Text = "Giáo viên";
            radioButtonGV.UseVisualStyleBackColor = true;
            radioButtonGV.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButtonAdmin
            // 
            radioButtonAdmin.AutoSize = true;
            radioButtonAdmin.Location = new Point(7, 24);
            radioButtonAdmin.Margin = new Padding(3, 4, 3, 4);
            radioButtonAdmin.Name = "radioButtonAdmin";
            radioButtonAdmin.Size = new Size(74, 24);
            radioButtonAdmin.TabIndex = 0;
            radioButtonAdmin.TabStop = true;
            radioButtonAdmin.Text = "Admin";
            radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // textBoxMaND
            // 
            textBoxMaND.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxMaND.Location = new Point(121, 127);
            textBoxMaND.Margin = new Padding(3, 4, 3, 4);
            textBoxMaND.Name = "textBoxMaND";
            textBoxMaND.Size = new Size(283, 26);
            textBoxMaND.TabIndex = 7;
            textBoxMaND.TextChanged += textBox1_TextChanged;
            // 
            // textBoxMKND
            // 
            textBoxMKND.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxMKND.Location = new Point(591, 188);
            textBoxMKND.Margin = new Padding(3, 4, 3, 4);
            textBoxMKND.Name = "textBoxMKND";
            textBoxMKND.Size = new Size(239, 26);
            textBoxMKND.TabIndex = 8;
            // 
            // textBoxHoTenND
            // 
            textBoxHoTenND.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxHoTenND.Location = new Point(165, 188);
            textBoxHoTenND.Margin = new Padding(3, 4, 3, 4);
            textBoxHoTenND.Name = "textBoxHoTenND";
            textBoxHoTenND.Size = new Size(239, 26);
            textBoxHoTenND.TabIndex = 9;
            // 
            // textBoxEmailND
            // 
            textBoxEmailND.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmailND.Location = new Point(562, 127);
            textBoxEmailND.Margin = new Padding(3, 4, 3, 4);
            textBoxEmailND.Name = "textBoxEmailND";
            textBoxEmailND.Size = new Size(268, 26);
            textBoxEmailND.TabIndex = 10;
            // 
            // adioButtonGridviewND
            // 
            adioButtonGridviewND.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            adioButtonGridviewND.Location = new Point(3, 303);
            adioButtonGridviewND.Margin = new Padding(3, 4, 3, 4);
            adioButtonGridviewND.Name = "adioButtonGridviewND";
            adioButtonGridviewND.RowHeadersWidth = 51;
            adioButtonGridviewND.Size = new Size(911, 277);
            adioButtonGridviewND.TabIndex = 11;
            // 
            // textBoxTimKiem
            // 
            textBoxTimKiem.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTimKiem.Location = new Point(239, 604);
            textBoxTimKiem.Margin = new Padding(3, 4, 3, 4);
            textBoxTimKiem.Name = "textBoxTimKiem";
            textBoxTimKiem.Size = new Size(283, 26);
            textBoxTimKiem.TabIndex = 12;
            textBoxTimKiem.Text = "Tìm kiếm theo email";
            textBoxTimKiem.TextChanged += textBoxTimKiem_TextChanged;
            // 
            // buttonTimKiem
            // 
            buttonTimKiem.Location = new Point(562, 604);
            buttonTimKiem.Margin = new Padding(3, 4, 3, 4);
            buttonTimKiem.Name = "buttonTimKiem";
            buttonTimKiem.Size = new Size(86, 31);
            buttonTimKiem.TabIndex = 13;
            buttonTimKiem.Text = "Tìm kiếm";
            buttonTimKiem.UseVisualStyleBackColor = true;
            // 
            // buttonThemND
            // 
            buttonThemND.Location = new Point(64, 668);
            buttonThemND.Margin = new Padding(3, 4, 3, 4);
            buttonThemND.Name = "buttonThemND";
            buttonThemND.Size = new Size(94, 67);
            buttonThemND.TabIndex = 14;
            buttonThemND.Text = "Thêm";
            buttonThemND.UseVisualStyleBackColor = true;
            buttonThemND.Click += buttonThemND_Click;
            // 
            // buttonSuaND
            // 
            buttonSuaND.Location = new Point(193, 668);
            buttonSuaND.Margin = new Padding(3, 4, 3, 4);
            buttonSuaND.Name = "buttonSuaND";
            buttonSuaND.Size = new Size(94, 67);
            buttonSuaND.TabIndex = 15;
            buttonSuaND.Text = "Sửa";
            buttonSuaND.UseVisualStyleBackColor = true;
            buttonSuaND.Click += buttonSuaND_Click;
            // 
            // buttonXoaND
            // 
            buttonXoaND.Location = new Point(315, 668);
            buttonXoaND.Margin = new Padding(3, 4, 3, 4);
            buttonXoaND.Name = "buttonXoaND";
            buttonXoaND.Size = new Size(94, 67);
            buttonXoaND.TabIndex = 16;
            buttonXoaND.Text = "Xóa";
            buttonXoaND.UseVisualStyleBackColor = true;
            // 
            // buttonThoat
            // 
            buttonThoat.Location = new Point(776, 668);
            buttonThoat.Margin = new Padding(3, 4, 3, 4);
            buttonThoat.Name = "buttonThoat";
            buttonThoat.Size = new Size(94, 67);
            buttonThoat.TabIndex = 17;
            buttonThoat.Text = "Thoát";
            buttonThoat.UseVisualStyleBackColor = true;
            buttonThoat.Click += buttonThoat_Click;
            // 
            // buttonDanhSachND
            // 
            buttonDanhSachND.Location = new Point(605, 668);
            buttonDanhSachND.Margin = new Padding(3, 4, 3, 4);
            buttonDanhSachND.Name = "buttonDanhSachND";
            buttonDanhSachND.Size = new Size(94, 67);
            buttonDanhSachND.TabIndex = 18;
            buttonDanhSachND.Text = "Danh sách";
            buttonDanhSachND.UseVisualStyleBackColor = true;
            // 
            // buttonLuuND
            // 
            buttonLuuND.Location = new Point(429, 668);
            buttonLuuND.Margin = new Padding(3, 4, 3, 4);
            buttonLuuND.Name = "buttonLuuND";
            buttonLuuND.Size = new Size(94, 67);
            buttonLuuND.TabIndex = 19;
            buttonLuuND.Text = "Lưu";
            buttonLuuND.UseVisualStyleBackColor = true;
            // 
            // QuanLyNguoiDungForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 740);
            Controls.Add(buttonLuuND);
            Controls.Add(buttonDanhSachND);
            Controls.Add(buttonThoat);
            Controls.Add(buttonXoaND);
            Controls.Add(buttonSuaND);
            Controls.Add(buttonThemND);
            Controls.Add(buttonTimKiem);
            Controls.Add(textBoxTimKiem);
            Controls.Add(adioButtonGridviewND);
            Controls.Add(textBoxEmailND);
            Controls.Add(textBoxHoTenND);
            Controls.Add(textBoxMKND);
            Controls.Add(textBoxMaND);
            Controls.Add(groupBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "QuanLyNguoiDungForm";
            Text = "Quản lý người dùng";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)adioButtonGridviewND).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private GroupBox groupBox1;
        private RadioButton radioButtonGV;
        private RadioButton radioButtonAdmin;
        private TextBox textBoxMaND;
        private TextBox textBoxMKND;
        private TextBox textBoxHoTenND;
        private TextBox textBoxEmailND;
        private DataGridView adioButtonGridviewND;
        private TextBox textBoxTimKiem;
        private Button buttonTimKiem;
        private Button buttonThemND;
        private Button buttonSuaND;
        private Button buttonXoaND;
        private Button buttonThoat;
        private Button buttonDanhSachND;
        private Button buttonLuuND;
    }
}