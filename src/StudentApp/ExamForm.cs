﻿using ExamLibrary.Question;
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
using Newtonsoft.Json;
using System.IO;
using ExamLibrary.Helper;
using ExamLibrary.Enum;
using System.Net;

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

        // Mã thí sinh
        private string _maThiSinh;

        // Kiểm tra người dùng đã hoàn thành bài thi hay chưa (cho nút Finish)
        private bool _userFinishedExam;

        // Kiểm tra nếu form đang lưu đề thi lên hệ thống
        private bool _isSavingExamToServer;

        // Thời gian còn lại
        private int _timeLeft;

        // Câu hỏi đã có đáp án được đổi
        private bool _answerChanged;

        // Câu hỏi hiện tại đếm từ 1 (MultipleChoice)
        private int _multipleChoice_currentQuestion;

        public ExamForm(ExamService.ExamServiceClient client, Grpc.Core.Metadata headers, ExamData data, string maThiSinh)
        {
            InitializeComponent();

            // MONKE Anticheat: Giấu cửa sổ thi khỏi phần mềm quay fim
            ExamForm.SetWindowDisplayAffinity(base.Handle, 1U);

            _client = client;
            _headers = headers;
            _data = data;

            _maThiSinh = maThiSinh;

            // Deserialize ServerInformation
            try
            {
                _serverInfo = JsonConvert.DeserializeObject<ServerInformation>(_data.ServerInformation);
                //MessageBox.Show(_data.ServerInformation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý dữ liệu thông tin máy chủ: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK);
                //Application.Exit();
            }

            try
            {
                _examPaper = JsonConvert.DeserializeObject<Paper>(GZip.DecompressJson(_data.ExamPaper.ToByteArray()));
                //MessageBox.Show(GZip.DecompressJson(_data.ExamPaper.ToByteArray()));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý dữ liệu dữ liệu thi: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK);
                //Application.Exit();
            }

            _submitPaper = new SubmitPaper(_maThiSinh, _examPaper.Duration, DateTime.Now, 0, false, 0, (Paper)_examPaper.Clone(), _examPaper.ExamCode);

            _submitPaper.SubmissionPaper.QMultipleChoice = _examPaper.QMultipleChoice.Select(q => new MultipleChoice
            {
                QuestionID = q.QuestionID,
                QuestionAnswers = new List<string>() // Để trống đáp án
            }).ToList();

            _timeLeft = _examPaper.Duration;

            _isSavingExamToServer = false;
            _answerChanged = false;
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            if (_data == null)
            {
                CrownMessageBox.ShowError($"Lỗi khi xử lý dữ liệu thi.", "Lỗi hệ thống", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                //Application.Exit();
            }

            _multipleChoice_currentQuestion = 1;

            // Load Server Info
            textBoxMachine.Text = Environment.MachineName;
            textBoxServer.Text = _serverInfo.ServerName;
            textBoxExamCode.Text = _examPaper.ExamCode;
            textBoxStudent.Text = _maThiSinh;

            if (string.IsNullOrWhiteSpace(_examPaper.ExamImageLink))
            {
                pictureAnhDeThi.Visible = false;
            }
            else
            {
                pictureAnhDeThi.Visible = true;

                //pictureAnhDeThi.Load(_examPaper.ExamImageLink);
                pictureAnhDeThi.Image = GetImageFromCacheOrDownload(_examPaper.ExamImageLink, _examPaper.ExamCode + "DisplayImage");
                //pictureBoxQuestionImage.Width = pictureBoxQuestionImage.Image.Width;
            }

            buttonFinish.Enabled = false;

            examContainerPanel.SectionHeader = "PolyTest Exam Client - Hôm nay: " + DateTime.Now.ToString("dd/MM/yyyy");

            // Fullscreen
            EnterFullScreenMode(this);

            checkBoxDapAnA.Click += checkBoxDapAn_CheckedChanged;
            checkBoxDapAnB.Click += checkBoxDapAn_CheckedChanged;
            checkBoxDapAnC.Click += checkBoxDapAn_CheckedChanged;
            checkBoxDapAnD.Click += checkBoxDapAn_CheckedChanged;

            // Load đề thi
            timerExam.Start();
            AddQuestionButtonsToPanel(_examPaper.QMultipleChoice.Count);
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

        private async void crownButtonFinish_Click(object sender, EventArgs e)
        {
            if (_userFinishedExam)
            {
                Application.Exit();
            }
            else
            {
                if (_isSavingExamToServer)
                {
                    return;
                }
                if (_answerChanged)
                {
                    SaveAnswerToSubmissionPaper(_multipleChoice_currentQuestion - 1);
                    _answerChanged = false;
                }
                await SendCurrentSubmissionPaperToServer(true);
            }
        }

        private async void buttonNext_Click(object sender, EventArgs e)
        {
            if (_isSavingExamToServer)
            {
                return;
            }
            if (_answerChanged)
            {
                SaveAnswerToSubmissionPaper(_multipleChoice_currentQuestion - 1);
                await SendCurrentSubmissionPaperToServer(false);
                _answerChanged = false;
            }
            _multipleChoice_currentQuestion += 1;
            if (_multipleChoice_currentQuestion > _examPaper.QMultipleChoice.Count)
            {
                _multipleChoice_currentQuestion = 1;
            }
            UpdateAnsweredQuestionButtons();
            DisplayMultipleChoice(_multipleChoice_currentQuestion - 1);
        }

        private void checkBoxDapAn_CheckedChanged(object sender, EventArgs e)
        {
            _answerChanged = true;
        }

        private async void questionButton_Click(object sender, EventArgs e)
        {
            if (_isSavingExamToServer)
            {
                return;
            }
            if (_answerChanged)
            {
                SaveAnswerToSubmissionPaper(_multipleChoice_currentQuestion - 1);
                await SendCurrentSubmissionPaperToServer(false);
                _answerChanged = false;
            }
            CrownButton button = (CrownButton)sender;
            int num = Convert.ToInt32(button.Text);
            _multipleChoice_currentQuestion = num;
            UpdateAnsweredQuestionButtons();
            DisplayMultipleChoice(_multipleChoice_currentQuestion - 1);
        }

        private void numericQuestionFontSize_ValueChanged(object sender, EventArgs e)
        {
            textBoxQuestion.Font = new Font("Segoe UI", (float)numericQuestionFontSize.Value, FontStyle.Regular);
        }

        private void panelDanhSachCauHoi_Scroll(object sender, ScrollEventArgs e)
        {
            panelDanhSachCauHoi.Invalidate();
            panelDanhSachCauHoi.Refresh();
        }
        #endregion

        #region Function
        private void SaveAnswerToSubmissionPaper(int questionIndex)
        {
            var currentQuestionSubmitPaper = _submitPaper.SubmissionPaper.QMultipleChoice.Where(q => q.QuestionID == _submitPaper.SubmissionPaper.QMultipleChoice[questionIndex].QuestionID).FirstOrDefault();
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

        private async Task SendCurrentSubmissionPaperToServer(bool isEndingExam)
        {
            PaperSubmission paperSubmission = new();
            try
            {
                _isSavingExamToServer = true;
                _submitPaper.TimeLeft = _timeLeft;
                if (isEndingExam)
                {
                    paperSubmission = new PaperSubmission
                    {
                        SubmissionType = (int)PaperSubmitResponse.SUBMIT_FINAL,
                        ThiSinhId = _maThiSinh,
                        ExamCode = _examPaper.ExamCode,
                        StudentSubmitPaper = ByteString.CopyFrom(GZip.CompressJson(JsonConvert.SerializeObject(_submitPaper)))
                    };
                }
                else
                {
                    paperSubmission = new PaperSubmission
                    {
                        SubmissionType = (int)PaperSubmitResponse.SUBMIT_CONTINUE,
                        ThiSinhId = _maThiSinh,
                        ExamCode = _examPaper.ExamCode,
                        StudentSubmitPaper = ByteString.CopyFrom(GZip.CompressJson(JsonConvert.SerializeObject(_submitPaper)))
                    };
                }

                var response = await _client.SubmitPaperAsync(paperSubmission, _headers);
                labelInfo.Text = "";
                if (response != null)
                {
                    if (response.ResponseCode == (int)PaperSubmitResponse.SUBMIT_FAILED)
                    {
                        labelInfo.Text = "Bài của bạn chưa được luu vì một lí do nội bộ hệ thống, xin hãy báo giám thị.";
                        return;
                    }
                    if (response.ResponseCode == (int)PaperSubmitResponse.SUBMIT_SUCCESS_FINAL)
                    {
                        if (!isEndingExam)
                        {
                            labelInfo.Text = "Bạn đã bị ép hoàn thành bài thi!";
                            FinishExam();
                        }
                        else
                        {
                            labelInfo.Text = "Bạn đã hoàn thành bài thi!";
                            FinishExam();
                        }
                    }
                }
                else
                {
                    labelInfo.Text = "Bài của bạn chưa được lưu một lí do nội bộ hệ thống, xin hãy báo giám thị và tiếp tục thi.";
                }
            }
            catch
            {
                if (_userFinishedExam)
                {
                    labelInfo.Text = "Bài của bạn chưa được lưu trên máy chủ, xin hãy báo giám thị.";
                    _userFinishedExam = false; // Chặn không cho thoát nếu chưa lưu được bài thi
                }
                else
                {
                    labelInfo.Text = "Bài của bạn chưa được lưu trên máy chủ, xin hãy báo giám thị và tiếp tục thi.";
                }
            }
            finally
            {
                _isSavingExamToServer = false;
            }
        }

        private void UpdateAnsweredQuestionButtons()
        {
            for (int i = 1; i < _submitPaper.SubmissionPaper.QMultipleChoice.Count; i++)
            {
                Color color;
                if (_submitPaper.SubmissionPaper.QMultipleChoice[i].QuestionAnswers.Count > 0)
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

        //private Image ByteArrayToImage(byte[] data)
        //{
        //    MemoryStream ms = new MemoryStream(data);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}

        private void AddQuestionButtonsToPanel(int n)
        {
            // Vị trí ban đầu của nút
            int x_pos = 1;
            int y_pos = 30;
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
                if (button.Left + button.Width >= this.panelDanhSachCauHoi.Width - button.Width)
                {
                    x_pos = 1;
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
            var currentQuestionExam = _examPaper.QMultipleChoice[questionOrder];
            var currentQuestionSubmitPaper = _submitPaper.SubmissionPaper.QMultipleChoice[questionOrder];
            panelCauHoiHienTai.SectionHeader = $"Câu hỏi ({questionOrder + 1}/{_examPaper.QMultipleChoice.Count})";
            textBoxQuestion.Text = $"(Chọn {currentQuestionExam.QuestionAnswers.Count} đáp án)\r\n" +
                $"{currentQuestionExam.QuestionText} \r\n\r\n" +
                $"A. {currentQuestionExam.QuestionAnswerTextA}\r\n" +
                $"B. {currentQuestionExam.QuestionAnswerTextB}\r\n" +
                $"C. {currentQuestionExam.QuestionAnswerTextC}\r\n" +
                $"D. {currentQuestionExam.QuestionAnswerTextD}\r\n";

            if (string.IsNullOrWhiteSpace(currentQuestionExam.QuestionImageLink))
            {
                panelQuestionImageContainer.Visible = false;
                pictureBoxQuestionImage.Visible = false;
                splitterQuestionImage.Visible = false;
            }
            else
            {
                panelQuestionImageContainer.Size = new Size(322, 1);
                panelQuestionImageContainer.Visible = true;
                pictureBoxQuestionImage.Visible = true;
                splitterQuestionImage.Visible = true;

                pictureBoxQuestionImage.Image = GetImageFromCacheOrDownload(currentQuestionExam.QuestionImageLink, currentQuestionExam.QuestionID.ToString());
                //pictureBoxQuestionImage.Load(currentQuestionExam.QuestionImageLink);
                //pictureBoxQuestionImage.Width = pictureBoxQuestionImage.Image.Width;
            }

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

        // Nếu không có ảnh sẵn thì tải về và lưu lại làm bộ nhớ tạm
        private Image GetImageFromCacheOrDownload(string imageLink, string fileName)
        {
            if (string.IsNullOrEmpty(imageLink))
            {
                return null;
            }

            string tempDirectory = Path.Combine(Path.GetTempPath(), "PolyTestExamClient");
            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }

            string fileName1 = Path.GetFileName(new Uri(imageLink).AbsolutePath); // Lấy tên file từ link ảnh
            string filePath = Path.Combine(tempDirectory, fileName1);

            if (File.Exists(filePath))
            {
                try
                {
                    return Image.FromFile(filePath);
                }
                catch (Exception ex)
                {
                    // Xử lý ảnh bị fake
                    labelInfo.Text = $"GetImage: Lỗi khi tải ảnh về máy: {ex.Message}";
                    File.Delete(filePath); // Xóa ảnh lỗi
                    return DownloadAndCacheImage(imageLink, filePath); // Tải lại ảnh
                }

            }
            else
            {
                return DownloadAndCacheImage(imageLink, filePath);
            }
        }

        private Image DownloadAndCacheImage(string imageLink, string filePath)
        {
            WebClient webClient = new WebClient();
            try
            {
                byte[] imageBytes = webClient.DownloadData(imageLink);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(ms);
                    image.Save(filePath); // Lưu vô thư mục tạm
                    return image;
                }
            }
            catch (WebException wex)
            {
                // Xử lý ảnh bị fake
                labelInfo.Text = $"DLWebException: Lỗi khi tải ảnh về máy: {wex.Message}";
                return null;
            }
            catch (Exception ex)
            {
                labelInfo.Text = $"DLException: Lỗi khi tải ảnh về máy: {ex.Message}";
                return null;
            }
            finally
            {
                webClient?.Dispose();
            }
        }

        private void FinishExam()
        {
            timerExam.Stop();
            panelQuestionContainer.Hide();
            numericQuestionFontSize.Hide();
            labelQuestionFontSize.Hide();
            LeaveFullScreenMode(this);
            _userFinishedExam = true;
            checkBoxConfirmFinish.Enabled = false;
        }

        #endregion

        #region Timer
        private void timerExam_Tick(object sender, EventArgs e)
        {
            if (_timeLeft > 0)
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
                if (base.Handle.ToInt32() != foregroundWindow)
                {
                    Win32.SendMessage(foregroundWindow, 274U, Win32.SC_MINIMIZE, 0);
                }
                Win32.SetActiveWindow(base.Handle.ToInt32());
            }
            else
            {
                ((System.Windows.Forms.Timer)sender).Stop();
                textBoxTime.Text = "00:00";
                checkBoxConfirmFinish.Checked = true;
                buttonFinish.Enabled = true;
                buttonFinish.PerformClick();
            }
            //if (_userFinishedExam)
            //{
            //    ((System.Windows.Forms.Timer)sender).Stop();
            //    checkBoxConfirmFinish.Checked = true;
            //    buttonFinish.Enabled = true;
            //    buttonFinish.PerformClick();
            //}
        }
        #endregion

        #region Fullscreen
        private void EnterFullScreenMode(Form targetForm)
        {
            targetForm.WindowState = FormWindowState.Normal;
            targetForm.FormBorderStyle = FormBorderStyle.None;
            targetForm.WindowState = FormWindowState.Maximized;
        }

        private void LeaveFullScreenMode(Form targetForm)
        {
            targetForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            targetForm.WindowState = FormWindowState.Normal;
        }
        #endregion

        #region Debug Button
        private void pictureAnhDeThi_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(_isSavingExamToServer.ToString());
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