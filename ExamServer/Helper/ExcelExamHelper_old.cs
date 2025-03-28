using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
using DocumentFormat.OpenXml.Office2021.MipLabelMetaData;
using DocumentFormat.OpenXml.Spreadsheet;
using ExamLibrary.Question;
using ExamLibrary.Question.Types;
using MiniExcelLibs;
using static System.Net.Mime.MediaTypeNames;

namespace ManagementServer.Helper
{
    internal class ExcelExamHelper_old
    {
        public static Paper ReadFromFileIntoPaper(string excelFileName)
        {
            //string thongTinSheet = "Thong tin"; // Replace with your sheet name
            //string cell_MaDe = "C5"; // Example: Read cell C5
            //string cell_MaGiangVien = "C8";
            //Paper paper = 
            return new Paper("name", "", "", "", 3600, null, false)
            {
                //Mark = ReadMarkInfo(excelFileName),
                Duration = ReadDurationInfo(excelFileName),
                ExamImageBase64 = Convert.ToBase64String(ReadImagesFromExcel(excelFileName, "Thong Tin")),
                OptionShuffleMultipleChoice = ReadMultipleChoiceInfo(excelFileName),
                QMultipleChoice = ReadMultipleChoiceQuestions(excelFileName),
            };
        }

        private static int ReadDurationInfo(string excelFileName)
        {
            string sheet = "Thong Tin";
            string cell = "C5";

            try
            {
                // --- Read a specific cell ---
                using (var workbook = new XLWorkbook(excelFileName))
                {
                    var worksheet = workbook.Worksheet(sheet);

                    // Read a specific cell value
                    var shuffleQuestions = worksheet.Cell(cell);
                    if (string.IsNullOrWhiteSpace((string)shuffleQuestions.Value))
                    {
                        return (int)shuffleQuestions.Value;
                    }
                    else
                    {
                        Console.WriteLine($"ReadDurationInfo Error reading file: {cell} is empty or not found.");
                        return 0;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"ReadDurationInfo Error: File not found at '{excelFileName}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ReadDurationInfo: An error occurred: {ex.Message}");
            }
            return 0;
        }

        private static int ReadMarkInfo(string excelFileName)
        {
            string sheet = "Thong Tin";
            string cell = "E5";

            try
            {
                // --- Read a specific cell ---
                using (var workbook = new XLWorkbook(excelFileName))
                {
                    var worksheet = workbook.Worksheet(sheet);

                    // Read a specific cell value
                    var mark = worksheet.Cell(cell);
                    if (string.IsNullOrWhiteSpace((string)mark.Value))
                    {
                        return (int)mark.Value;
                    }
                    else
                    {
                        Console.WriteLine($"ReadMarkInfo Error reading file: {cell} is empty or not found.");
                        return 0;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"ReadMarkInfo Error: File not found at '{excelFileName}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ReadMarkInfo: An error occurred: {ex.Message}");
            }
            return 0;
        }

        private static bool ReadMultipleChoiceInfo(string excelFileName)
        {
            string multipleChoiceSheet = "MultipleChoice";
            string cell_ShuffleQuestions = "C6";

            try
            {
                // --- Read a specific cell ---
                using (var workbook = new XLWorkbook(excelFileName))
                {
                    var worksheet = workbook.Worksheet(multipleChoiceSheet);

                    // Read a specific cell value
                    var shuffleQuestions = worksheet.Cell(cell_ShuffleQuestions);
                    if ((string)shuffleQuestions.Value != null)
                    {
                        if ((string)shuffleQuestions.Value == "Yes")
                        {
                            return true;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error reading file: Mark: {cell_ShuffleQuestions} is empty or not found.");
                        return false;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: File not found at '{excelFileName}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ReadMultipleChoiceInfo: An error occurred: {ex.Message}");
            }
            return false;
        }

        private static List<MultipleChoice> ReadMultipleChoiceQuestions(string excelFileName)
        {
            string multipleChoiceSheet = "MultipleChoice";
            //string cell_PassAnswer = "C7";
            //string cell_ShuffleQuestions = "C8";

            string tableStartCellAddress = "B10"; // Example: Table starts at B10

            List<MultipleChoice> multipleChoiceList = new List<MultipleChoice>();

            try
            {
                using (var workbook = new XLWorkbook(excelFileName))
                {
                    var worksheet = workbook.Worksheet(multipleChoiceSheet);
                    var tableStartCell = worksheet.Cell(tableStartCellAddress);

                    if (tableStartCell == null)
                    {
                        Console.WriteLine($"Error: Table start cell '{tableStartCellAddress}' not found.");
                        return multipleChoiceList;
                    }

                    int firstRow = tableStartCell.Address.RowNumber;
                    int firstColumn = tableStartCell.Address.ColumnNumber;

                    // Assuming your table has headers in the first row of the table
                    // and the order of columns is: QuestionID, QuestionText, A, B, C, D
                    // Adjust the column indices based on your actual Excel structure.
                    int questionIdColumn = firstColumn;
                    int questionTextColumn = firstColumn + 1;
                    int answerAColumn = firstColumn + 2;
                    int answerBColumn = firstColumn + 3;
                    int answerCColumn = firstColumn + 4;
                    int answerDColumn = firstColumn + 5;
                    int answersColumn = firstColumn + 6;

                    int currentRow = firstRow;
                    while (true)
                    {
                        var questionIdCell = worksheet.Cell(currentRow, questionIdColumn);
                        if (string.IsNullOrWhiteSpace(questionIdCell.Value.ToString()))
                        {
                            // Stop if the QuestionID cell is empty, assuming it indicates the end of the table
                            break;
                        }

                        var multipleChoiceItem = new MultipleChoice();

                        // Read QuestionID (assuming it's an integer)
                        if (int.TryParse(questionIdCell.Value.ToString(), out int questionId))
                        {
                            multipleChoiceItem.QuestionID = questionId;
                        }
                        else
                        {
                            Console.WriteLine($"Warning: Could not parse QuestionID in row {currentRow}. Skipping this row.");
                            currentRow++;
                            continue; // Skip to the next row if QuestionID is invalid
                        }

                        // Read QuestionText
                        var questionTextCell = worksheet.Cell(currentRow, questionTextColumn);
                        multipleChoiceItem.QuestionText = questionTextCell.Value.ToString();

                        // Read Answers
                        multipleChoiceItem.QuestionAnswerTextA = worksheet.Cell(currentRow, answerAColumn).Value.ToString();
                        multipleChoiceItem.QuestionAnswerTextB = worksheet.Cell(currentRow, answerBColumn).Value.ToString();
                        multipleChoiceItem.QuestionAnswerTextC = worksheet.Cell(currentRow, answerCColumn).Value.ToString();
                        multipleChoiceItem.QuestionAnswerTextD = worksheet.Cell(currentRow, answerDColumn).Value.ToString();

                        // Add answers to the list
                        string allAnswersText = worksheet.Cell(currentRow, answersColumn).Value.ToString();
                        if (!string.IsNullOrEmpty(allAnswersText))
                        {
                            string[] individualAnswers = allAnswersText.Split(';');
                            foreach (string answer in individualAnswers)
                            {
                                // Trim any leading/trailing whitespace from each answer
                                multipleChoiceItem.QuestionAnswers.Add(answer.Trim());
                            }
                        }

                        multipleChoiceList.Add(multipleChoiceItem);
                        currentRow++;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"ReadMultipleChoiceQuestions: Error: File not found at '{excelFileName}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ReadMultipleChoiceQuestions: An error occurred: {ex.Message}");
            }

            return multipleChoiceList;
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
