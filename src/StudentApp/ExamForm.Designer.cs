﻿namespace StudentApp
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
            components = new System.ComponentModel.Container();
            examContainerPanel = new ReaLTaiizor.Controls.CrownSectionPanel();
            labelQuestionFontSize = new ReaLTaiizor.Controls.CrownTitle();
            numericQuestionFontSize = new ReaLTaiizor.Controls.CrownNumeric();
            labelInfo = new ReaLTaiizor.Controls.CrownTitle();
            panelQuestionContainer = new Panel();
            panelCauHoiHienTai = new ReaLTaiizor.Controls.CrownSectionPanel();
            textBoxQuestion = new ReaLTaiizor.Controls.CrownTextBox();
            splitterQuestionImage = new Splitter();
            panelQuestionImageContainer = new Panel();
            pictureBoxQuestionImage = new PictureBox();
            panelChonDapAn = new ReaLTaiizor.Controls.CrownSectionPanel();
            checkBoxDapAnD = new ReaLTaiizor.Controls.CrownCheckBox();
            checkBoxDapAnC = new ReaLTaiizor.Controls.CrownCheckBox();
            checkBoxDapAnB = new ReaLTaiizor.Controls.CrownCheckBox();
            checkBoxDapAnA = new ReaLTaiizor.Controls.CrownCheckBox();
            buttonNext = new ReaLTaiizor.Controls.CrownButton();
            panelDanhSachCauHoi = new ReaLTaiizor.Controls.CrownSectionPanel();
            checkBoxConfirmFinish = new ReaLTaiizor.Controls.CrownCheckBox();
            pictureAnhDeThi = new PictureBox();
            crownTitle1 = new ReaLTaiizor.Controls.CrownTitle();
            textBoxServer = new ReaLTaiizor.Controls.CrownTextBox();
            textBoxExamCode = new ReaLTaiizor.Controls.CrownTextBox();
            textBoxStudent = new ReaLTaiizor.Controls.CrownTextBox();
            textBoxTime = new ReaLTaiizor.Controls.CrownTextBox();
            crownTitleServer = new ReaLTaiizor.Controls.CrownTitle();
            crownTitleExamCode = new ReaLTaiizor.Controls.CrownTitle();
            crownTitleStudent = new ReaLTaiizor.Controls.CrownTitle();
            buttonFinish = new ReaLTaiizor.Controls.CrownButton();
            textBoxMachine = new ReaLTaiizor.Controls.CrownTextBox();
            crownTitleMachine = new ReaLTaiizor.Controls.CrownTitle();
            timerExam = new System.Windows.Forms.Timer(components);
            examContainerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericQuestionFontSize).BeginInit();
            panelQuestionContainer.SuspendLayout();
            panelCauHoiHienTai.SuspendLayout();
            panelQuestionImageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQuestionImage).BeginInit();
            panelChonDapAn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureAnhDeThi).BeginInit();
            SuspendLayout();
            // 
            // examContainerPanel
            // 
            examContainerPanel.Controls.Add(labelQuestionFontSize);
            examContainerPanel.Controls.Add(numericQuestionFontSize);
            examContainerPanel.Controls.Add(labelInfo);
            examContainerPanel.Controls.Add(panelQuestionContainer);
            examContainerPanel.Controls.Add(checkBoxConfirmFinish);
            examContainerPanel.Controls.Add(pictureAnhDeThi);
            examContainerPanel.Controls.Add(crownTitle1);
            examContainerPanel.Controls.Add(textBoxServer);
            examContainerPanel.Controls.Add(textBoxExamCode);
            examContainerPanel.Controls.Add(textBoxStudent);
            examContainerPanel.Controls.Add(textBoxTime);
            examContainerPanel.Controls.Add(crownTitleServer);
            examContainerPanel.Controls.Add(crownTitleExamCode);
            examContainerPanel.Controls.Add(crownTitleStudent);
            examContainerPanel.Controls.Add(buttonFinish);
            examContainerPanel.Controls.Add(textBoxMachine);
            examContainerPanel.Controls.Add(crownTitleMachine);
            examContainerPanel.Dock = DockStyle.Fill;
            examContainerPanel.Font = new Font("Segoe UI", 10F);
            examContainerPanel.Location = new Point(0, 0);
            examContainerPanel.Name = "examContainerPanel";
            examContainerPanel.SectionHeader = "PolyTest Exam Client - Hôm nay: 24/3/2025";
            examContainerPanel.Size = new Size(868, 591);
            examContainerPanel.TabIndex = 0;
            // 
            // labelQuestionFontSize
            // 
            labelQuestionFontSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelQuestionFontSize.AutoSize = true;
            labelQuestionFontSize.Location = new Point(756, 204);
            labelQuestionFontSize.Name = "labelQuestionFontSize";
            labelQuestionFontSize.Size = new Size(55, 19);
            labelQuestionFontSize.TabIndex = 65;
            labelQuestionFontSize.Text = "Cỡ chữ:";
            // 
            // numericQuestionFontSize
            // 
            numericQuestionFontSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericQuestionFontSize.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            numericQuestionFontSize.Location = new Point(817, 201);
            numericQuestionFontSize.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numericQuestionFontSize.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            numericQuestionFontSize.Name = "numericQuestionFontSize";
            numericQuestionFontSize.Size = new Size(39, 25);
            numericQuestionFontSize.TabIndex = 64;
            numericQuestionFontSize.Value = new decimal(new int[] { 12, 0, 0, 0 });
            numericQuestionFontSize.ValueChanged += numericQuestionFontSize_ValueChanged;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInfo.Location = new Point(12, 201);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(84, 21);
            labelInfo.TabIndex = 62;
            labelInfo.Text = "Bất đầu thi";
            // 
            // panelQuestionContainer
            // 
            panelQuestionContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelQuestionContainer.Controls.Add(panelCauHoiHienTai);
            panelQuestionContainer.Controls.Add(splitterQuestionImage);
            panelQuestionContainer.Controls.Add(panelQuestionImageContainer);
            panelQuestionContainer.Controls.Add(panelChonDapAn);
            panelQuestionContainer.Controls.Add(panelDanhSachCauHoi);
            panelQuestionContainer.Location = new Point(12, 225);
            panelQuestionContainer.Name = "panelQuestionContainer";
            panelQuestionContainer.Size = new Size(844, 325);
            panelQuestionContainer.TabIndex = 20;
            // 
            // panelCauHoiHienTai
            // 
            panelCauHoiHienTai.AutoScroll = true;
            panelCauHoiHienTai.Controls.Add(textBoxQuestion);
            panelCauHoiHienTai.Dock = DockStyle.Fill;
            panelCauHoiHienTai.Font = new Font("Segoe UI", 9F);
            panelCauHoiHienTai.Location = new Point(119, 0);
            panelCauHoiHienTai.MinimumSize = new Size(75, 0);
            panelCauHoiHienTai.Name = "panelCauHoiHienTai";
            panelCauHoiHienTai.SectionHeader = "Câu hỏi (1/20)";
            panelCauHoiHienTai.Size = new Size(400, 244);
            panelCauHoiHienTai.TabIndex = 68;
            // 
            // textBoxQuestion
            // 
            textBoxQuestion.BackColor = Color.FromArgb(69, 73, 74);
            textBoxQuestion.BorderStyle = BorderStyle.None;
            textBoxQuestion.Cursor = Cursors.Cross;
            textBoxQuestion.Dock = DockStyle.Fill;
            textBoxQuestion.Font = new Font("Segoe UI", 12F);
            textBoxQuestion.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxQuestion.Location = new Point(1, 25);
            textBoxQuestion.Margin = new Padding(0);
            textBoxQuestion.Multiline = true;
            textBoxQuestion.Name = "textBoxQuestion";
            textBoxQuestion.PlaceholderText = "Câu hỏi trống";
            textBoxQuestion.ReadOnly = true;
            textBoxQuestion.ScrollBars = ScrollBars.Vertical;
            textBoxQuestion.Size = new Size(398, 218);
            textBoxQuestion.TabIndex = 0;
            textBoxQuestion.Text = "(Chọn 1 đáp án)\r\nVăn thành có bình thường không?\r\n\r\nA. Có\r\nB. Không\r\nC. No\r\nD. skibidi dop dop yes yes\r\n";
            // 
            // splitterQuestionImage
            // 
            splitterQuestionImage.Dock = DockStyle.Right;
            splitterQuestionImage.Location = new Point(519, 0);
            splitterQuestionImage.MinExtra = 75;
            splitterQuestionImage.MinSize = 75;
            splitterQuestionImage.Name = "splitterQuestionImage";
            splitterQuestionImage.Size = new Size(3, 244);
            splitterQuestionImage.TabIndex = 63;
            splitterQuestionImage.TabStop = false;
            // 
            // panelQuestionImageContainer
            // 
            panelQuestionImageContainer.Controls.Add(pictureBoxQuestionImage);
            panelQuestionImageContainer.Dock = DockStyle.Right;
            panelQuestionImageContainer.Location = new Point(522, 0);
            panelQuestionImageContainer.Name = "panelQuestionImageContainer";
            panelQuestionImageContainer.Size = new Size(322, 244);
            panelQuestionImageContainer.TabIndex = 70;
            // 
            // pictureBoxQuestionImage
            // 
            pictureBoxQuestionImage.Dock = DockStyle.Fill;
            pictureBoxQuestionImage.Location = new Point(0, 0);
            pictureBoxQuestionImage.Name = "pictureBoxQuestionImage";
            pictureBoxQuestionImage.Size = new Size(322, 244);
            pictureBoxQuestionImage.TabIndex = 63;
            pictureBoxQuestionImage.TabStop = false;
            // 
            // panelChonDapAn
            // 
            panelChonDapAn.Controls.Add(checkBoxDapAnD);
            panelChonDapAn.Controls.Add(checkBoxDapAnC);
            panelChonDapAn.Controls.Add(checkBoxDapAnB);
            panelChonDapAn.Controls.Add(checkBoxDapAnA);
            panelChonDapAn.Controls.Add(buttonNext);
            panelChonDapAn.Dock = DockStyle.Left;
            panelChonDapAn.Font = new Font("Segoe UI", 9F);
            panelChonDapAn.Location = new Point(0, 0);
            panelChonDapAn.Name = "panelChonDapAn";
            panelChonDapAn.SectionHeader = "Đáp án";
            panelChonDapAn.Size = new Size(119, 244);
            panelChonDapAn.TabIndex = 0;
            // 
            // checkBoxDapAnD
            // 
            checkBoxDapAnD.Anchor = AnchorStyles.None;
            checkBoxDapAnD.AutoSize = true;
            checkBoxDapAnD.Font = new Font("Segoe UI", 12F);
            checkBoxDapAnD.Location = new Point(44, 149);
            checkBoxDapAnD.Name = "checkBoxDapAnD";
            checkBoxDapAnD.Size = new Size(40, 25);
            checkBoxDapAnD.TabIndex = 67;
            checkBoxDapAnD.Text = "D";
            // 
            // checkBoxDapAnC
            // 
            checkBoxDapAnC.Anchor = AnchorStyles.None;
            checkBoxDapAnC.AutoSize = true;
            checkBoxDapAnC.Font = new Font("Segoe UI", 12F);
            checkBoxDapAnC.Location = new Point(44, 115);
            checkBoxDapAnC.Name = "checkBoxDapAnC";
            checkBoxDapAnC.Size = new Size(39, 25);
            checkBoxDapAnC.TabIndex = 66;
            checkBoxDapAnC.Text = "C";
            // 
            // checkBoxDapAnB
            // 
            checkBoxDapAnB.Anchor = AnchorStyles.None;
            checkBoxDapAnB.AutoSize = true;
            checkBoxDapAnB.Font = new Font("Segoe UI", 12F);
            checkBoxDapAnB.Location = new Point(44, 80);
            checkBoxDapAnB.Name = "checkBoxDapAnB";
            checkBoxDapAnB.Size = new Size(38, 25);
            checkBoxDapAnB.TabIndex = 65;
            checkBoxDapAnB.Text = "B";
            // 
            // checkBoxDapAnA
            // 
            checkBoxDapAnA.Anchor = AnchorStyles.None;
            checkBoxDapAnA.AutoSize = true;
            checkBoxDapAnA.Font = new Font("Segoe UI", 12F);
            checkBoxDapAnA.Location = new Point(44, 45);
            checkBoxDapAnA.Name = "checkBoxDapAnA";
            checkBoxDapAnA.Size = new Size(39, 25);
            checkBoxDapAnA.TabIndex = 62;
            checkBoxDapAnA.Text = "A";
            // 
            // buttonNext
            // 
            buttonNext.Anchor = AnchorStyles.None;
            buttonNext.Location = new Point(22, 194);
            buttonNext.Name = "buttonNext";
            buttonNext.Padding = new Padding(5);
            buttonNext.Size = new Size(75, 23);
            buttonNext.TabIndex = 63;
            buttonNext.Text = "Next";
            buttonNext.Click += buttonNext_Click;
            // 
            // panelDanhSachCauHoi
            // 
            panelDanhSachCauHoi.AutoScroll = true;
            panelDanhSachCauHoi.Dock = DockStyle.Bottom;
            panelDanhSachCauHoi.Font = new Font("Segoe UI", 9F);
            panelDanhSachCauHoi.Location = new Point(0, 244);
            panelDanhSachCauHoi.Name = "panelDanhSachCauHoi";
            panelDanhSachCauHoi.SectionHeader = "Danh sách câu hỏi";
            panelDanhSachCauHoi.Size = new Size(844, 81);
            panelDanhSachCauHoi.TabIndex = 69;
            panelDanhSachCauHoi.Scroll += panelDanhSachCauHoi_Scroll;
            // 
            // checkBoxConfirmFinish
            // 
            checkBoxConfirmFinish.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBoxConfirmFinish.AutoSize = true;
            checkBoxConfirmFinish.Location = new Point(93, 556);
            checkBoxConfirmFinish.Name = "checkBoxConfirmFinish";
            checkBoxConfirmFinish.Size = new Size(262, 23);
            checkBoxConfirmFinish.TabIndex = 19;
            checkBoxConfirmFinish.Text = "Tôi muốn hoàn thành bài kiểm tra này";
            checkBoxConfirmFinish.CheckedChanged += checkBoxConfirmFinish_CheckedChanged;
            // 
            // pictureAnhDeThi
            // 
            pictureAnhDeThi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureAnhDeThi.Location = new Point(717, 45);
            pictureAnhDeThi.Name = "pictureAnhDeThi";
            pictureAnhDeThi.Size = new Size(128, 128);
            pictureAnhDeThi.SizeMode = PictureBoxSizeMode.Zoom;
            pictureAnhDeThi.TabIndex = 18;
            pictureAnhDeThi.TabStop = false;
            pictureAnhDeThi.Click += pictureAnhDeThi_Click;
            // 
            // crownTitle1
            // 
            crownTitle1.Anchor = AnchorStyles.Top;
            crownTitle1.AutoSize = true;
            crownTitle1.Location = new Point(376, 35);
            crownTitle1.Name = "crownTitle1";
            crownTitle1.Size = new Size(108, 19);
            crownTitle1.TabIndex = 17;
            crownTitle1.Text = "Thời gian còn lại";
            // 
            // textBoxServer
            // 
            textBoxServer.BackColor = Color.FromArgb(69, 73, 74);
            textBoxServer.BorderStyle = BorderStyle.FixedSingle;
            textBoxServer.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxServer.Location = new Point(110, 81);
            textBoxServer.Name = "textBoxServer";
            textBoxServer.ReadOnly = true;
            textBoxServer.Size = new Size(140, 25);
            textBoxServer.TabIndex = 13;
            // 
            // textBoxExamCode
            // 
            textBoxExamCode.BackColor = Color.FromArgb(69, 73, 74);
            textBoxExamCode.BorderStyle = BorderStyle.FixedSingle;
            textBoxExamCode.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxExamCode.Location = new Point(110, 116);
            textBoxExamCode.Name = "textBoxExamCode";
            textBoxExamCode.ReadOnly = true;
            textBoxExamCode.Size = new Size(140, 25);
            textBoxExamCode.TabIndex = 12;
            // 
            // textBoxStudent
            // 
            textBoxStudent.BackColor = Color.FromArgb(69, 73, 74);
            textBoxStudent.BorderStyle = BorderStyle.FixedSingle;
            textBoxStudent.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxStudent.Location = new Point(110, 152);
            textBoxStudent.Name = "textBoxStudent";
            textBoxStudent.ReadOnly = true;
            textBoxStudent.Size = new Size(140, 25);
            textBoxStudent.TabIndex = 11;
            // 
            // textBoxTime
            // 
            textBoxTime.Anchor = AnchorStyles.Top;
            textBoxTime.BackColor = Color.FromArgb(69, 73, 74);
            textBoxTime.BorderStyle = BorderStyle.None;
            textBoxTime.Font = new Font("Segoe UI", 28F);
            textBoxTime.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxTime.Location = new Point(347, 57);
            textBoxTime.Multiline = true;
            textBoxTime.Name = "textBoxTime";
            textBoxTime.ReadOnly = true;
            textBoxTime.Size = new Size(157, 61);
            textBoxTime.TabIndex = 10;
            textBoxTime.Text = "00:00";
            textBoxTime.TextAlign = HorizontalAlignment.Center;
            // 
            // crownTitleServer
            // 
            crownTitleServer.AutoSize = true;
            crownTitleServer.Location = new Point(20, 83);
            crownTitleServer.Name = "crownTitleServer";
            crownTitleServer.Size = new Size(50, 19);
            crownTitleServer.TabIndex = 9;
            crownTitleServer.Text = "Server:";
            // 
            // crownTitleExamCode
            // 
            crownTitleExamCode.AutoSize = true;
            crownTitleExamCode.Location = new Point(20, 118);
            crownTitleExamCode.Name = "crownTitleExamCode";
            crownTitleExamCode.Size = new Size(77, 19);
            crownTitleExamCode.TabIndex = 8;
            crownTitleExamCode.Text = "Exam code:";
            // 
            // crownTitleStudent
            // 
            crownTitleStudent.AutoSize = true;
            crownTitleStudent.Location = new Point(20, 154);
            crownTitleStudent.Name = "crownTitleStudent";
            crownTitleStudent.Size = new Size(60, 19);
            crownTitleStudent.TabIndex = 7;
            crownTitleStudent.Text = "Student:";
            // 
            // buttonFinish
            // 
            buttonFinish.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonFinish.Location = new Point(12, 557);
            buttonFinish.Name = "buttonFinish";
            buttonFinish.Padding = new Padding(5);
            buttonFinish.Size = new Size(75, 23);
            buttonFinish.TabIndex = 3;
            buttonFinish.Text = "Finish";
            buttonFinish.Click += crownButtonFinish_Click;
            // 
            // textBoxMachine
            // 
            textBoxMachine.BackColor = Color.FromArgb(69, 73, 74);
            textBoxMachine.BorderStyle = BorderStyle.FixedSingle;
            textBoxMachine.ForeColor = Color.FromArgb(220, 220, 220);
            textBoxMachine.Location = new Point(110, 45);
            textBoxMachine.Name = "textBoxMachine";
            textBoxMachine.ReadOnly = true;
            textBoxMachine.Size = new Size(140, 25);
            textBoxMachine.TabIndex = 2;
            // 
            // crownTitleMachine
            // 
            crownTitleMachine.AutoSize = true;
            crownTitleMachine.Location = new Point(20, 47);
            crownTitleMachine.Name = "crownTitleMachine";
            crownTitleMachine.Size = new Size(64, 19);
            crownTitleMachine.TabIndex = 1;
            crownTitleMachine.Text = "Machine:";
            // 
            // timerExam
            // 
            timerExam.Interval = 1000;
            timerExam.Tick += timerExam_Tick;
            // 
            // ExamForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(868, 591);
            Controls.Add(examContainerPanel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(800, 419);
            Name = "ExamForm";
            Text = "ExamForm";
            TopMost = true;
            Load += ExamForm_Load;
            examContainerPanel.ResumeLayout(false);
            examContainerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericQuestionFontSize).EndInit();
            panelQuestionContainer.ResumeLayout(false);
            panelCauHoiHienTai.ResumeLayout(false);
            panelCauHoiHienTai.PerformLayout();
            panelQuestionImageContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxQuestionImage).EndInit();
            panelChonDapAn.ResumeLayout(false);
            panelChonDapAn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureAnhDeThi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.CrownSectionPanel examContainerPanel;
        private ReaLTaiizor.Controls.CrownButton crownButton2;
        private ReaLTaiizor.Controls.CrownRadioButton crownRadioButton1;
        private ReaLTaiizor.Controls.CrownButton buttonFinish;
        private ReaLTaiizor.Controls.CrownTextBox textBoxMachine;
        private ReaLTaiizor.Controls.CrownTitle crownTitleMachine;
        private ReaLTaiizor.Controls.CrownTextBox textBoxServer;
        private ReaLTaiizor.Controls.CrownTextBox textBoxExamCode;
        private ReaLTaiizor.Controls.CrownTextBox textBoxStudent;
        private ReaLTaiizor.Controls.CrownTextBox textBoxTime;
        private ReaLTaiizor.Controls.CrownTitle crownTitleServer;
        private ReaLTaiizor.Controls.CrownTitle crownTitleExamCode;
        private ReaLTaiizor.Controls.CrownTitle crownTitleStudent;
        private ReaLTaiizor.Controls.CrownRadioButton crownRadioButton4;
        private ReaLTaiizor.Controls.CrownRadioButton crownRadioButton3;
        private ReaLTaiizor.Controls.CrownSectionPanel panelChonDapAn;
        private PictureBox pictureAnhDeThi;
        private ReaLTaiizor.Controls.CrownTitle crownTitle1;
        private ReaLTaiizor.Controls.CrownCheckBox checkBoxConfirmFinish;
        private Panel panelQuestionContainer;
        private ReaLTaiizor.Controls.CrownSectionPanel panelCauHoiHienTai;
        private ReaLTaiizor.Controls.CrownTitle crownTitle10;
        private ReaLTaiizor.Controls.CrownTitle crownTitle9;
        private ReaLTaiizor.Controls.CrownTitle crownTitle8;
        private ReaLTaiizor.Controls.CrownTitle crownTitle7;
        private ReaLTaiizor.Controls.CrownCheckBox checkBoxDapAnD;
        private ReaLTaiizor.Controls.CrownCheckBox checkBoxDapAnC;
        private ReaLTaiizor.Controls.CrownCheckBox checkBoxDapAnB;
        private ReaLTaiizor.Controls.CrownCheckBox checkBoxDapAnA;
        private ReaLTaiizor.Controls.CrownButton buttonNext;
        private ReaLTaiizor.Controls.CrownSectionPanel panelDanhSachCauHoi;
        private ReaLTaiizor.Controls.CrownTitle labelInfo;
        private System.Windows.Forms.Timer timerExam;
        private ReaLTaiizor.Controls.CrownTitle labelQuestionFontSize;
        private ReaLTaiizor.Controls.CrownNumeric numericQuestionFontSize;
        private Splitter splitterQuestionImage;
        private Panel panelQuestionImageContainer;
        private PictureBox pictureBoxQuestionImage;
        private ReaLTaiizor.Controls.CrownTextBox textBoxQuestion;
    }
}