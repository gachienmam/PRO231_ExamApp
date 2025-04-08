using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServerDatabaseLibrary.Database
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Chạy lệnh SQL trả về dữ liệu (SELECT, ...)
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    return dataTable;
                }
            }
        }

        // Chạy lệnh SQL không trả về dữ liệu (INSERT, UPDATE, DELETE, ...)
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        // Cho phép trực tiếp chạy lệnh SQL (lệnh từ phần mềm quản lý)
        public async Task<int> ExecuteSqlNonQueryAsync(string sqlCommand)
        {
            if (string.IsNullOrWhiteSpace(sqlCommand))
            {
                throw new ArgumentException("SQL command cannot be null or empty.", nameof(sqlCommand));
            }

            await using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(sqlCommand, connection))
                {
                    try
                    {
                        return await command.ExecuteNonQueryAsync();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                        //throw;
                        return 0;
                    }
                }
            }
        }

        public async Task<object> ExecuteSqlScalarAsync(string sqlCommand)
        {
            if (string.IsNullOrWhiteSpace(sqlCommand))
            {
                throw new ArgumentException("SQL command cannot be null or empty.", nameof(sqlCommand));
            }

            await using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(sqlCommand, connection))
                {
                    try
                    {
                        return await command.ExecuteScalarAsync();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public async Task<string> ExecuteSqlReaderAsync(string sqlCommand)
        {
            if (string.IsNullOrWhiteSpace(sqlCommand))
            {
                return "SQL command cannot be null or empty. " + nameof(sqlCommand);
            }

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                var command = new SqlCommand(sqlCommand, connection);
                SqlDataReader result = await command.ExecuteReaderAsync(System.Data.CommandBehavior.CloseConnection);
                return SerializeDataReader(result);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    await connection.CloseAsync();
                }
                return $"SQL Error: {ex.Message}";
            }
        }


        // Chuyển dữ liệu SQL sang JSON
        private string SerializeDataReader(SqlDataReader reader)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            while (reader.Read())
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.GetValue(i);
                }
                rows.Add(row);
            }
            return JsonConvert.SerializeObject(rows);
        }
    }
}
