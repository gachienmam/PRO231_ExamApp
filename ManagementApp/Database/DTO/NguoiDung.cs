using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDatabaseLibrary.Database.DTO
{
    public class NguoiDung
    {
        public NguoiDung(string maNguoiDung, string hoTen, string email, string matKhau, string vaiTro)
        {
            MaNguoiDung = maNguoiDung;
            HoTen = hoTen;
            Email = email;
            MatKhau = matKhau;
            VaiTro = vaiTro;
        }

        [MaxLength(50)]
        public string MaNguoiDung { get; set; }

        [MaxLength(50)]
        public string HoTen { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string MatKhau { get; set; }

        [MaxLength(10)]
        public string VaiTro { get; set; }
    }
}
