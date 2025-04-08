using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamLibrary.Question;
using ExamLibrary.Question.Types;
using MiniExcelLibs;
using static System.Net.Mime.MediaTypeNames;

namespace ManagementApp.Helper
{
    internal class ExcelExamHelper
    {
        public static void TestReadFromFileIntoPaper(string excelFileName)
        {
            Paper paper = new Paper("name", "", "", "", 3600, null, false);
            paper.Duration = Convert.ToInt32(ReadFirstValueFromExcel(excelFileName, "Thong Tin", "ThoiGianLamBai"));
            paper.ExamImageLink = (string)ReadFirstValueFromExcel(excelFileName, "Thong Tin", "LinkAnhDeThi");
            paper.OptionShuffleMultipleChoice = (string)ReadFirstValueFromExcel(excelFileName, "Option MultipleChoice", "XaoTronCauHoi") == "Yes" ? true : false;
            paper.QMultipleChoice = ReadMultipleChoiceQuestions(excelFileName, "MultipleChoice");
            return;
        }

        public static object ReadFirstValueFromExcel(string filePath, string worksheet, string columnName)
        {
            using (var stream = File.OpenRead(filePath))
            {
                var rows = stream.Query(sheetName: worksheet, useHeaderRow: true); // Đọc dòng đầu tiên
                var firstRow = rows.FirstOrDefault() as IDictionary<string, object>; // Chuyển sang dạng IDictionary

                if (firstRow != null && firstRow.ContainsKey(columnName))
                {
                    return firstRow[columnName];
                }
                else
                {
                    throw new Exception("Data not found");
                }
            }
        }

        public static List<MultipleChoice> ReadMultipleChoiceQuestions(string filePath, string worksheetName)
        {
            List<MultipleChoice> questions = new List<MultipleChoice>();
            string[] requiredHeaders = { "QuestionID", "QuestionText", "QuestionAnswerTextA", "QuestionAnswerTextB", "QuestionAnswerTextC", "QuestionAnswerTextD", "QuestionAnswers", "QuestionImageLink" };

            using (var stream = File.OpenRead(filePath))
            {
                var rows = stream.Query(sheetName: worksheetName, useHeaderRow: true);

                if (rows == null)
                {
                    Console.WriteLine($"Worksheet '{worksheetName}' not found or is empty.");
                    return questions; // Trả danh sách trống nếu không tìm thấy dữ liệu
                }

                // Lấy cột đầu tiên
                var firstRow = rows.FirstOrDefault() as IDictionary<string, object>;

                if (firstRow != null)
                {
                    var actualHeaders = firstRow.Keys.ToArray();

                    // Kiểm tra các cột có tồn tại không
                    if (!requiredHeaders.All(header => actualHeaders.Contains(header)))
                    {
                        // Lấy các cột bị mất ra để ném lỗi
                        var missingHeaders = requiredHeaders.Where(header => !actualHeaders.Contains(header)).ToList();
                        throw new Exception($"Missing required headers: {string.Join(", ", missingHeaders)} in worksheet '{worksheetName}'.");
                    }
                }
                else
                {
                    // Lỗi nếu không đọc được tên cột
                    throw new Exception($"Could not read header row from worksheet '{worksheetName}' gg.");
                }

                // Lấy từng cột trong danh sách cột
                foreach (var row in rows)
                {
                    var dictRow = row as IDictionary<string, object>;

                    // Kiểm tra nếu cột có tồn tại hay k
                    if (dictRow != null)
                    {
                        try
                        {
                            // Tạo câu hỏi mới
                            var question = new MultipleChoice
                            {
                                // rồi nhét dữ liệu vào theo key trong IDictionary
                                QuestionID = Convert.ToInt32(dictRow["QuestionID"]),
                                QuestionText = dictRow["QuestionText"].ToString(),
                                QuestionAnswerTextA = dictRow["QuestionAnswerTextA"].ToString(),
                                QuestionAnswerTextB = dictRow["QuestionAnswerTextB"].ToString(),
                                QuestionAnswerTextC = dictRow["QuestionAnswerTextC"].ToString(),
                                QuestionAnswerTextD = dictRow["QuestionAnswerTextD"].ToString(),
                                QuestionAnswers = dictRow.ContainsKey("QuestionAnswers") && dictRow["QuestionAnswers"] != null
                                    ? dictRow["QuestionAnswers"].ToString().Split(';').ToList()
                                    : new List<string>(),// Xử lý danh sách đáp án là null hoặc để trống
                                QuestionImageLink = dictRow["QuestionImageLink"]?.ToString()
                            };

                            // Thêm vào danh sách
                            questions.Add(question);
                        }
                        catch (Exception ex)
                        {
                            // Nếu gặp lỗi bất kỳ thì in ra console
                            Console.WriteLine($"Error processing row: {ex.Message}");
                        }
                    }   
                }
            }
            // Trả về danh sách sau khi lấy xong
            return questions;
        }
    }
}
