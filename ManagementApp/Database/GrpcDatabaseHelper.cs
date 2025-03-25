using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static ManagementApp.AdminProto.AdminService;
using ManagementApp.AdminProto;
using ExamLibrary.Enum;
using ReaLTaiizor.Controls;
using System.Net;
using System.Windows.Forms;

namespace ManagementApp.Database
{
    public class GrpcDatabaseHelper
    {
        private readonly AdminServiceClient _client;
        private readonly string _accessToken;
        private readonly Grpc.Core.Metadata _headers;

        public GrpcDatabaseHelper(AdminServiceClient client, string accessToken)
        {
            _client = client;
            _accessToken = accessToken;
            _headers = new Grpc.Core.Metadata
                {
                    { "Authorization", $"Bearer {_accessToken}" }
                };
        }

        // Cho phép trực tiếp chạy lệnh SQL (lệnh từ phần mềm quản lý)
        public async Task<int> ExecuteSqlNonQueryAsync(string sqlCommand)
        {
            if (string.IsNullOrWhiteSpace(sqlCommand))
            {
                throw new ArgumentException("SQL command cannot be null or empty.", nameof(sqlCommand));
            }

            try
            {
                var request = new CommandRequest()
                {
                    RequestCode = (int)RemoteCommandType.SQL_NONQUERY,
                    Command = sqlCommand
                };

                var response = await _client.ExecuteRemoteCommandAsync(request, _headers);

                if (response.ResponseCode == (int)HttpStatusCode.OK)
                {
                    int result = 0;
                    int.TryParse(response.ResponseMessage, out result);
                    return result;
                }
                else
                {
                    //CrownMessageBox.ShowError($"Lỗi: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    return -1;
                }
            }
            catch (Exception ex)
            {
                //CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                return -1;
            }
        }

        public async Task<object> ExecuteSqlScalarAsync(string sqlCommand)
        {
            if (string.IsNullOrWhiteSpace(sqlCommand))
            {
                throw new ArgumentException("SQL command cannot be null or empty.", nameof(sqlCommand));
            }

            try
            {
                var request = new CommandRequest()
                {
                    RequestCode = (int)RemoteCommandType.SQL_NONQUERY,
                    Command = sqlCommand
                };

                var response = await _client.ExecuteRemoteCommandAsync(request, _headers);

                if (response.ResponseCode == (int)HttpStatusCode.OK)
                {
                    int result = 0;
                    int.TryParse(response.ResponseMessage, out result);
                    return result;
                }
                else
                {
                    //CrownMessageBox.ShowError($"Lỗi: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    return $"Error: {response.ResponseMessage}";
                }
            }
            catch (Exception ex)
            {
                //CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                return $"Error {ex.Message}";
            }
        }

        public async Task<DataTable> ExecuteSqlReaderAsync(string sqlCommand)
        {
            if (string.IsNullOrWhiteSpace(sqlCommand))
            {
                throw new ArgumentException("SQL command cannot be null or empty.", nameof(sqlCommand));
            }

            try
            {
                var request = new CommandRequest()
                {
                    RequestCode = (int)RemoteCommandType.SQL_NONQUERY,
                    Command = sqlCommand
                };

                var response = await _client.ExecuteRemoteCommandAsync(request, _headers);

                if (response.ResponseCode == (int)HttpStatusCode.OK)
                {
                    DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(response.ResponseMessage);
                    //DataTable dataTable = ConvertToDataTable(response.ResponseMessage);
                    if (dataTable == null)
                    {
                        //CrownMessageBox.ShowError($"Lỗi khi hiển thị bảng: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                        return ConvertToDataTable($"Error\r\n{response.ResponseMessage}");
                    }
                    return dataTable;
                }
                else
                {
                    //CrownMessageBox.ShowError($"Lỗi: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    return ConvertToDataTable($"Error\r\n{response.ResponseMessage}");
                }
            }
            catch (Exception ex)
            {
                //CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                return ConvertToDataTable($"Error\r\n{ex.Message}");
            }
        }
        private DataTable ConvertToDataTable(string data)
        {
            DataTable dataTable = new DataTable();
            string[] rows = data.Split('\n');
            if (rows.Length > 0)
            {
                string[] headers = rows[0].Split(',');
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }

                for (int i = 1; i < rows.Length; i++)
                {
                    string[] cells = rows[i].Split(',');
                    dataTable.Rows.Add(cells);
                }
            }
            return dataTable;
        }
    }
}
