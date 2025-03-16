using ExamLibrary;
using ExamLibrary.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace ExamServer.Helper
{
    public class ExcelExamPaper
    {
        private XLWorkbook _workbook;
        
        public ExcelExamPaper(XLWorkbook workbook)
        {
            _workbook = workbook;
        }

        public Task<Paper> GetExam(string fileLocation)
        {
            Paper paper = new Paper();
            var InfoSheet = _workbook.Worksheet(1);
            paper.ExamCode = InfoSheet.Cell("F4").GetValue<string>();
            paper.Duration = InfoSheet.Cell("I4").GetValue<int>();

            // Multiple choice
            InfoSheet.Table("ModuleInfoTable")
        }

        public  GetMultipleChoice()
        {

        }
    }
}
