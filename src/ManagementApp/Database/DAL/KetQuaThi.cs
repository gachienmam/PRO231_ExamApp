using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ManagementApp.Database.DAL
{
    public class KetQuaThi
    {
        private readonly GrpcDatabaseHelper _dbHelper;

        public KetQuaThi(GrpcDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public DataTable GetBangDiem(string maDe)
        {
            string query = "EXEC sp_BangDiem @MaDe";
            return (int)_dbHelper.ExecuteSqlScalarAsync(query);
        }
       
        public DataTable GetBangDiemTheoMaDe(string maDe)  // Đổi tên phương thức
        {
            string query = $"EXEC sp_BangDiem {maDe}";

            return (int)_dbHelper.ExecuteSqlScalarAsync(query);
        }


    }
}
