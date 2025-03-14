using ExamLibrary.Enum;
using ExamServer.AdminExamService;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamServer.Services
{
    internal class AdminExamServiceImpl
    {
        private readonly string _uploadPath = "ExamPapers/";

        private readonly ILogger<AdminExamServiceImpl> _logger;
        // Thay bằng BUS
        //private readonly ExamDbContext _dbContext; // Assuming EF Core for SQL Server
        private Database.BUS.DeThi _busDeThi = new Database.BUS.DeThi();
        private JWTService _jwtService;

        public AdminExamServiceImpl(ILogger<AdminExamServiceImpl> logger/*, ExamDbContext dbContext*/)
        {
            _logger = logger;
            //_dbContext = dbContext;
        }

        public async Task<AdminExamService.AuthResponse> AuthenticateUser(AdminExamService.AuthRequest request, ServerCallContext context)
        {
            // Validate user (simplified example)
            //var user = await _dbContext.Users
            //    .FirstOrDefaultAsync(u => u.Username == request.Username && u.Password == request.Password);

            if (request.Username == null)
            {
                return new AdminExamService.AuthResponse { ResponseCode = 401, ResponseMessage = "Invalid credentials" };
            }

            string token = _jwtService.GenerateJwtToken(request.Username, user.VaiTro); // Implement token generation
            return new AdminExamService.AuthResponse { ResponseCode = 200, ResponseMessage = "Success", Token = token };
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
                return new UploadResponse { ResponseCode = (int)GenericResponse.UPLOAD_SUCCESS, ResponseMessage = "File uploaded successfully" };
            }
            catch (Exception ex)
            {
                return new UploadResponse { ResponseCode = (int)GenericResponse.UPLOAD_FAILED, ResponseMessage = $"Error: {ex.Message}" };
            }
        }

        [Authorize]
        public async Task<CommandResponse> ExecuteRemoteCommand(CommandRequest request, ServerCallContext context)
        {
            var user = context.GetHttpContext().User;
            if (!user.IsInRole("Admin"))
            {
                throw new RpcException(new Status(StatusCode.PermissionDenied, "Access denied"));
            }

            // Execute command logic...
            return new CommandResponse { ResponseCode = (int)GenericResponse.CMD_SUCCESS, ResponseMessage = "Command executed successfully" };
        }
    }
}