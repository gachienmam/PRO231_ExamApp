using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Question.Types
{
    public class MultipleChoice : ICloneable
    {
        public MultipleChoice()
        {

        }

        public MultipleChoice(int questionID, string questionText, string questionAnswerTextA, string questionAnswerTextB, string questionAnswerTextC, string questionAnswerTextD, List<string> questionAnswers, string questionImageLink)
        {
            QuestionID = questionID;
            QuestionText = questionText;
            QuestionAnswerTextA = questionAnswerTextA;
            QuestionAnswerTextB = questionAnswerTextB;
            QuestionAnswerTextC = questionAnswerTextC;
            QuestionAnswerTextD = questionAnswerTextD;
            QuestionAnswers = questionAnswers != null ? new List<string>(questionAnswers) : null; // Deep copy of the list
            QuestionImageLink = questionImageLink;
        }

        private MultipleChoice(MultipleChoice other)
        {
            QuestionID = other.QuestionID;
            QuestionText = other.QuestionText;
            QuestionAnswerTextA = other.QuestionAnswerTextA;
            QuestionAnswerTextB = other.QuestionAnswerTextB;
            QuestionAnswerTextC = other.QuestionAnswerTextC;
            QuestionAnswerTextD = other.QuestionAnswerTextD;
            QuestionAnswers = other.QuestionAnswers != null ? new List<string>(other.QuestionAnswers) : null; // Deep copy of the list
            QuestionImageLink = other.QuestionImageLink;
        }

        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionAnswerTextA { get; set; }
        public string QuestionAnswerTextB { get; set; }
        public string QuestionAnswerTextC { get; set; }
        public string QuestionAnswerTextD { get; set; }
        public List<string> QuestionAnswers { get; set; }
        public string QuestionImageLink { get; set; }

        public object Clone()
        {
            return new MultipleChoice(this);
        }
    }
}
