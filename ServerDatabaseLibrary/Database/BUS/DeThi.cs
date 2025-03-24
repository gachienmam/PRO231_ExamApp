using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDatabaseLibrary.Database.BUS
{
    public class DeThi
    {
        private readonly DAL.DeThi _DAL_deThi;

        public DeThi(DAL.DeThi deThi)
        {
            _DAL_deThi = deThi;
        }

        public DataTable GetDeThiFromMaDe(string MaDe)
        {
            return null;
        }

        public bool SetDeThiState(string examId)
        {
            return false;
        }
    }
}
