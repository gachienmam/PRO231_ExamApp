using ServerDatabaseLibrary.Database.DTO;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp.Database.DAL
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
            string query = $"SELECT * FROM NguoiDung WHERE MaNguoiDung = {MaNguoiDung}";
            return (int)_dbHelper.ExecuteSqlScalarAsync(query);
        }
        public bool DeleteNguoiDung(string MaNguoiDung)
        {
            string query = $"EXEC sp_DeleteNguoiDung {MaNguoiDung}";
            return (int)_dbHelper.ExecuteSqlScalarAsync(query);
        }
        public bool InsertNguoiDung(string MaNguoiDung, string hoTen, string email, string matKhau, string vaiTro)
        {
            string query = $"EXEC sp_InsertNguoiDung N'{MaNguoiDung}', N'{hoTen}', N'{email}', N'{matKhau}', N'{vaiTro}'";
            return (int)_dbHelper.ExecuteSqlScalarAsync(query);
        }
        public bool UpdateNguoiDung(string MaNguoiDung, string hoTen, string email, string matKhau, string vaiTro)
        {
            string query = $"EXEC sp_UpdateNguoiDung N'{MaNguoiDung}', N'{hoTen}', N'{email}', N'{matKhau}', N'{vaiTro}'";
            return (int)_dbHelper.ExecuteSqlScalarAsync(query);
        }
        public DataTable GetNguoiDungByVaiTro(string vaiTro)
        {
            string query = $"EXEC sp_DanhSachNguoiDung {vaiTro}";
            return (int)_dbHelper.ExecuteSqlScalarAsync(query);
        }

    }
}