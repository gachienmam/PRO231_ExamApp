using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ExamServer.Database.DAL
{
    internal class KetQuaThi
    {
        private readonly DatabaseHelper _dbHelper;

        public KetQuaThi(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public DataTable GetBangDiem(string maDe)
        {
            string query = "EXEC sp_BangDiem @MaDe";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaDe", maDe)
            };

            return _dbHelper.ExecuteQuery(query, parameters);
        }

    }
}
