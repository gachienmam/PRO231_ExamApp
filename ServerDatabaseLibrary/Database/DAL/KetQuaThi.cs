using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ServerDatabaseLibrary.Database.DAL
{
    public class KetQuaThi
    {
        private readonly DatabaseHelper _dbHelper;

        public KetQuaThi(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        
        public bool InsertKetQuaThi(string maThiSinh, string maDe, float diem, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, bool daHoanThanh)
        {
            string query = "EXEC sp_InsertKetQuaThi @MaThiSinh, @MaDe, @Diem, @ThoiGianBatDau, @ThoiGianKetThuc, @DaHoanThanh";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaThiSinh", maThiSinh),
                    new SqlParameter("@MaDe", maDe),
                    new SqlParameter("@Diem", diem),
                    new SqlParameter("@ThoiGianBatDau", thoiGianBatDau),
                    new SqlParameter("@ThoiGianKetThuc", thoiGianKetThuc.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@DaHoanThanh", daHoanThanh)
                };

                _dbHelper.ExecuteNonQuery(query, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi thêm kết quả thi: {ex.Message}");
                return false;
            }
        }

        public bool UpdateKetQuaThi(string maThiSinh, string maDe, float diem, DateTime thoiGianKetThuc, bool daHoanThanh)
        {
            string query = "UPDATE KetQuaThi SET Diem = @Diem, ThoiGianKetThuc = @ThoiGianKetThuc, DaHoanThanh = @DaHoanThanh WHERE MaDe = @MaDe AND MaThiSinh = @MaThiSinh;";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaThiSinh", maThiSinh),
                    new SqlParameter("@MaDe", maDe),
                    new SqlParameter("@Diem", diem),
                    new SqlParameter("@ThoiGianKetThuc", thoiGianKetThuc.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@DaHoanThanh", daHoanThanh)
                };

                _dbHelper.ExecuteNonQuery(query, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật kết quả thi: {ex.Message}");
                return false;
            }
        }

        public DataTable GetBangDiemTheoMaDe(string maDe)  // Đổi tên phương thức
        {
            string query = "EXEC sp_BangDiem @MaDe";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDe", maDe)
                };

                return _dbHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy bảng điểm: {ex.Message}");
                return null;
            }
        }


    }
}
