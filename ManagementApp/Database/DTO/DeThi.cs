using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDatabaseLibrary.Database.DTO
{
    public class DeThi
    {
        [MaxLength(50)]
        public string MaDe { get; set; }

        [MaxLength(50)]
        public string MaNguoiDung { get; set; }

        [MaxLength(255)]
        public string MatKhau { get; set; }

        public DateTime ThoiGianBatDau { get; set; }

        public DateTime ThoiGianKetThuc { get; set; }

        public int TrangThai { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string? DanhSachThi { get; set; }

        public string ViTriFileDe { get; set; }

        public DeThi(string maDe, string maNguoiDung, string matKhau, DateTime tgBatDau, DateTime tgKetThuc, int trangThai, string danhSachThi, string viTriFileDe)
        {
            MaDe = maDe;
            MaNguoiDung = maNguoiDung;
            MatKhau = matKhau;
            ThoiGianBatDau = tgBatDau;
            ThoiGianKetThuc = tgKetThuc;
            TrangThai = trangThai;
            DanhSachThi = danhSachThi;
            ViTriFileDe = viTriFileDe;
        }

        public DeThi(string maDe, string maNguoiDung, string matKhau, DateTime tgBatDau, DateTime tgKetThuc, int trangThai, string viTriFileDe)
        {
            MaDe = maDe;
            MaNguoiDung = maNguoiDung;
            MatKhau = matKhau;
            ThoiGianBatDau = tgBatDau;
            ThoiGianKetThuc = tgKetThuc;
            TrangThai = trangThai;
            ViTriFileDe = viTriFileDe;
        }
    }
}
