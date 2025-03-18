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
            crownSectionPanel1 = new ReaLTaiizor.Controls.CrownSectionPanel();
            crownTitleMachine = new ReaLTaiizor.Controls.CrownTitle();
            crttonFisnisMachine = new ReaLTaiizor.Controls.CrownTextBox();
            crownButtonFisnish = new ReaLTaiizor.Controls.CrownButton();
            this.crownRadioButtonA = new ReaLTaiizor.Controls.CrownRadioButton();
            crownTitleStuden = new ReaLTaiizor.Controls.CrownTitle();
            crownTitleExamCode = new ReaLTaiizor.Controls.CrownTitle();
            crownTitleServer = new ReaLTaiizor.Controls.CrownTitle();
            crownTextBoxTime = new ReaLTaiizor.Controls.CrownTextBox();
            crownTextBoxStuden = new ReaLTaiizor.Controls.CrownTextBox();
            crownTextBoxExamcode = new ReaLTaiizor.Controls.CrownTextBox();
            crownTextBoxServer = new ReaLTaiizor.Controls.CrownTextBox();
            crownTextBoxImage = new ReaLTaiizor.Controls.CrownTextBox();
            crownGroupBoxCauHoi = new ReaLTaiizor.Controls.CrownGroupBox();
            crownTitle2 = new ReaLTaiizor.Controls.CrownTitle();
            crownRadioButtonD = new ReaLTaiizor.Controls.CrownRadioButton();
            this.crownRadioButtonB = new ReaLTaiizor.Controls.CrownRadioButton();
            this.crownRadioButtonC = new ReaLTaiizor.Controls.CrownRadioButton();
            crownTitle6 = new ReaLTaiizor.Controls.CrownTitle();
            crownTitle7 = new ReaLTaiizor.Controls.CrownTitle();
            crownTitle8 = new ReaLTaiizor.Controls.CrownTitle();
            crownTitle9 = new ReaLTaiizor.Controls.CrownTitle();
            crownTitle10 = new ReaLTaiizor.Controls.CrownTitle();
            crownButtonNext = new ReaLTaiizor.Controls.CrownButton();
            crownSectionPanel1.SuspendLayout();
            crownGroupBoxCauHoi.SuspendLayout();
            SuspendLayout();
            // 
            // crownSectionPanel1
            // 
            crownSectionPanel1.Controls.Add(crownGroupBoxCauHoi);
            crownSectionPanel1.Controls.Add(crownTextBoxImage);
            crownSectionPanel1.Controls.Add(crownTextBoxServer);
            crownSectionPanel1.Controls.Add(crownTextBoxExamcode);
            crownSectionPanel1.Controls.Add(crownTextBoxStuden);
            crownSectionPanel1.Controls.Add(crownTextBoxTime);
            crownSectionPanel1.Controls.Add(crownTitleServer);
            crownSectionPanel1.Controls.Add(crownTitleExamCode);
            crownSectionPanel1.Controls.Add(crownTitleStuden);
            crownSectionPanel1.Controls.Add(crownButtonFisnish);
            crownSectionPanel1.Controls.Add(crttonFisnisMachine);
            crownSectionPanel1.Controls.Add(crownTitleMachine);
            crownSectionPanel1.Dock = DockStyle.Fill;
            crownSectionPanel1.Location = new Point(0, 0);
            crownSectionPanel1.Name = "crownSectionPanel1";
            crownSectionPanel1.SectionHeader = null;
            crownSectionPanel1.Size = new Size(868, 522);
            crownSectionPanel1.TabIndex = 0;
            // 
            // crownTitleMachine
            // 
            crownTitleMachine.AutoSize = true;
            crownTitleMachine.Location = new Point(29, 51);
            crownTitleMachine.Name = "crownTitleMachine";
            crownTitleMachine.Size = new Size(56, 15);
            crownTitleMachine.TabIndex = 1;
            crownTitleMachine.Text = "Machine:";
            crownTitleMachine.Click += crownTitle1_Click;
            // 
            // crttonFisnisMachine
            // 
            crttonFisnisMachine.BackColor = Color.FromArgb(69, 73, 74);
            crttonFisnisMachine.BorderStyle = BorderStyle.FixedSingle;
            crttonFisnisMachine.ForeColor = Color.FromArgb(220, 220, 220);
            crttonFisnisMachine.Location = new Point(119, 49);
            crttonFisnisMachine.Name = "crttonFisnisMachine";
            crttonFisnisMachine.Size = new Size(140, 23);
            crttonFisnisMachine.TabIndex = 2;
            // 
            // crownButtonFisnish
            // 
            crownButtonFisnish.Location = new Point(12, 490);
            crownButtonFisnish.Name = "crownButtonFisnish";
            crownButtonFisnish.Padding = new Padding(5);
            crownButtonFisnish.Size = new Size(75, 23);
            crownButtonFisnish.TabIndex = 3;
            crownButtonFisnish.Text = "Fisnish";
            // 
            // crownRadioButtonA
            // 
            this.crownRadioButtonA.AutoSize = true;
            this.crownRadioButtonA.Location = new Point(30, 58);
            this.crownRadioButtonA.Name = "crownRadioButtonA";
            this.crownRadioButtonA.Size = new Size(33, 19);
            this.crownRadioButtonA.TabIndex = 4;
            this.crownRadioButtonA.TabStop = true;
            this.crownRadioButtonA.Text = "A";
            // 
            // crownTitleStuden
            // 
            crownTitleStuden.AutoSize = true;
            crownTitleStuden.Location = new Point(29, 164);
            crownTitleStuden.Name = "crownTitleStuden";
            crownTitleStuden.Size = new Size(47, 15);
            crownTitleStuden.TabIndex = 7;
            crownTitleStuden.Text = "Studen:";
            // 
            // crownTitleExamCode
            // 
            crownTitleExamCode.AutoSize = true;
            crownTitleExamCode.Location = new Point(29, 126);
            crownTitleExamCode.Name = "crownTitleExamCode";
            crownTitleExamCode.Size = new Size(67, 15);
            crownTitleExamCode.TabIndex = 8;
            crownTitleExamCode.Text = "Exam code:";
            // 
            // crownTitleServer
            // 
            crownTitleServer.AutoSize = true;
            crownTitleServer.Location = new Point(29, 85);
            crownTitleServer.Name = "crownTitleServer";
            crownTitleServer.Size = new Size(42, 15);
            crownTitleServer.TabIndex = 9;
            crownTitleServer.Text = "Server:";
            // 
            // crownTextBoxTime
            // 
            crownTextBoxTime.BackColor = Color.FromArgb(69, 73, 74);
            crownTextBoxTime.BorderStyle = BorderStyle.FixedSingle;
            crownTextBoxTime.ForeColor = Color.FromArgb(220, 220, 220);
            crownTextBoxTime.Location = new Point(425, 49);
            crownTextBoxTime.Multiline = true;
            crownTextBoxTime.Name = "crownTextBoxTime";
            crownTextBoxTime.Size = new Size(137, 59);
            crownTextBoxTime.TabIndex = 10;
            // 
            // crownTextBoxStuden
            // 
            crownTextBoxStuden.BackColor = Color.FromArgb(69, 73, 74);
            crownTextBoxStuden.BorderStyle = BorderStyle.FixedSingle;
            crownTextBoxStuden.ForeColor = Color.FromArgb(220, 220, 220);
            crownTextBoxStuden.Location = new Point(119, 162);
            crownTextBoxStuden.Name = "crownTextBoxStuden";
            crownTextBoxStuden.Size = new Size(140, 23);
            crownTextBoxStuden.TabIndex = 11;
            // 
            // crownTextBoxExamcode
            // 
            crownTextBoxExamcode.BackColor = Color.FromArgb(69, 73, 74);
            crownTextBoxExamcode.BorderStyle = BorderStyle.FixedSingle;
            crownTextBoxExamcode.ForeColor = Color.FromArgb(220, 220, 220);
            crownTextBoxExamcode.Location = new Point(119, 124);
            crownTextBoxExamcode.Name = "crownTextBoxExamcode";
            crownTextBoxExamcode.Size = new Size(140, 23);
            crownTextBoxExamcode.TabIndex = 12;
            // 
            // crownTextBoxServer
            // 
            crownTextBoxServer.BackColor = Color.FromArgb(69, 73, 74);
            crownTextBoxServer.BorderStyle = BorderStyle.FixedSingle;
            crownTextBoxServer.ForeColor = Color.FromArgb(220, 220, 220);
            crownTextBoxServer.Location = new Point(119, 85);
            crownTextBoxServer.Name = "crownTextBoxServer";
            crownTextBoxServer.Size = new Size(140, 23);
            crownTextBoxServer.TabIndex = 13;
            // 
            // crownTextBoxImage
            // 
            crownTextBoxImage.BackColor = Color.FromArgb(69, 73, 74);
            crownTextBoxImage.BorderStyle = BorderStyle.FixedSingle;
            crownTextBoxImage.ForeColor = Color.FromArgb(220, 220, 220);
            crownTextBoxImage.Location = new Point(678, 49);
            crownTextBoxImage.Multiline = true;
            crownTextBoxImage.Name = "crownTextBoxImage";
            crownTextBoxImage.Size = new Size(178, 117);
            crownTextBoxImage.TabIndex = 14;
            // 
            // crownGroupBoxCauHoi
            // 
            crownGroupBoxCauHoi.BorderColor = Color.FromArgb(51, 51, 51);
            crownGroupBoxCauHoi.Controls.Add(crownButtonNext);
            crownGroupBoxCauHoi.Controls.Add(crownTitle10);
            crownGroupBoxCauHoi.Controls.Add(crownTitle9);
            crownGroupBoxCauHoi.Controls.Add(crownTitle8);
            crownGroupBoxCauHoi.Controls.Add(crownTitle7);
            crownGroupBoxCauHoi.Controls.Add(crownTitle6);
            crownGroupBoxCauHoi.Controls.Add(this.crownRadioButtonC);
            crownGroupBoxCauHoi.Controls.Add(this.crownRadioButtonB);
            crownGroupBoxCauHoi.Controls.Add(crownRadioButtonD);
            crownGroupBoxCauHoi.Controls.Add(crownTitle2);
            crownGroupBoxCauHoi.Controls.Add(this.crownRadioButtonA);
            crownGroupBoxCauHoi.Location = new Point(29, 222);
            crownGroupBoxCauHoi.Name = "crownGroupBoxCauHoi";
            crownGroupBoxCauHoi.Size = new Size(827, 241);
            crownGroupBoxCauHoi.TabIndex = 15;
            crownGroupBoxCauHoi.TabStop = false;
            // 
            // crownTitle2
            // 
            crownTitle2.AutoSize = true;
            crownTitle2.Location = new Point(30, 19);
            crownTitle2.Name = "crownTitle2";
            crownTitle2.Size = new Size(46, 15);
            crownTitle2.TabIndex = 16;
            crownTitle2.Text = "Answer";
            // 
            // crownRadioButtonD
            // 
            crownRadioButtonD.AutoSize = true;
            crownRadioButtonD.Location = new Point(30, 162);
            crownRadioButtonD.Name = "crownRadioButtonD";
            crownRadioButtonD.Size = new Size(33, 19);
            crownRadioButtonD.TabIndex = 17;
            crownRadioButtonD.TabStop = true;
            crownRadioButtonD.Text = "D";
            crownRadioButtonD.UseMnemonic = false;
            // 
            // crownRadioButtonB
            // 
            this.crownRadioButtonB.AutoSize = true;
            this.crownRadioButtonB.Location = new Point(30, 93);
            this.crownRadioButtonB.Name = "crownRadioButtonB";
            this.crownRadioButtonB.Size = new Size(32, 19);
            this.crownRadioButtonB.TabIndex = 18;
            this.crownRadioButtonB.TabStop = true;
            this.crownRadioButtonB.Text = "B";
            // 
            // crownRadioButtonC
            // 
            this.crownRadioButtonC.AutoSize = true;
            this.crownRadioButtonC.Location = new Point(30, 128);
            this.crownRadioButtonC.Name = "crownRadioButtonC";
            this.crownRadioButtonC.Size = new Size(33, 19);
            this.crownRadioButtonC.TabIndex = 19;
            this.crownRadioButtonC.TabStop = true;
            this.crownRadioButtonC.Text = "C";
            // 
            // crownTitle6
            // 
            crownTitle6.AutoSize = true;
            crownTitle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            crownTitle6.Location = new Point(107, 14);
            crownTitle6.Name = "crownTitle6";
            crownTitle6.Size = new Size(236, 21);
            crownTitle6.TabIndex = 20;
            crownTitle6.Text = "Văn thành có bình tường không?";
            // 
            // crownTitle7
            // 
            crownTitle7.AutoSize = true;
            crownTitle7.Location = new Point(75, 60);
            crownTitle7.Name = "crownTitle7";
            crownTitle7.Size = new Size(73, 15);
            crownTitle7.TabIndex = 21;
            crownTitle7.Text = "Bình thường";
            // 
            // crownTitle8
            // 
            crownTitle8.AutoSize = true;
            crownTitle8.Location = new Point(75, 93);
            crownTitle8.Name = "crownTitle8";
            crownTitle8.Size = new Size(111, 15);
            crownTitle8.TabIndex = 22;
            crownTitle8.Text = "Không bình thường";
            // 
            // crownTitle9
            // 
            crownTitle9.AutoSize = true;
            crownTitle9.Location = new Point(75, 130);
            crownTitle9.Name = "crownTitle9";
            crownTitle9.Size = new Size(84, 15);
            crownTitle9.TabIndex = 23;
            crownTitle9.Text = "Cái gì đó thứ 3";
            // 
            // crownTitle10
            // 
            crownTitle10.AutoSize = true;
            crownTitle10.Location = new Point(75, 160);
            crownTitle10.Name = "crownTitle10";
            crownTitle10.Size = new Size(42, 15);
            crownTitle10.TabIndex = 24;
            crownTitle10.Text = "Khùng";
            // 
            // crownButtonNext
            // 
            crownButtonNext.Location = new Point(30, 196);
            crownButtonNext.Name = "crownButtonNext";
            crownButtonNext.Padding = new Padding(5);
            crownButtonNext.Size = new Size(75, 23);
            crownButtonNext.TabIndex = 16;
            crownButtonNext.Text = "Next";
            // 
            // ExamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 522);
            Controls.Add(crownSectionPanel1);
            MinimumSize = new Size(800, 419);
            Name = "ExamForm";
            Text = "ExamForm";
            crownSectionPanel1.ResumeLayout(false);
            crownSectionPanel1.PerformLayout();
            crownGroupBoxCauHoi.ResumeLayout(false);
            crownGroupBoxCauHoi.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.CrownSectionPanel crownSectionPanel1;
        private ReaLTaiizor.Controls.CrownButton crownButton2;
        private ReaLTaiizor.Controls.CrownRadioButton crownRadioButton1;
        private ReaLTaiizor.Controls.CrownButton crownButtonFisnish;
        private ReaLTaiizor.Controls.CrownTextBox crttonFisnisMachine;
        private ReaLTaiizor.Controls.CrownTitle crownTitleMachine;
        private ReaLTaiizor.Controls.CrownGroupBox crownGroupBoxCauHoi;
        private ReaLTaiizor.Controls.CrownTextBox crownTextBoxImage;
        private ReaLTaiizor.Controls.CrownTextBox crownTextBoxServer;
        private ReaLTaiizor.Controls.CrownTextBox crownTextBoxExamcode;
        private ReaLTaiizor.Controls.CrownTextBox crownTextBoxStuden;
        private ReaLTaiizor.Controls.CrownTextBox crownTextBoxTime;
        private ReaLTaiizor.Controls.CrownTitle crownTitleServer;
        private ReaLTaiizor.Controls.CrownTitle crownTitleExamCode;
        private ReaLTaiizor.Controls.CrownTitle crownTitleStuden;
        private ReaLTaiizor.Controls.CrownTitle crownTitle10;
        private ReaLTaiizor.Controls.CrownTitle crownTitle9;
        private ReaLTaiizor.Controls.CrownTitle crownTitle8;
        private ReaLTaiizor.Controls.CrownTitle crownTitle7;
        private ReaLTaiizor.Controls.CrownTitle crownTitle6;
        private ReaLTaiizor.Controls.CrownRadioButton crownRadioButton4;
        private ReaLTaiizor.Controls.CrownRadioButton crownRadioButton3;
        private ReaLTaiizor.Controls.CrownRadioButton crownRadioButtonD;
        private ReaLTaiizor.Controls.CrownTitle crownTitle2;
        private ReaLTaiizor.Controls.CrownButton crownButtonNext;
    }
}