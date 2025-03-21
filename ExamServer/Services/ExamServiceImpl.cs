using ExamLibrary.Enum;
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

namespace ExamServer.Services
{
    internal class ExamServiceImpl
    {
        private readonly IMemoryCache _cache;
        //private readonly ILogger<UserExamServiceImpl> _logger;
        // Thay bằng BUS
        //private readonly ExamDbContext _dbContext; // Assuming EF Core for SQL Server
        private Database.BUS.DeThi _busDeThi = new Database.BUS.DeThi();
        private PolyTestJWT _jwtService;

        public ExamServiceImpl(IMemoryCache cache/*, ExamDbContext dbContext*/)
        {
            _cache = cache;
            //_dbContext = dbContext;
        }

        public async Task<AuthResponse> AuthenticateUser(AuthRequest request, ServerCallContext context)
        {
            // Validate user (simplified example)
            //var user = await _dbContext.Users
            //    .FirstOrDefaultAsync(u => u.Username == request.Username && u.Password == request.Password);

            if (request.Username == null)
            {
                return new AuthResponse { ResponseCode = 401, ResponseMessage = "Invalid credentials" };
            }

            string token = _jwtService.GenerateJwtToken(user); // Implement token generation
            return new AuthResponse { ResponseCode = 200, ResponseMessage = "Success", AccessToken = token};
        }

        [Authorize]
        public async Task<ExamData> GetExamData(ExamRequest request, ServerCallContext context)
        {
            string cacheKey = $"Exam_{request.ExamId}";

            if (!_cache.TryGetValue(cacheKey, out ExamData examData))
            {
                // Load from database if not in cache
                var exam = await _busDeThi.GetDeThiFromID().FindAsync(request.ExamId);
                if (exam == null)
                {
                    return new ExamData { ResponseCode = 404 }; // Not Found
                }

                examData = new ExamData
                {
                    ResponseCode = (int)HttpStatusCode.OK,
                    ExamPaper = ByteString.CopyFrom(exam.PaperData),
                    //ExamForm = ByteString.CopyFrom(exam.FormData),
                    //ExamFormSize = exam.FormData.Length,
                    ServerInformation = ByteString.CopyFromUtf8("PolyTestExamServer_14032025")
                };

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