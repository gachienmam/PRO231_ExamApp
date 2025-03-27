using ExamLibrary.Question;
using ExamLibrary.Question.Types;
using ExamLibrary.Remote;
using StudentApp.ExamProto;
using Google.Protobuf;
using ProtoBuf;
using ReaLTaiizor.Controls;
using StudentApp.ExamProto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing.Text;
using System.Runtime.ConstrainedExecution;
using static ReaLTaiizor.Helper.CrownHelper;

namespace StudentApp
{
    public partial class ExamForm : Form
    {
        #region Constructor
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        // Dữ liệu thi
        private ExamData _data;
        private Paper _examPaper;
        private ServerInformation _serverInfo;

        // Dữ liệu nộp thi
        private SubmitPaper _submitPaper;

        // Kết nối máy chủ ExamServer
        private readonly ExamService.ExamServiceClient _client;
        private readonly Grpc.Core.Metadata _headers;

        // Kiểm tra người dùng đã hoàn thành bài thi hay chưa (cho nút Finish)
        private bool _userFinishedExam;

        // Thời gian còn lại
        private int _timeLeft;

        // Câu hỏi hiện tại đếm từ 1 (MultipleChoice)
        private int _multipleChoice_currentQuestion;

        public ExamForm(ExamData data, Paper paper)
        {
            InitializeComponent();

            // MONKE Anticheat: Giấu cửa sổ thi khỏi phần mềm quay fim
            ExamForm.SetWindowDisplayAffinity(base.Handle, 1U);
            _data = data;

            // Deserialize ServerInformation
            //using (var memoryStream = new MemoryStream(data.ServerInformation.ToByteArray()))
            //{
            //    try
            //    {
            //        _serverInfo = Serializer.Deserialize<ServerInformation>(memoryStream);
            //    }
            //    catch (Exception ex)
            //    {
            //        CrownMessageBox.ShowError($"Lỗi khi xử lý dữ liệu thông tin máy chủ: {ex.Message}", "Lỗi hệ thống", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
            //        Application.Exit();
            //    }
            //}
            //using (var memoryStream = new MemoryStream(data.ExamPaper.ToByteArray()))
            //{
            //    try
            //    {
            //        _examPaper = Serializer.Deserialize<ExamLibrary.Question.>(memoryStream);
            //    }
            //    catch (Exception ex)
            //    {
            //        CrownMessageBox.ShowError($"Lỗi khi xử lý dữ liệu thi: {ex.Message}", "Lỗi hệ thống", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
            //        Application.Exit();
            //    }
            //}
            _examPaper = paper;

            _submitPaper = new SubmitPaper();

            _submitPaper.SubmissionPaper = paper;

            _submitPaper.SubmissionPaper.MultipleChoiceQuestions = new List<MultipleChoice>();

            _submitPaper.SubmissionPaper.MultipleChoiceQuestions = _examPaper.MultipleChoiceQuestions;
            foreach (var question in _submitPaper.SubmissionPaper.MultipleChoiceQuestions)
            {
                if (question != null)
                {
                    question.QuestionAnswers = new List<string>();
                }
            }

            if (_examPaper != null && _examPaper.MultipleChoiceQuestions != null)
            {

            }
            else
            {
                Console.WriteLine("Lỗi khi nhập đáp án.");
            }

            _timeLeft = _examPaper.Duration;
        }

