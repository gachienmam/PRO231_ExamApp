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
                return this.ID.Equals(submitPaper.ID) && this.SPaper.ExamCode.Equals(submitPaper.SPaper.ExamCode);
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

        public Paper SPaper;

        public int LastSelectedTabIndex;

        public string ID;

        public List<Types.MultipleChoice> MultipleChoiceQuestions;
    }
}
