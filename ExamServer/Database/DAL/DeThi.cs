using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamServer.Database.DAL
{
    public class DeThi
    {
        private readonly DatabaseHelper _dbHelper;

        public DeThi(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool InsertDeThi(string examId, string userId, string password, DateTime startTime, DateTime endTime, int status, string questionList, string fileLocation)
        {
            string query = @"INSERT INTO DeThi (MaDe, MaNguoiDung, MatKhau, ThoiGianBatDau, ThoiGianKetThuc, TrangThai, DanhSachThi, ViTriFileDe) 
                             VALUES (@MaDe, @MaNguoiDung, @MatKhau, @ThoiGianBatDau, @ThoiGianKetThuc, @TrangThai, @DanhSachThi, @ViTriFileDe)";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDe", examId),
                    new SqlParameter("@MaNguoiDung", userId),
                    new SqlParameter("@MatKhau", password),
                    new SqlParameter("@ThoiGianBatDau", startTime),
                    new SqlParameter("@ThoiGianKetThuc", endTime),
                    new SqlParameter("@TrangThai", status),
                    new SqlParameter("@DanhSachThi", questionList),
                    new SqlParameter("@ViTriFileDe", fileLocation)
                };

                _dbHelper.ExecuteNonQuery(query, parameters);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
