using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerDatabaseLibrary.Database.DTO;

namespace ServerDatabaseLibrary.Database.DAL
{
    public class ThiSinh
    {
        private readonly DatabaseHelper _dbHelper;

        public ThiSinh(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public DataTable GetThiSinhByMaThiSinh(string maThiSinh)
        {
            string query = "SELECT * FROM ThiSinh WHERE MaThiSinh = @MaThiSinh";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaThiSinh", maThiSinh)
            };

            return _dbHelper.ExecuteQuery(query, parameters);
        }
        public bool DeleteThiSinh(string maThiSinh)
        {
            string query = "EXEC sp_DeleteThiSinh @MaThiSinh";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaThiSinh", maThiSinh)
                };

                _dbHelper.ExecuteNonQuery(query, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi xóa thí sinh: {ex.Message}");
                return false;
            }
        }
        public bool InsertThiSinh(string maThiSinh, string hoTen, string email, string matKhau, DateTime ngaySinh, string soDienThoai, int trangThai)
        {
            string query = "EXEC sp_InsertThiSinh @MaThiSinh, @HoTen, @Email, @MatKhau, @NgaySinh, @SoDienThoai, @TrangThai";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaThiSinh", maThiSinh),
                    new SqlParameter("@HoTen", hoTen),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@MatKhau", matKhau),
                    new SqlParameter("@NgaySinh", ngaySinh),
                    new SqlParameter("@SoDienThoai", soDienThoai),
                    new SqlParameter("@TrangThai", trangThai)
                };

                _dbHelper.ExecuteNonQuery(query, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi thêm thí sinh: {ex.Message}");
                return false;
            }
        }
        public bool UpdateThiSinh(string maThiSinh, string hoTen, string email, string matKhau, DateTime ngaySinh, string soDienThoai, int trangThai)
        {
            string query = "EXEC sp_UpdateThiSinh @MaThiSinh, @HoTen, @Email, @MatKhau, @NgaySinh, @SoDienThoai, @TrangThai";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaThiSinh", maThiSinh),
                    new SqlParameter("@HoTen", hoTen),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@MatKhau", matKhau),
                    new SqlParameter("@NgaySinh", ngaySinh),
                    new SqlParameter("@SoDienThoai", soDienThoai),
                    new SqlParameter("@TrangThai", trangThai)
                };

                _dbHelper.ExecuteNonQuery(query, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật thí sinh: {ex.Message}");
                return false;
            }
        }
        public DataTable GetDanhSachThiSinh(int trangThai)
        {
            string query = "EXEC sp_DanhSachThiSinh @TrangThai";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@TrangThai", trangThai)
                };

                return _dbHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy danh sách thí sinh: {ex.Message}");
                return null;
            }
        }

    }
}
