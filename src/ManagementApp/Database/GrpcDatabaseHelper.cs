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
        private readonly Grpc.Core.Metadata _headers;

        public GrpcDatabaseHelper(AdminServiceClient client, Grpc.Core.Metadata headers)
        {
            _client = client;
            _headers = headers;
        }

        #region Async
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
                    RequestCode = (int)RemoteCommandType.SQL_SCALAR,
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
                    RequestCode = (int)RemoteCommandType.SQL_READER,
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
                        return new DataTable().Columns.Add("Exception").Table.Rows.Add(response.ResponseMessage).Table;
                    }
                    return dataTable;
                }
                else
                {
                    //CrownMessageBox.ShowError($"Lỗi: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    return new DataTable().Columns.Add("Exception").Table.Rows.Add( response.ResponseMessage).Table;
                }
            }
            catch (Exception ex)
            {
                //CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                return new DataTable().Columns.Add("Exception").Table.Rows.Add(ex.Message).Table;
            }
        }
        #endregion

        #region Non-Async
        // Cho phép trực tiếp chạy lệnh SQL (lệnh từ phần mềm quản lý)
        public int ExecuteSqlNonQuery(string sqlCommand)
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

                var response = _client.ExecuteRemoteCommand(request, _headers);

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

        public object ExecuteSqlScalar(string sqlCommand)
        {
            if (string.IsNullOrWhiteSpace(sqlCommand))
            {
                throw new ArgumentException("SQL command cannot be null or empty.", nameof(sqlCommand));
            }

            try
            {
                var request = new CommandRequest()
                {
                    RequestCode = (int)RemoteCommandType.SQL_SCALAR,
                    Command = sqlCommand
                };

                var response = _client.ExecuteRemoteCommand(request, _headers);

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

        public DataTable ExecuteSqlReader(string sqlCommand)
        {
            if (string.IsNullOrWhiteSpace(sqlCommand))
            {
                throw new ArgumentException("SQL command cannot be null or empty.", nameof(sqlCommand));
            }

            try
            {
                var request = new CommandRequest()
                {
                    RequestCode = (int)RemoteCommandType.SQL_READER,
                    Command = sqlCommand
                };

                var response = _client.ExecuteRemoteCommand(request, _headers);

                if (response.ResponseCode == (int)HttpStatusCode.OK)
                {
                    DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(response.ResponseMessage);
                    //DataTable dataTable = ConvertToDataTable(response.ResponseMessage);
                    if (dataTable == null)
                    {
                        //CrownMessageBox.ShowError($"Lỗi khi hiển thị bảng: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                        return new DataTable().Columns.Add("Exception").Table.Rows.Add(response.ResponseMessage).Table;
                    }
                    return dataTable;
                }
                else
                {
                    //CrownMessageBox.ShowError($"Lỗi: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    return new DataTable().Columns.Add("Exception").Table.Rows.Add(response.ResponseMessage).Table;
                }
            }
            catch (Exception ex)
            {
                //CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                return new DataTable().Columns.Add("Exception").Table.Rows.Add(ex.Message).Table;
            }
        }
        #endregion
    }
}
