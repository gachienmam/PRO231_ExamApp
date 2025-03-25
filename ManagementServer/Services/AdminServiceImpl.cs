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
            var userTable = await Task.Run(() => _busNguoiDung.GetNguoiDungByMaNguoiDung(request.Email));
            var user = await Task.Run(() => JArray.FromObject(userTable)[0].ToObject<ServerDatabaseLibrary.Database.DTO.NguoiDung>());
            if (user == null || !PasswordEncryption.VerifyPassword(request.Password, user.MatKhau))
            {
                return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Invalid credentials" };
            }

            string token = _jwtHelper.GenerateJwtToken(user); // Implement token generation

            //string token = _jwtHelper.GenerateJwtToken(new ServerDatabaseLibrary.Database.DTO.NguoiDung(request.Email, "Joe Biden", "ND001", "Pass", "Admin"));

            return new AuthResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = "Success", AccessToken = token };
        }

        [Authorize(Roles = "Admin, GiangVien")]
        public override async Task<UploadResponse> UploadExamPaper(IAsyncStreamReader<UploadExamFileChunk> requestStream, ServerCallContext context)
        {
            string examId = null;
            string filePath = null;
            FileStream fileStream = null;

            try
            {
                await foreach (var chunk in requestStream.ReadAllAsync())
                {
                    if (examId == null)
                    {
                        examId = chunk.ExamId;
                        Directory.CreateDirectory(_uploadPath);
                        filePath = Path.Combine(_uploadPath, $"{examId}.xlsx");
                        fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    }

                    await fileStream.WriteAsync(chunk.Data.ToByteArray(), 0, chunk.Data.Length);

                    if (chunk.IsLastChunk)
                    {
                        break;
                    }
                }

                fileStream?.Close();
                return new UploadResponse { ResponseCode = (int)StatusCode.OK, ResponseMessage = $"File uploaded successfully at: {filePath}" };
            }
            catch (Exception ex)
            {
                return new UploadResponse { ResponseCode = (int)StatusCode.Internal, ResponseMessage = $"Error: {ex.Message}" };
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
                    Console.WriteLine($"SQL_NONQUERY: " + result);
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
                    Console.WriteLine(result);
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
                    Console.WriteLine(json);
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