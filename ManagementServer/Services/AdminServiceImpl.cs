using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using ManagementServer.AdminProto;
using Newtonsoft.Json.Linq;
using ExamLibrary.Enum;
using ManagementServer.Helper;
using ServerDatabaseLibrary;
using ServerDatabaseLibrary.Database;

namespace ManagementServer.Services
{
    public class AdminServiceImpl : AdminService.AdminServiceBase
    {
        #region Constructor
        private readonly string _uploadPath = "ExamPapers/";

        private readonly IConfiguration _configuration;
        private readonly ILogger<AdminServiceImpl> _logger;

        // Cho phần mềm quản lý kết nối vô để xử lý SQL trực tiếp
        private DatabaseHelper _databaseHelper;

        // Cho server
        private ServerDatabaseLibrary.Database.BUS.NguoiDung _busNguoiDung;
        private ManagementJWT _jwtHelper;

        public AdminServiceImpl(IConfiguration configuration, ILogger<AdminServiceImpl> logger)
        {
            _configuration = configuration;
            _logger = logger;

            _databaseHelper = new DatabaseHelper(_configuration.GetConnectionString("ExamDatabase") ?? "");
            _busNguoiDung = new ServerDatabaseLibrary.Database.BUS.NguoiDung(new ServerDatabaseLibrary.Database.DAL.NguoiDung(_databaseHelper));

            _jwtHelper = new ManagementJWT(_configuration);
        }
        #endregion

        public override async Task<AuthResponse> AdminAuthenticateUser(AuthRequest request, ServerCallContext context)
        {
            if (request.Email == null)
            {
                return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Invalid credentials" };
            }
            var userTable = await Task.Run(() => _busNguoiDung.GetNguoiDungByEmail(request.Email));
            if (userTable.Rows.Count > 0)
            {
                var user = await Task.Run(() => JArray.FromObject(userTable)[0].ToObject<ServerDatabaseLibrary.Database.DTO.NguoiDung>());
                if (user == null || !PasswordEncryption.VerifyPassword(request.Password, user.MatKhau))
                {
                    return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Invalid credentials" };
                }

                string token = _jwtHelper.GenerateJwtToken(user); // Implement token generation

                //string token = _jwtHelper.GenerateJwtToken(new ServerDatabaseLibrary.Database.DTO.NguoiDung(request.Email, "Joe Biden", "ND001", "Pass", "Admin"));

                return new AuthResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = "Success", AccessToken = token };
            }
            else
            {
                return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Invalid credentials" };
            }

            //string token = _jwtHelper.GenerateJwtToken(new ServerDatabaseLibrary.Database.DTO.NguoiDung(request.Email, "Joe Biden", "ND001", "Pass", "Admin"));

            //return new AuthResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = "Success", AccessToken = token };
        }

        [Authorize(Roles = "Admin, GiangVien")]
        public override async Task<UploadResponse> UploadExamPaper(IAsyncStreamReader<UploadExamFileChunk> requestStream, ServerCallContext context)
        {
            try
            {
                _logger.LogInformation("Received UploadExamPaper request from client.");

                string examId = string.Empty; // Initialize examId
                string fileNamePrefix = $"exam_";
                string filePath = string.Empty;

                while (await requestStream.MoveNext())
                {
                    var request = requestStream.Current;
                    if (!string.IsNullOrEmpty(request.ExamId))
                    {
                        examId = request.ExamId;
                        fileNamePrefix = $"exam_{examId}";
                    }

                    if (request.Data != null)
                    {
                        if (string.IsNullOrEmpty(filePath))
                        {
                            filePath = Path.Combine(_uploadPath, $"{fileNamePrefix}.xlsx");
                        }
                        using (var fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                        {
                            var chunk = request.Data.ToByteArray();
                            _logger.LogDebug($"Received chunk of size: {chunk.Length} bytes for Exam ID: {examId}");
                            await fileStream.WriteAsync(chunk);
                        }
                    }
                    else
                    {
                        _logger.LogWarning("Received null chunk in request stream.");
                    }
                }

                _logger.LogInformation($"File saved successfully: {fileNamePrefix}");
                return new UploadResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = filePath };
            }
            catch (RpcException rpcEx)
            {
                _logger.LogError($"gRPC Error during upload: {rpcEx.Status.Detail}");
                return new UploadResponse { ResponseCode = (int)HttpStatusCode.NotFound, ResponseMessage = $"gRPC Error during exam paper upload: {rpcEx.Status.Detail}" };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during exam paper upload: {ex.Message}");
                return new UploadResponse { ResponseCode = (int)HttpStatusCode.NotFound, ResponseMessage = $"Generic error during exam paper upload: {ex.Message}" };
            }
            finally
            {
                _logger.LogInformation("UploadExamPaper request finished.");
            }


        }

        [Authorize(Roles = "Admin, GiangVien")]
        public override async Task<CommandResponse> ExecuteRemoteCommand(CommandRequest request, ServerCallContext context)
        {
            if (request.RequestCode.Equals((int)RemoteCommandType.SQL_NONQUERY))
            {
                try
                {
                    int result = await _databaseHelper.ExecuteSqlNonQueryAsync(request.Command);
                    _logger.LogInformation($"SQL_NONQUERY: " + result);
                    return new CommandResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = result.ToString() };
                }
                catch (Exception ex)
                {
                    return new CommandResponse { ResponseCode = (int)HttpStatusCode.InternalServerError, ResponseMessage = $"SQL Error: {ex.Message}"};
                }
            }
            if (request.RequestCode.Equals((int)RemoteCommandType.SQL_SCALAR))
            {
                try
                {
                    object result = await _databaseHelper.ExecuteSqlScalarAsync(request.Command);
                    _logger.LogInformation("SQL_SCALAR: " + result);
                    return new CommandResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = (string)result };
                }
                catch (Exception ex)
                {
                    return new CommandResponse { ResponseCode = (int)HttpStatusCode.InternalServerError, ResponseMessage = $"SQL Error: {ex.Message}" };
                }
            }
            if (request.RequestCode.Equals((int)RemoteCommandType.SQL_READER))
            {
                try
                {
                    string json = await _databaseHelper.ExecuteSqlReaderAsync(request.Command);
                    _logger.LogInformation("SQL_READER: " + json);
                    return new CommandResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = json };
                }
                catch (Exception ex)
                {
                    return new CommandResponse { ResponseCode = (int)HttpStatusCode.InternalServerError, ResponseMessage = $"SQL Error: {ex.Message}" };
                }
            }

            if (request.RequestCode.Equals((int)RemoteCommandType.REQUEST_ENCRYPTEDPASSWORD))
            {
                return new CommandResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = PasswordEncryption.HashPassword(request.Command) };
            }

            return new CommandResponse { ResponseCode = (int)HttpStatusCode.NotImplemented, ResponseMessage = $"Not implemented" };
        }
    }
}