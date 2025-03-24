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
    public class DeThi
    {
        private readonly DatabaseHelper _dbHelper;

        public DeThi(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool InsertDeThi(string examId, string userId, string password, DateTime startTime, DateTime endTime, int status, string examList, string fileLocation)
        {
            string query = "EXEC sp_InsertDeThi @MaDe, @MaNguoiDung, @MatKhau, @ThoiGianBatDau, @ThoiGianKetThuc, @TrangThai, @DanhSachThi, @ViTriFileDe";
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
                    new SqlParameter("@DanhSachThi", examList),
                    new SqlParameter("@ViTriFileDe", fileLocation)
                };

                int rowsAffected = _dbHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"Lỗi thêm đề thi: {ex.Message}"); 
                return false;
            }
        }
        public bool UpdateDeThi(string examId, string userId, string password, DateTime startTime, DateTime endTime, int status, string examList, string fileLocation)
        {
            string query = "EXEC sp_UpdateDeThi @MaDe, @MaNguoiDung, @MatKhau, @ThoiGianBatDau, @ThoiGianKetThuc, @TrangThai, @DanhSachThi, @ViTriFileDe";

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
                    new SqlParameter("@DanhSachThi", examList),
                    new SqlParameter("@ViTriFileDe", fileLocation)
                };

                int rowsAffected = _dbHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật đề thi: {ex.Message}");
                return false; 
            }
        }

        public bool DeleteDeThi(string examId)
        {
            string query = "EXEC sp_DeleteDeThi @MaDe";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaDe", examId)
                };

                _dbHelper.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi xóa đề thi: {ex.Message}");
                return false;
            }
            return true;
        }

        public DataTable GetNguoiDungByVaiTro(string vaiTro)
        {
            string query = "EXEC sp_DanhSachNguoiDung @VaiTro";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@VaiTro", vaiTro)
                };

                return _dbHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy danh sách người dùng: {ex.Message}");
                return null;
            }
        }

    }
}
