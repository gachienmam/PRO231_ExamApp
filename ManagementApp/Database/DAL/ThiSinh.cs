
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerDatabaseLibrary.Database.DTO;

namespace ManagementApp.Database.DAL
{
    public class ThiSinh
    {
        private readonly GrpcDatabaseHelper _dbHelper;

        public ThiSinh(GrpcDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public DataTable GetUserByUsername(string studenId)
        {
            string query = $"SELECT * FROM ThiSinh WHERE MaThiSing = {studenId}";
            return (int)_dbHelper.ExecuteSqlScalarAsync(query);
        }
        public bool DeleteThiSinh(string maThiSinh)
        {
            string query = $"EXEC sp_DeleteThiSinh {maThiSinh}";
            return (int)_dbHelper.ExecuteSqlScalarAsync(query);

        }
        public bool InsertThiSinh(string maThiSinh, string hoTen, string email, string matKhau, DateTime ngaySinh, string soDienThoai, int trangThai)
        {
            string query = $"EXEC sp_InsertThiSinh N'{maThiSinh}', N'{hoTen}', N'{email}', N'{matKhau}', '{ngaySinh}', N'{soDienThoai}', {trangThai}";
            return (int)_dbHelper.ExecuteSqlScalarAsync(query);

        }
        public bool UpdateThiSinh(string maThiSinh, string hoTen, string email, string matKhau, DateTime ngaySinh, string soDienThoai, int trangThai)
        {
            string query =  $"EXEC sp_UpdateThiSinh N'{maThiSinh}', N'{hoTen}', N'{email}', N'{matKhau}', '{ngaySinh}', N'{soDienThoai}', {trangThai}";

            return (int)_dbHelper.ExecuteSqlScalarAsync(query);
            
        }
        public DataTable GetDanhSachThiSinh(int trangThai)
        {
            string query = $"EXEC sp_DanhSachThiSinh {trangThai}";
            return (int)_dbHelper.ExecuteSqlScalarAsync(query);

        }

    }
}
