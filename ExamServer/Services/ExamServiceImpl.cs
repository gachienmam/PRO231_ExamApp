using ExamServer.Helper;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ExamProto;
using ServerDatabaseLibrary.Database;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace ExamServer.Services
{
    internal class ExamServiceImpl
    {
        private readonly IMemoryCache _cache;
        //private readonly ILogger<UserExamServiceImpl> _logger;
        // Thay bằng BUS
        //private readonly ExamDbContext _dbContext; // Assuming EF Core for SQL Server
        private readonly IConfiguration _configuration;
        private readonly ILogger<ExamServiceImpl> _logger;

        // Cho phần mềm quản lý kết nối vô để xử lý SQL trực tiếp
        private DatabaseHelper _databaseHelper;

        // Cho server
        private ServerDatabaseLibrary.Database.BUS.DeThi _busDeThi;
        private ServerDatabaseLibrary.Database.BUS.ThiSinh _busThiSinh;
        private PolyTestJWT _jwtHelper;

        public ExamServiceImpl(IConfiguration configuration, ILogger<ExamServiceImpl> logger, IMemoryCache cache)
        {
            _configuration = configuration;
            _logger = logger;
            _cache = cache;

            _databaseHelper = new DatabaseHelper(_configuration.GetConnectionString("ExamDatabase") ?? "");
            _busDeThi = new ServerDatabaseLibrary.Database.BUS.DeThi(new ServerDatabaseLibrary.Database.DAL.DeThi(_databaseHelper));
            _busThiSinh = new ServerDatabaseLibrary.Database.BUS.ThiSinh(new ServerDatabaseLibrary.Database.DAL.ThiSinh(_databaseHelper));

            _jwtHelper = new PolyTestJWT(_configuration);
        }

        public async Task<AuthResponse> ExamAuthenticateUser(AuthRequest request, ServerCallContext context)
        {
            if (request.Email == null || request.Password == null)
            {
                return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Invalid credentials" };
            }
            var userTable = await Task.Run(() => _busThiSinh.Get(request.Email));
            var user = await Task.Run(() => JArray.FromObject(userTable)[0].ToObject<ServerDatabaseLibrary.Database.DTO.ThiSinh>());
            if (user == null)
            {
                return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Invalid credentials" };
            }

            string token = _jwtHelper.GenerateJwtToken(user); // Implement token generation
            return new AuthResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = "Success", AccessToken = token };
            //return new AuthResponse { ResponseCode = 200, ResponseMessage = "Success", AccessToken = ""};
        }

        [Authorize]
        public async Task<ExamData> GetExamData(ExamRequest request, ServerCallContext context)
        {
            string cacheKey = $"Exam_{request.ExamId}";

            if (!_cache.TryGetValue(cacheKey, out ExamData examData))
            {
                // Load from database if not in cache
                var examDataTable = await Task.Run(() => _busDeThi.GetDeThiFromMaDe(request.ExamId));

                // Load DeThi.ViTriFileDe from excel into usable type to return to client
                //
                //if (exam == null)
                //{
                //    return new ExamData { ResponseCode = 404 }; // Not Found
                //}

                //examData = new ExamData
                //{
                //    ResponseCode = (int)HttpStatusCode.OK,
                //    ExamPaper = ByteString.CopyFrom(exam.),
                //    //ExamForm = ByteString.CopyFrom(exam.FormData),
                //    //ExamFormSize = exam.FormData.Length,
                //    ServerInformation = ByteString.CopyFromUtf8("PolyTestExamServer_14032025")
                //};

                // Store in cache for 10 minutes
                _cache.Set(cacheKey, examData, TimeSpan.FromMinutes(10));
            }

            return examData;
        }

        [Authorize]
        public async Task<PaperSubmissionResponse> SubmitPaper(PaperSubmission request, ServerCallContext context)
        {
            /*
            await _dbContext.Submissions.AddAsync(new ExamSubmissionRequest
            {
                SubmissionData = request.StudentSubmitPaper.ToByteArray(),
                SubmissionType = request.SubmissionType
            });
            await _dbContext.SaveChangesAsync();
            */

            return new PaperSubmissionResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = "Submission received" };
        }

        [Authorize]
        public async Task StreamExamUpdates(ExamUpdateRequest request, IServerStreamWriter<ExamUpdate> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                var update = new ExamUpdate
                {
                    ResponseCode = 200,
                    ExamId = request.ExamId,
                    Timestamp = Timestamp.FromDateTime(DateTime.UtcNow),
                    ResponseMessage = ByteString.CopyFromUtf8("DMM!")
                };

                await responseStream.WriteAsync(update);
                await Task.Delay(5000); // Send update every 5 seconds
            }
        }
    }
}