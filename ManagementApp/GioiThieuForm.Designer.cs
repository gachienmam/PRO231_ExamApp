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
            crownSectionPanel1 = new ReaLTaiizor.Controls.CrownSectionPanel();
            crownTitle4 = new ReaLTaiizor.Controls.CrownTitle();
            crownTitle1 = new ReaLTaiizor.Controls.CrownTitle();
            crownTitle3 = new ReaLTaiizor.Controls.CrownTitle();
            crownTitle2 = new ReaLTaiizor.Controls.CrownTitle();
            crownSectionPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // crownSectionPanel1
            // 
            crownSectionPanel1.Controls.Add(crownTitle4);
            crownSectionPanel1.Controls.Add(crownTitle1);
            crownSectionPanel1.Controls.Add(crownTitle3);
            crownSectionPanel1.Controls.Add(crownTitle2);
            crownSectionPanel1.Dock = DockStyle.Fill;
            crownSectionPanel1.Location = new Point(0, 0);
            crownSectionPanel1.Name = "crownSectionPanel1";
            crownSectionPanel1.SectionHeader = null;
            crownSectionPanel1.Size = new Size(870, 418);
            crownSectionPanel1.TabIndex = 0;
            // 
            // crownTitle4
            // 
            crownTitle4.AutoSize = true;
            crownTitle4.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            crownTitle4.Location = new Point(71, 255);
            crownTitle4.Name = "crownTitle4";
            crownTitle4.Size = new Size(880, 13);
            crownTitle4.TabIndex = 6;
            crownTitle4.Text = "Phần mềm cho phép tạo đề thi, quản lý ngân hàng câu hỏi, tổ chức thi và chấm điểm tự động, giúp giảm tải công việc cho giáo viên và nâng cao trải nghiệm người dùng.";
            // 
            // crownTitle1
            // 
            crownTitle1.AutoSize = true;
            crownTitle1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            crownTitle1.Location = new Point(162, 213);
            crownTitle1.Name = "crownTitle1";
            crownTitle1.Size = new Size(696, 13);
            crownTitle1.TabIndex = 5;
            crownTitle1.Text = "EOS (Exam Online System) là một phần mềm thi trắc nghiệm trực tuyến, giúp tổ chức và quản lý các kỳ thi một cách dễ dàng, hiệu quả. ";
            crownTitle1.Click += crownTitle1_Click_1;
            // 
            // crownTitle3
            // 
            crownTitle3.AutoSize = true;
            crownTitle3.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            crownTitle3.Location = new Point(286, 73);
            crownTitle3.Name = "crownTitle3";
            crownTitle3.Size = new Size(277, 21);
            crownTitle3.TabIndex = 3;
            crownTitle3.Text = "Tên phần mềm: Thi Trắc nghiệm PolyTest";
            // 
            // crownTitle2
            // 
            crownTitle2.AutoSize = true;
            crownTitle2.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            crownTitle2.Location = new Point(262, 127);
            crownTitle2.Name = "crownTitle2";
            crownTitle2.Size = new Size(349, 21);
            crownTitle2.TabIndex = 1;
            crownTitle2.Text = "Nhà phát hành: Pupu chacha và những người bạn";
            // 
            // GioiThieuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 418);
            Controls.Add(crownSectionPanel1);
            MinimumSize = new Size(800, 419);
            Name = "GioiThieuForm";
            Text = "GioiThieuForm";
            crownSectionPanel1.ResumeLayout(false);
            crownSectionPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.CrownSectionPanel crownSectionPanel1;
        private ReaLTaiizor.Controls.CrownTitle crownTitle3;
        private ReaLTaiizor.Controls.CrownTitle crownTitle2;
        private ReaLTaiizor.Controls.CrownTitle crownTitle1;
        private ReaLTaiizor.Controls.CrownTitle crownTitle4;
    }
}