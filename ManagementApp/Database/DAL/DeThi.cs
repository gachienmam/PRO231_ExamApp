using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ManagementApp.Database;
using System.Collections;


namespace ServerDatabaseLibrary.Database.DAL
{
    public class DeThi
    {
        private readonly GrpcDatabaseHelper _dbHelper;

        public DeThi(GrpcDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool InsertDeThi(string examId, string userId, string password, DateTime startTime, DateTime endTime, int status, string examList, string fileLocation)
        {
            string query = $"EXEC sp_InsertDeThi N'{examId}', N'{userId}', N'{password}', '{startTime}', '{endTime}', N'{status}', N'{examList}, N'{fileLocation}";
            return (int)_dbHelper.ExecuteSqlScalarAsync(query);
        }
        public bool UpdateDeThi(string examId, string userId, string password, DateTime startTime, DateTime endTime, int status, string examList, string fileLocation)
        {
            string query = $"EXEC sp_UpdateDeThi N'{examId}', N'{userId}', N'{password}', '{startTime}', '{endTime}', N'{status}', N'{examList}, N'{fileLocation}";

            return (int)_dbHelper.ExecuteSqlScalarAsync(query);
        }

        public bool DeleteDeThi(string examId)
        {
            string query = $"EXEC sp_DeleteDeThi {examId}";
            return (int)_dbHelper.ExecuteSqlScalarAsync(query);
        }

        public DataTable Getdethi(string MaDe)
        {
            string query = $"EXEC sp_DanhSachDeThi {MaDe}";
            return (int)_dbHelper.ExecuteSqlScalarAsync(query);
        }

    }
}
