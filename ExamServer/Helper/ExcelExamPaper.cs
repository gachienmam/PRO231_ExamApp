using ExamLibrary;
using ExamLibrary.Question;
using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamServer.Helper
{
    public class ExcelExamPaper
    {
        //public static List<Dictionary<>> ReadExcelData(string filePath)
        //{
        //    return MiniExcel.Query(filePath).ToList();
        //}

        public static void ProcessExcelData(List<Dictionary<string, object>> data)
        {
            foreach (var row in data)
            {
                // Access data by column name (e.g., "Mã câu", "Câu hỏi", "A", "B", "C", "D", "Đáp án")
                if (row.ContainsKey("Mã câu") && row.ContainsKey("Câu hỏi"))
                {
                    string questionId = row["Mã câu"].ToString();
                    string question = row["Câu hỏi"].ToString();
                    string optionA = row.ContainsKey("A") ? row["A"].ToString() : "";
                    string optionB = row.ContainsKey("B") ? row["B"].ToString() : "";
                    string optionC = row.ContainsKey("C") ? row["C"].ToString() : "";
                    string optionD = row.ContainsKey("D") ? row["D"].ToString() : "";
                    string answer = row.ContainsKey("Đáp án") ? row["Đáp án"].ToString() : "";

                    // Process the data (e.g., print to console, store in a database, etc.)
                    Console.WriteLine($"Question ID: {questionId}, Question: {question}, Options: A={optionA}, B={optionB}, C={optionC}, D={optionD}, Answer: {answer}");
                }
            }
        }
    }
}
