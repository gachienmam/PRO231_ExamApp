using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamServer.Database.DAL
{
    public class NguoiDung
    {
        private readonly DatabaseHelper _dbHelper;

        public NguoiDung(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public DataTable GetUserByUsername(string username)
        {
            string query = "SELECT * FROM NguoiDung WHERE MaNguoiDung = @MaNguoiDung";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNguoiDung", username)
            };

            return _dbHelper.ExecuteQuery(query, parameters);
        }
    }
}
