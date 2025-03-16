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
        private readonly DAL.DeThi _DAL_deThi;

        public DeThi(DAL.DeThi deThi)
        {
            _DAL_deThi = deThi;
        }

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
