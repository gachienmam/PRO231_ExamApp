using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office.SpreadSheetML.Y2023.MsForms;
using DocumentFormat.OpenXml.Office2021.MipLabelMetaData;
using DocumentFormat.OpenXml.Spreadsheet;
using ExamLibrary.Question;
using ExamLibrary.Question.Types;
using MiniExcelLibs;
using static System.Net.Mime.MediaTypeNames;

namespace ManagementServer.Helper
{
    internal class ExcelExamHelper
    {
        public static Paper ReadFromFileIntoPaper(string excelFileName)
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
            return paper;
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

        private static byte[] ReadImagesFromExcel(string filePath, string sheetName)
        {
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(sheetName);

                    foreach (var drawing in worksheet.Pictures)
                    {
                        Console.WriteLine($"Found Image From {filePath}/{sheetName}: {drawing.ImageStream}");

                        //string imageName = $"extracted_image_{Guid.NewGuid()}.{drawing.Name.Split('/').Last()}";
                        //string outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), imageName);

                        try
                        {
                            return drawing.ImageStream.ToArray();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error saving image '{drawing.Name}': {ex.Message}");
                            return null;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: File not found.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
            return null;
        }
    }
}
