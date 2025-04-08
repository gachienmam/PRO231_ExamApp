using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDatabaseLibrary.Database.DTO
{
    public class ThiSinh
    {
        public ThiSinh(string maThiSinh, string hoTen, string email, string matKhau, DateOnly ngaySinh, string soDienThoai, int trangThai)
        {
            MaThiSinh = maThiSinh;
            HoTen = hoTen;
            Email = email;
            MatKhau = matKhau;
            NgaySinh = ngaySinh;
            SoDienThoai = soDienThoai;
            TrangThai = trangThai;
        }

        [MaxLength(50)]
        public string MaThiSinh { get; set; }

        [MaxLength(50)]
        public string HoTen { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string MatKhau { get; set; }

        public DateOnly NgaySinh {  get; set; }

        [MaxLength(15)]
        public string SoDienThoai {  get; set; }

        public int TrangThai { get; set; }
    }
}
