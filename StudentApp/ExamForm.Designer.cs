namespace StudentApp
{
    partial class ExamForm
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
            Button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            SuspendLayout();
            // 
            // Button1
            // 
            Button1.Location = new Point(91, 354);
            Button1.Name = "Button1";
            Button1.Size = new Size(75, 23);
            Button1.TabIndex = 1;
            Button1.Text = "Finish";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(630, 354);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Exit ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 75);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 3;
            label1.Text = "Machine";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 118);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 4;
            label2.Text = "Sever";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(91, 163);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 5;
            label3.Text = "Exam Code";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(91, 216);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 6;
            label4.Text = "Student";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(228, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(228, 110);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(228, 155);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(228, 208);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 10;
            // 
            // ExamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 397);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(Button1);
            Name = "ExamForm";
            Text = "ExamForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
    }
}