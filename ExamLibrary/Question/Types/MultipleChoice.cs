using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Question.Types
{
    public class MultipleChoice
    {
        public MultipleChoice()
        {

        }

        public int QuestionID;

        public string QuestionText;

        public string QuestionAnswerTextA;

        public string QuestionAnswerTextB;

        public string QuestionAnswerTextC;

        public string QuestionAnswerTextD;

        public List<string> QuestionAnswers;
    }
}
