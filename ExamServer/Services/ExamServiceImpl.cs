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
using ServerDatabaseLibrary.Database;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using ExamServer.ExamProto;
using ManagementServer.Helper;
using ProtoBuf;
using ExamLibrary.Question;
using ExamLibrary.Remote;
using ExamLibrary.Enum;

namespace ExamServer.Services
{
    internal class ExamServiceImpl : ExamProto.ExamService.ExamServiceBase
    {
        private readonly string _examPaperPath = "ExamPapers/";
        private readonly string _submitPaperPath = "SubmitPapers/";

        private readonly IMemoryCache _cache;
        //private readonly ILogger<UserExamServiceImpl> _logger;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ExamServiceImpl> _logger;

        // Truy cập dữ liệu cho BUS -> DAL
        private DatabaseHelper _databaseHelper;

        // Cho server
        //private ServerDatabaseLibrary.Database.BUS.DeThi _busDeThi;
        //private ServerDatabaseLibrary.Database.BUS.ThiSinh _busThiSinh;
        private ServerDatabaseLibrary.Database.DAL.DeThi _dalDeThi;
        private ServerDatabaseLibrary.Database.DAL.ThiSinh _dalThiSinh;

        private PolyTestJWT _jwtHelper;

        public ExamServiceImpl(IConfiguration configuration, ILogger<ExamServiceImpl> logger, IMemoryCache cache)
        {
            _configuration = configuration;
            _logger = logger;
            _cache = cache;

            _databaseHelper = new DatabaseHelper(_configuration.GetConnectionString("ExamDatabase") ?? "");
            _dalDeThi = new ServerDatabaseLibrary.Database.DAL.DeThi(_databaseHelper);
            _dalThiSinh = new ServerDatabaseLibrary.Database.DAL.ThiSinh(_databaseHelper);

            _jwtHelper = new PolyTestJWT(_configuration);
        }

        public override async Task<AuthResponse> ExamAuthenticateUser(AuthRequest request, ServerCallContext context)
        {
            if (request.ThiSinhId == null || request.Password == null)
            {
                return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Invalid credentials" };
            }
            var userTable = await Task.Run(() => _dalThiSinh.GetThiSinhByMaThiSinh(request.ThiSinhId));
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
        public override async Task<ExamData> GetExamData(ExamRequest request, ServerCallContext context)
        {
            string cacheKey = $"Exam_{request.ExamId}";

            if (!_cache.TryGetValue(cacheKey, out ExamData examData))
            {
                // Load from database if not in cache
                var examDataTable = await Task.Run(() => _dalDeThi.GetDeThiByMaDe(request.ExamId));
                if (examDataTable != null || examDataTable.Rows.Count > 0)
                {
                    //Load DeThi.ViTriFileDe from excel into usable type to return to client
                    var exam = ExcelExamHelper.ReadFromFileIntoPaper(examDataTable.Rows[0]["ViTriFileDe"].ToString());
                    if (exam == null)
                    {
                        return new ExamData { ResponseCode = (int)HttpStatusCode.NotFound }; // Not Found
                    }

                    byte[] examPaperByteArray;
                    using (var memoryStream = new MemoryStream())
                    {
                        Serializer.Serialize(memoryStream, exam);
                        examPaperByteArray = memoryStream.ToArray();
                    }

                    ServerInformation serverInfo = new ServerInformation()
                    {
                        IP = "192.168.110.1",
                        ServerName = Environment.MachineName
                    };
                    byte[] serverInfoByteArray;
                    using (var memoryStream = new MemoryStream())
                    {
                        Serializer.Serialize(memoryStream, serverInfo);
                        serverInfoByteArray = memoryStream.ToArray();
                    }

                    examData = new ExamData
                    {
                        ResponseCode = (int)HttpStatusCode.OK,
                        ExamPaper = ByteString.CopyFrom(examPaperByteArray),
                        ExamForm = null,
                        ExamFormSize = 0,
                        ServerInformation = ByteString.CopyFrom(serverInfoByteArray)
                    };

                    // Lưu trong bộ nhớ tạm trong thời gian thi
                   _cache.Set(cacheKey, examData, TimeSpan.FromSeconds(exam.Duration + 120));
                }
                else
                {
                    return new ExamData { ResponseCode = (int)HttpStatusCode.NotFound, ExamForm = null, ExamFormSize = 0, ExamPaper = null, ServerInformation = null };
                }
            }

            return examData;
        }

        [Authorize]
        public override async Task<PaperSubmissionResponse> SubmitPaper(PaperSubmission request, ServerCallContext context)
        {
            /*
            await _dbContext.Submissions.AddAsync(new ExamSubmissionRequest
            {
                SubmissionData = request.StudentSubmitPaper.ToByteArray(),
                SubmissionType = request.SubmissionType
            });
            await _dbContext.SaveChangesAsync();
            */
            if(request.SubmissionType == (int)PaperSubmitResponse.SUBMIT_CONTINUE)
            {

            }

            return new PaperSubmissionResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = "Submission received" };
        }

        [Authorize]
        public override async Task StreamExamUpdates(ExamUpdateRequest request, IServerStreamWriter<ExamUpdate> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                var update = new ExamUpdate
                {
                    ResponseCode = 200,
                    ExamId = request.ExamId,
                    Timestamp = Timestamp.FromDateTime(DateTime.UtcNow),
                    ResponseMessage = ByteString.CopyFromUtf8("gg")
                };

                await responseStream.WriteAsync(update);
                await Task.Delay(5000); // Send update every 5 seconds
            }
        }
    }
}