        public ExamForm(ExamService.ExamServiceClient client, Grpc.Core.Metadata headers, ExamData data)
        {
            InitializeComponent();

            // MONKE Anticheat: Giấu cửa sổ thi khỏi phần mềm quay fim
            ExamForm.SetWindowDisplayAffinity(base.Handle, 1U);

            _client = client;
            _headers = headers;
            _data = data;

            // Deserialize ServerInformation
            using (var memoryStream = new MemoryStream(data.ServerInformation.ToByteArray()))
            {
                try
                {
                    _serverInfo = Serializer.Deserialize<ServerInformation>(memoryStream);
                }
                catch (Exception ex)
                {
                    CrownMessageBox.ShowError($"Lỗi khi xử lý dữ liệu thông tin máy chủ: {ex.Message}", "Lỗi hệ thống", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    //Application.Exit();
                }
            }
            using (var memoryStream = new MemoryStream(data.ExamPaper.ToByteArray()))
            {
                try
                {
                    _examPaper = Serializer.Deserialize<Paper>(memoryStream);
                }
                catch (Exception ex)
                {
                    CrownMessageBox.ShowError($"Lỗi khi xử lý dữ liệu thi: {ex.Message}", "Lỗi hệ thống", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    //Application.Exit();
                }
            }

            _submitPaper = new SubmitPaper();

            _submitPaper.SubmissionPaper.MultipleChoiceQuestions = _examPaper.MultipleChoiceQuestions.Select(q => new MultipleChoice
            {
                QuestionID = q.QuestionID,
                QuestionAnswers = new List<string>() // Để trống đáp án
            }).ToList();

            _timeLeft = _examPaper.Duration;
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            if (_data == null)
            {
                CrownMessageBox.ShowError($"Lỗi khi xử lý dữ liệu thi.", "Lỗi hệ thống", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                Application.Exit();
            }

            // Load Server Info
            textBoxMachine.Text = Environment.MachineName;
            //textBoxServer.Text = _serverInfo.ServerName;
            textBoxServer.Text = "ggMrBit";
            textBoxExamCode.Text = _examPaper.ExamCode;
            textBoxStudent.Text = Environment.MachineName;
            //pictureAnhDeThi.Image = ByteArrayToImage(_examPaper.ExamImage);

            // Fullscreen
            //EnterFullScreenMode(this);

            // Load đề thi
            //timerExam.Start();
            AddQuestionButtonsToPanel(_examPaper.NoOfQuestion);
            DisplayMultipleChoice(0);
        }
        #endregion

        #region Control Action Events
        private void checkBoxConfirmFinish_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxConfirmFinish.Checked)
            {
                buttonFinish.Enabled = true;
            }
            else
            {
                buttonFinish.Enabled = false;
            }
        }

        private void crownButtonFinish_Click(object sender, EventArgs e)
        {
            if (_userFinishedExam)
            {
                Application.Exit();
            }
            else
            {
                DialogResult result = CrownMessageBox.ShowInformation("Bạn có chắc chắn muốn hoàn thành bài thi?", "Xác nhận", ReaLTaiizor.Enum.Crown.DialogButton.YesNo);
                if (result == DialogResult.Yes)
                {
                    panel1.Hide();
                    LeaveFullScreenMode(this);
                    _userFinishedExam = true;
                }
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            _multipleChoice_currentQuestion += 1;
            if (_multipleChoice_currentQuestion > _examPaper.MultipleChoiceQuestions.Count)
            {
                _multipleChoice_currentQuestion = 1;
            }
            SaveAnswerToSubmissionPaper(_multipleChoice_currentQuestion - 1);
            UpdateAnsweredQuestionButtons();
            DisplayMultipleChoice(_multipleChoice_currentQuestion - 1);
        }

        private void questionButton_Click(object sender, EventArgs e)
        {
            CrownButton button = (CrownButton)sender;
            int num = Convert.ToInt32(button.Text);
            _multipleChoice_currentQuestion = num;
            SaveAnswerToSubmissionPaper(_multipleChoice_currentQuestion - 1);
            UpdateAnsweredQuestionButtons();
            DisplayMultipleChoice(_multipleChoice_currentQuestion - 1);
        }
        #endregion

        #region Function
        private void SaveAnswerToSubmissionPaper(int questionIndex)
        {
            var currentQuestionSubmitPaper = _submitPaper.SubmissionPaper.MultipleChoiceQuestions.Where(q => q.QuestionID == questionIndex + 1).FirstOrDefault();
            if (currentQuestionSubmitPaper != null)
            {
                List<string> answers = new List<string>();
                if (checkBoxDapAnA.Checked == true)
                {
                    answers.Add("A");
                }
                if (checkBoxDapAnB.Checked == true)
                {
                    answers.Add("B");
                }
                if (checkBoxDapAnC.Checked == true)
                {
                    answers.Add("C");
                }
                if (checkBoxDapAnD.Checked == true)
                {
                    answers.Add("D");
                }
                currentQuestionSubmitPaper.QuestionAnswers = answers;
            }
        }

        private void UpdateAnsweredQuestionButtons()
        {
            for (int i = 1; i < _submitPaper.SubmissionPaper.MultipleChoiceQuestions.Count; i++)
            {
                Color color;
                if (_submitPaper.SubmissionPaper.MultipleChoiceQuestions[i].QuestionAnswers.Count > 0)
                {
                    color = Color.Lime;
                }
                else
                {
                    color = ThemeProvider.Theme.Colors.GreyBackground;
                }
                foreach (object obj in this.panelDanhSachCauHoi.Controls)
                {
                    CrownButton button = (CrownButton)obj;
                    int num = Convert.ToInt32(button.Text);
                    if (i == num)
                    {
                        button.BackColor = color;
                    }
                }
            }
        }

        private Image ByteArrayToImage(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void AddQuestionButtonsToPanel(int n)
        {
            // Vị trí ban đầu của nút
            int x_pos = 0;
            int y_pos = 10;
            for (int i = 1; i <= n; i++)
            {
                CrownButton button = new CrownButton();
                button.Name = "buttonQuestion" + i;
                button.Text = i.ToString();
                button.Width = 30;
                button.Height = 20;
                button.Left = button.Width * x_pos;
                button.Top = y_pos;
                x_pos++;
                bool flag = button.Left + button.Width >= this.panelDanhSachCauHoi.Width - button.Width;
                if (flag)
                {
                    x_pos = 0;
                    button.Left = button.Width * x_pos;
                    y_pos = y_pos + button.Height + 5;
                    button.Top = y_pos;
                    x_pos++;
                }
                this.panelDanhSachCauHoi.Controls.Add(button);
                button.Visible = true;
                button.Click += questionButton_Click;
            }
        }

        private void DisplayMultipleChoice(int questionOrder)
        {
            var currentQuestionExam = _examPaper.MultipleChoiceQuestions[questionOrder];
            var currentQuestionSubmitPaper = _submitPaper.SubmissionPaper.MultipleChoiceQuestions[questionOrder];
            panelCauHoiHienTai.SectionHeader = $"Câu hỏi ({questionOrder}/{_examPaper.MultipleChoiceQuestions.Count})";
            labelQuestion.Text = currentQuestionExam.QuestionText + $"\r\n\r\n" +
                $"A. {currentQuestionExam.QuestionAnswerTextA}\r\n" +
                $"B. {currentQuestionExam.QuestionAnswerTextB}\r\n" +
                $"C. {currentQuestionExam.QuestionAnswerTextC}\r\n" +
                $"D. {currentQuestionExam.QuestionAnswerTextD}\r\n";

            checkBoxDapAnA.Checked = false;
            checkBoxDapAnB.Checked = false;
            checkBoxDapAnC.Checked = false;
            checkBoxDapAnD.Checked = false;

            if (currentQuestionSubmitPaper.QuestionAnswers.Contains("A"))
            {
                checkBoxDapAnA.Checked = true;
            }
            if (currentQuestionSubmitPaper.QuestionAnswers.Contains("B"))
            {
                checkBoxDapAnB.Checked = true;
            }
            if (currentQuestionSubmitPaper.QuestionAnswers.Contains("C"))
            {
                checkBoxDapAnC.Checked = true;
            }
            if (currentQuestionSubmitPaper.QuestionAnswers.Contains("D"))
            {
                checkBoxDapAnD.Checked = true;
            }
        }
        #endregion

        #region Timer
        private void timerExam_Tick(object sender, EventArgs e)
        {
            if (_timeLeft < 0)
            {
                _timeLeft -= 1;
                int minute_int = _timeLeft / 60;
                int second_int = _timeLeft % 60;
                string minute_string = minute_int.ToString("00"); // Giữ số 0 ở trước nếu phút <10
                string second_string = second_int.ToString("00"); // Giữ số 0 ở trước nếu giây <10
                textBoxTime.Text = minute_string + ":" + second_string;

                // MONKE Anticheat: Tự động tắt app hiện trước màn hình thi
                int foregroundWindow = Win32.GetForegroundWindow();
                // Kiểm tra cửa sổ hiện tại được focus
                //if (base.Handle.ToInt32() != foregroundWindow)
                //{
                //    Win32.SendMessage(foregroundWindow, 274U, 61472, 0);
                //}
                //Win32.SetActiveWindow(base.Handle.ToInt32());
            }
            else
            {
                ((System.Windows.Forms.Timer)sender).Stop();
                textBoxTime.Text = "00:00";
                _userFinishedExam = true;
                checkBoxConfirmFinish.Checked = true;
                buttonFinish.Enabled = true;
                buttonFinish.PerformClick();
            }

            if (_userFinishedExam)
            {
                ((System.Windows.Forms.Timer)sender).Stop();
                checkBoxConfirmFinish.Checked = true;
                buttonFinish.Enabled = true;
                buttonFinish.PerformClick();
            }
        }
        #endregion

        #region Fullscreen
        public void EnterFullScreenMode(Form targetForm)
        {
            targetForm.WindowState = FormWindowState.Normal;
            targetForm.FormBorderStyle = FormBorderStyle.None;
            targetForm.WindowState = FormWindowState.Maximized;
        }

        public void LeaveFullScreenMode(Form targetForm)
        {
            targetForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            targetForm.WindowState = FormWindowState.Normal;
        }
        #endregion
    }
    internal class Win32
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(int hWnd);

        [DllImport("user32.dll")]
        public static extern bool SetActiveWindow(int hWnd);

        public const int WM_SYSCOMMAND = 274;

        public const int SC_CLOSE = 61536;

        public const int SC_MINIMIZE = 61472;
    }
}