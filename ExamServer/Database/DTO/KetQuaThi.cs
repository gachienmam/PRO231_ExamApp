using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamServer.Database.DTO
{
    internal class KetQuaThi
    {
        public KetQuaThi(string maThiSinh, string maDe, float diem, DateTime tgBatDau, DateTime tgKetThuc)
        {
            MaThiSinh = maThiSinh;
            MaDe = maDe;
            Diem = diem;
            ThoiGianBatDau = tgBatDau;
            ThoiGianKetThuc = tgKetThuc;
        }

        public int MaKetQua {  get; set; }

        [MaxLength(50)]
        public string MaThiSinh { get; set; }

        [MaxLength(50)]
        public string MaDe { get; set; }

        public float Diem {  get; set; }

        public DateTime ThoiGianBatDau { get; set; }

        public DateTime ThoiGianKetThuc { get; set; }

    }
}
