using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamServer.Database.DAL
{
    internal class ThiSinh
    {
        private readonly DatabaseHelper _dbHelper;

        public ThiSinh(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public DataTable GetUserByUsername(string username)
        {
            string query = "SELECT * FROM ThiSinh WHERE MaThiSing = @MaThiSing";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaThiSing", username)
            };

            return _dbHelper.ExecuteQuery(query, parameters);
        }
    }
}
