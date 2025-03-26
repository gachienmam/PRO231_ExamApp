using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDatabaseLibrary.Database.BUS
{
    public class ThiSinh
    {
        private readonly DAL.ThiSinh _DAL_ThiSinh;

        public ThiSinh(DAL.ThiSinh ThiSinh)
        {
            _DAL_ThiSinh = ThiSinh;
        }
        public bool InsertThiSinh(DTO.ThiSinh ThiSinh)
        {
            _DAL_ThiSinh.InsertThiSinh(ThiSinh.MaThiSinh, ThiSinh.HoTen, ThiSinh.Email, ThiSinh.MatKhau, ThiSinh.NgaySinh.ToDateTime(TimeOnly.MinValue), ThiSinh.SoDienThoai, ThiSinh.TrangThai);
            return true;
        }
        public bool UpdateThiSinh(DTO.ThiSinh ThiSinh)
        {
            _DAL_ThiSinh.UpdateThiSinh(ThiSinh.MaThiSinh, ThiSinh.HoTen, ThiSinh.Email, ThiSinh.MatKhau, ThiSinh.NgaySinh.ToDateTime(TimeOnly.MinValue), ThiSinh.SoDienThoai, ThiSinh.TrangThai);
            return true;
        }
        public bool DeleteThiSinh(DTO.ThiSinh ThiSinh)
        {
            _DAL_ThiSinh.DeleteThiSinh(ThiSinh.MaThiSinh);
            return true;
        }
        public bool GetDanhSachThiSinh(DTO.ThiSinh ThiSinh)
        {
            return true;
        }
    }
}
