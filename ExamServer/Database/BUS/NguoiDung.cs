using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamServer.Database.BUS
{
    internal class NguoiDung
    {
        private readonly DAL.NguoiDung _DAL_NguoiDung;

        public NguoiDung(DAL.NguoiDung NguoiDung)
        {
            _DAL_NguoiDung = NguoiDung;
        }


    }
}
