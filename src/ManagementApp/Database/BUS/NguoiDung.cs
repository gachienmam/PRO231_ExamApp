﻿using ServerDatabaseLibrary.Database.DTO;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp.Database.BUS
{
    public class NguoiDung
    {
        private readonly DAL.NguoiDung _DAL_NguoiDung;

        public NguoiDung(DAL.NguoiDung NguoiDung)
        {
            _DAL_NguoiDung = NguoiDung;
        }

        public DataTable GetNguoiDungByMaNguoiDung(string MaNguoiDung)
        {
            return _DAL_NguoiDung.GetNguoiDungByMaNguoiDung(MaNguoiDung);
        }
    }
}