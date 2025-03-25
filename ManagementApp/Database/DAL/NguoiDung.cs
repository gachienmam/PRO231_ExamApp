using ServerDatabaseLibrary.Database.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDatabaseLibrary.Database.DAL
{
    public class NguoiDung
    {
        private readonly GrpcDatabaseHelper _dbHelper;

        public NguoiDung(GrpcDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public DataTable GetNguoiDungByMaNguoiDung(string MaNguoiDung)
        {
            string query = "SELECT * FROM NguoiDung WHERE MaNguoiDung = @MaNguoiDung";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNguoiDung", MaNguoiDung)
            };

            return _dbHelper.ExecuteQuery(query, parameters);
        }
        public bool DeleteNguoiDung(string MaNguoiDung)
        {
            string query = "EXEC sp_DeleteNguoiDung @MaNguoiDung";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNguoiDung", MaNguoiDung)
                };

                _dbHelper.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi xóa người dùng: {ex.Message}");
                return false;
            }
            return true;
        }
        public bool InsertNguoiDung(string MaNguoiDung, string hoTen, string email, string matKhau, string vaiTro)
        {
            string query = "EXEC sp_InsertNguoiDung @MaNguoiDung, @HoTen, @Email, @MatKhau, @VaiTro";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNguoiDung", MaNguoiDung),
                    new SqlParameter("@HoTen", hoTen),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@MatKhau", matKhau),
                    new SqlParameter("@VaiTro", vaiTro)
                };

                _dbHelper.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi thêm người dùng: {ex.Message}");
                return false;
            }
            return true;
        }
        public bool UpdateNguoiDung(string MaNguoiDung, string hoTen, string email, string matKhau, string vaiTro)
        {
            string query = "EXEC sp_UpdateNguoiDung @MaNguoiDung, @HoTen, @Email, @MatKhau, @VaiTro";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNguoiDung", MaNguoiDung),
                    new SqlParameter("@HoTen", hoTen),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@MatKhau", matKhau),
                    new SqlParameter("@VaiTro", vaiTro)
                };

                _dbHelper.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật người dùng: {ex.Message}");
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