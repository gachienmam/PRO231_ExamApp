using ExamLibrary.Question.Types;

namespace ExamServer.Helper
{
    public class ExamGrader
    {
        public static Dictionary<int, bool> GradeExam(List<MultipleChoice> correctAnswers, List<MultipleChoice> studentAnswers)
        {
            Dictionary<int, bool> results = new Dictionary<int, bool>();

            foreach (var studentAnswer in studentAnswers)
            {
                var correctAnswer = correctAnswers.FirstOrDefault(ca => ca.QuestionID == studentAnswer.QuestionID);

                if (correctAnswer != null)
                {
                    results[studentAnswer.QuestionID] = CheckEqual(correctAnswer, studentAnswer, correctAnswers.Count > 1 ? true : false);
                }
                else
                {
                    results[studentAnswer.QuestionID] = false; // Đánh sai nếu không tìm thấy câu hỏi trong paper của thí sinh
                }
            }

            return results;
        }

        public static int GetCorrectAnswersFromGradeExamResult(Dictionary<int, bool> results)
        {
            return results.Count(r => r.Value);
        }

        private static bool CheckEqual(MultipleChoice correctAnswer, MultipleChoice studentAnswer, bool isMultipleChoice)
        {
            if (isMultipleChoice)
            {
                // Cho câu hỏi có nhiều lựa chọn, thì so sánh 2 danh sách
                if (correctAnswer.QuestionAnswers == null || studentAnswer.QuestionAnswers == null)
                {
                    return correctAnswer.QuestionAnswers == null && studentAnswer.QuestionAnswers == null;
                }

                if (correctAnswer.QuestionAnswers.Count > 1) // Cho câu hỏi có nhiều đáp án đúng
                {
                    // Kiểm tra nếu đáp án thí sinh có trùng với đáp án đúng
                    return studentAnswer.QuestionAnswers.All(sa => correctAnswer.QuestionAnswers.Any(ca => ca.Equals(sa, StringComparison.OrdinalIgnoreCase)));
                }
                else // Chỉ một đáp án đúng
                {
                    if (studentAnswer.QuestionAnswers.Count != 1)
                    {
                        return false; // Có một đáp án đúng mà thí sinh chọn nhiều thì auto sai gg
                    }
                    else
                    {
                        return correctAnswer.QuestionAnswers[0].Equals(studentAnswer.QuestionAnswers[0], StringComparison.OrdinalIgnoreCase);
                    }
                }
            }
            else
            {
                // Không cho chọn nhiều thì chỉ so cái đầu tiên
                if (correctAnswer.QuestionAnswers == null || correctAnswer.QuestionAnswers.Count == 0 || correctAnswer.QuestionAnswers[0] == null)
                {
                    return studentAnswer.QuestionAnswers == null || studentAnswer.QuestionAnswers.Count == 0 || studentAnswer.QuestionAnswers[0] == null;
                }

                return correctAnswer.QuestionAnswers[0].Equals(studentAnswer.QuestionAnswers[0], StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
