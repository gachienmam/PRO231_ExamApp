using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using AdminProto;
using Newtonsoft.Json.Linq;
using ExamLibrary.Enum;
using ManagementServer.Helper;
using ServerDatabaseLibrary;
using ServerDatabaseLibrary.Database;

namespace ManagementServer.Services
{
    public class AdminServiceImpl
    {
        #region Constructor
        private readonly string _uploadPath = "ExamPapers/";

        private readonly IConfiguration _configuration;
        private readonly ILogger<AdminServiceImpl> _logger;

        // Cho phần mềm quản lý kết nối vô để xử lý SQL trực tiếp
        private DatabaseHelper _databaseHelper;

        // Cho server
        private ServerDatabaseLibrary.Database.BUS.NguoiDung _busNguoiDung;
        private PolyTestJWT _jwtHelper;

        public AdminServiceImpl(IConfiguration configuration, ILogger<AdminServiceImpl> logger)
        {
            _configuration = configuration;
            _logger = logger;

            _databaseHelper = new DatabaseHelper(_configuration.GetConnectionString("ExamDatabase") ?? "");
            _busNguoiDung = new ServerDatabaseLibrary.Database.BUS.NguoiDung(new ServerDatabaseLibrary.Database.DAL.NguoiDung(_databaseHelper));

            _jwtHelper = new PolyTestJWT(_configuration);
        }
        #endregion

        public async Task<AuthResponse> AdminAuthenticateUser(AuthRequest request, ServerCallContext context)
        {
            if (request.Email == null)
            {
                return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Invalid credentials" };
            }
            var userTable = await Task.Run(() => _busNguoiDung.GetNguoiDungByMaNguoiDung(request.Email));
            var user = await Task.Run(() => JArray.FromObject(userTable)[0].ToObject<ServerDatabaseLibrary.Database.DTO.NguoiDung>());
            if (user == null)
            {
                return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Invalid credentials" };
            }

            string token = _jwtHelper.GenerateJwtToken(request.Email, user); // Implement token generation

            return new AuthResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = "Success", AccessToken = token };
        }

        [Authorize]
        public async Task<UploadResponse> UploadExamPaper(IAsyncStreamReader<UploadExamFileChunk> requestStream, ServerCallContext context)
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

        [Authorize]
        public async Task<CommandResponse> ExecuteRemoteCommand(CommandRequest request, ServerCallContext context)
        {
            var user = context.GetHttpContext().User;
            if (!user.IsInRole("Admin") || !user.IsInRole("GiangVien"))
            {
                throw new RpcException(new Status(StatusCode.PermissionDenied, "Access denied"));
            }

            if (request.RequestCode.Equals((int)RemoteCommandType.SQL))
            {
                try
                {
                    string json = await Task.Run(() => _databaseHelper.ExecuteRawSqlQuery(request.Command));
                    return new CommandResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = json };
                }
                catch (Exception ex)
                {
                    return new CommandResponse { ResponseCode = (int)HttpStatusCode.InternalServerError, ResponseMessage = $"Error: {ex.Message}"};
                }
            }

            return new CommandResponse { ResponseCode = (int)HttpStatusCode.NotImplemented, ResponseMessage = $"Not implemented" };
        }
    }
}