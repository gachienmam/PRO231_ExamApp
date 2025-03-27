using ServerDatabaseLibrary.Database.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ServerDatabaseLibrary.Database.BUS
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

        public DataTable GetNguoiDungByEmail(string email)
        {
            return _DAL_NguoiDung.GetNguoiDungByEmail(email);
        }

        public bool InsertNguoidung(DTO.NguoiDung NguoiDung)
        {
            _DAL_NguoiDung.InsertNguoiDung(NguoiDung.MaNguoiDung, NguoiDung.HoTen, NguoiDung.Email, NguoiDung.MatKhau, NguoiDung.VaiTro);
            return true;
        }
        public bool UpdateNguoidung(DTO.NguoiDung NguoiDung)
        {
            _DAL_NguoiDung.UpdateNguoiDung(NguoiDung.MaNguoiDung, NguoiDung.HoTen, NguoiDung.Email, NguoiDung.MatKhau, NguoiDung.VaiTro);
            return true;
        }
        public bool DeleteNguoidung(DTO.NguoiDung NguoiDung)
        {
            _DAL_NguoiDung.DeleteNguoiDung(NguoiDung.MaNguoiDung);
            return true;
        }
        
    }
}