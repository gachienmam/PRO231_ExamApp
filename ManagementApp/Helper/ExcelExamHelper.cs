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
            //string thongTinSheet = "Thong tin"; // Replace with your sheet name
            //string cell_MaDe = "C5"; // Example: Read cell C5
            //string cell_MaGiangVien = "C8";
            Paper paper = new Paper("name", "", "", "", 3600, null, false);
            paper.Duration = Convert.ToInt32(ReadFirstValueFromExcel(excelFileName, "Thong Tin", "ThoiGianLamBai"));
            //ExamImageBase64 = Convert.ToBase64String(ReadImagesFromExcel(excelFileName, "Thong Tin")),
            paper.ExamImageBase64 = "";
            paper.OptionShuffleMultipleChoice = (string)ReadFirstValueFromExcel(excelFileName, "Option MultipleChoice", "XaoTronCauHoi") == "Yes" ? true : false;
            paper.QMultipleChoice = ReadMultipleChoiceQuestions(excelFileName, "MultipleChoice");
            return;
        }

        public static object ReadFirstValueFromExcel(string filePath, string worksheet, string columnName)
        {
            using (var stream = File.OpenRead(filePath))
            {
                var rows = stream.Query(sheetName: worksheet, useHeaderRow: true); //Read the first row
                var firstRow = rows.FirstOrDefault() as IDictionary<string, object>; // Cast to IDictionary

                if (firstRow != null && firstRow.ContainsKey(columnName))
                {
                    return firstRow[columnName];
                }
                else
                {
                    return null; // Or throw an exception, depending on your needs.
                }
            }
        }

        public static List<MultipleChoice> ReadMultipleChoiceQuestions(string filePath, string worksheetName)
        {
            List<MultipleChoice> questions = new List<MultipleChoice>();

            using (var stream = File.OpenRead(filePath))
            {
                var rows = stream.Query(sheetName: worksheetName, useHeaderRow: true);

                if (rows == null)
                {
                    Console.WriteLine($"Worksheet '{worksheetName}' not found or is empty.");
                    return questions; // Return empty list.
                }

                foreach (var row in rows)
                {
                    var dictRow = row as IDictionary<string, object>;

                    if (dictRow != null)
                    {
                        try
                        {
                            var question = new MultipleChoice
                            {
                                QuestionID = Convert.ToInt32(dictRow["QuestionID"]),
                                QuestionText = dictRow["QuestionText"]?.ToString(),
                                QuestionAnswerTextA = dictRow["QuestionAnswerTextA"]?.ToString(),
                                QuestionAnswerTextB = dictRow["QuestionAnswerTextB"]?.ToString(),
                                QuestionAnswerTextC = dictRow["QuestionAnswerTextC"]?.ToString(),
                                QuestionAnswerTextD = dictRow["QuestionAnswerTextD"]?.ToString(),
                                QuestionAnswers = dictRow.ContainsKey("QuestionAnswers") && dictRow["QuestionAnswers"] != null
                                    ? dictRow["QuestionAnswers"].ToString().Split(';').ToList()
                                    : new List<string>() // Handle null or missing QuestionAnswers.
                            };
                            questions.Add(question);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error processing row: {ex.Message}");
                        }
                    }
                }
            }
            return questions;
        }
    }
}
