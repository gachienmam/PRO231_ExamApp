using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office.SpreadSheetML.Y2023.MsForms;
using ExamLibrary.Question;

namespace ExamServer.Database.BUS
{
    internal class DeThi
    {
        Database.DAL.DeThi dalDeThi = new Database.DAL.DeThi();

        public ExamLibrary.Question.Paper GetDeThiFromID()
        {
            return null;
        }

        public bool SetDeThiState(string examId)
        {
            return false;
        }
    }
}
