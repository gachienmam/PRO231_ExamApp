using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Question
{
    public class SubmitPaper
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

        public string Username;

        public int TimeLeft;

        public DateTime SubmitTime;

        public int MultipleChoiceIndex;

        public bool Finished;

        public int Mark;

        public Paper SubmissionPaper;

        public int LastSelectedTabIndex;

        public string ExamCode;
    }
}
