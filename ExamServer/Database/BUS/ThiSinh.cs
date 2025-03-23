using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamServer.Database.BUS
{
    internal class ThiSinh
    {
        private readonly DAL.ThiSinh _DAL_NguoiDung;

        public ThiSinh(DAL.ThiSinh ThiSinh)
        {
            _DAL_NguoiDung = ThiSinh;
        }
    }
}
