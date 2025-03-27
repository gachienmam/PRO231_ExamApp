using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Question
{
    public class SubmitPaper : ICloneable
    {
        public override bool Equals(object obj)
        {
            try
            {
                SubmitPaper submitPaper = (SubmitPaper)obj;
                return this.ExamCode.Equals(submitPaper.ExamCode) && this.SubmissionPaper.ExamCode.Equals(submitPaper.SubmissionPaper.ExamCode);
            }
            catch
            {
                return false;
            }
        }
        
        // Tên thí sinh (MaThiSinh)
        public string Username { get; set; }
        // Thời gian còn lại khi nộp bài
        public int TimeLeft { get; set; }
        // Thời gian (máy tính) hiện tại khi nộp
        public DateTime SubmitTime { get; set; }
        // Câu hỏi cuối cùng thí sinh chọn trước khi nộp
        public int MultipleChoiceIndex { get; set; }
        // Thí sinh đã hoàn thành bài kiểm tra hay chưa?
        public bool Finished { get; set; }
        // Paper chứa câu trả lời
        public Paper SubmissionPaper { get; set; }
        // Mã đề thi (MaDe)
        public string ExamCode { get; set; }

        public SubmitPaper(string username, int timeLeft, DateTime submitTime, int multipleChoiceIndex, bool finished, int mark, Paper submissionPaper, string examCode)
        {
            Username = username;
            TimeLeft = timeLeft;
            SubmitTime = submitTime;
            MultipleChoiceIndex = multipleChoiceIndex;
            Finished = finished;
            SubmissionPaper = submissionPaper; // Reference assignment, will be deep copied in Clone()
            //LastSelectedTabIndex = lastSelectedTabIndex;
            ExamCode = examCode;
        }

        private SubmitPaper(SubmitPaper other)
        {
            Username = other.Username;
            TimeLeft = other.TimeLeft;
            SubmitTime = other.SubmitTime;
            MultipleChoiceIndex = other.MultipleChoiceIndex;
            Finished = other.Finished;
            SubmissionPaper = other.SubmissionPaper != null ? (Paper)other.SubmissionPaper.Clone() : null; // Deep copy of Paper
            ExamCode = other.ExamCode;
        }

        public object Clone()
        {
            return new SubmitPaper(this);
        }
    }
}
