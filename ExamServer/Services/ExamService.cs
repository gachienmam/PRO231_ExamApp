using ExamLibrary.Enum;
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
    internal class ExamService
    {

        private readonly ILogger<ExamService> _logger;
        private readonly JWTService jwtService;
        private readonly Dictionary<int, AsyncServerStreamingCall<ExamUpdate>> _subscribers = new();

        public ExamService(ILogger<ExamService> logger)
        {
            _logger = logger;
        }

        public Task<AuthResponse> AuthenticateUser(AuthRequest request, ServerCallContext context)
        {
            // Simulate user validation (replace with actual validation logic)
            if (request.Username == "admin" && request.Password == "password")
            {
                string token = jwtService.GenerateJwtToken(request.Username);
                return Task.FromResult(new AuthResponse { Token = token, Response = (int)GenericResponse.AUTH_SUCCESS });
            }
            else
            {
                return Task.FromResult(new AuthResponse { Token = "", Response = (int)GenericResponse.AUTH_STUDENT_LOGIN_FAILED });
            }
        }

        [Authorize]
        public Task<Empty> SendExamUpdate(ExamUpdate request, ServerCallContext context)
        {
            _logger.LogInformation($"Received update from Student {request.RecipientId}: {(UpdateResponse)request.ResponseCode}");
            BroadcastMessageToStudents($"Student {request.RecipientId} performed {(UpdateResponse)request.ResponseCode}");
            return Task.FromResult(new Empty());
        }

        [Authorize]
        public async Task SubscribeToExamUpdates(ExamUpdate request, IServerStreamWriter<ExamUpdate> responseStream, ServerCallContext context)
        {
            _logger.LogInformation($"Student subscribed to exam {request.ExamId} updates.");

            while (!context.CancellationToken.IsCancellationRequested)
            {
                await Task.Delay(5000); // Simulating periodic broadcasts
                await responseStream.WriteAsync(new ExamUpdate
                {
                    ResponseCode = (int)UpdateResponse.SUBSCRIBE_BROADCAST,
                    RecipientId = request.RecipientId,
                    ExamId = request.ExamId,
                    ResponseMessage = ByteString.CopyFromUtf8("Exam status updated..."),
                    Timestamp = Timestamp.FromDateTime(DateTime.UtcNow),
                });
            }
        }

        [Authorize]
        private bool ValidateAccessToken(string token)
        {
            return token == "valid_token"; // Simulate authentication
        }

        [Authorize]
        private ExamData LoadExamData(int examId)
        {
            // Replace with loading from database
            return new ExamData
            {
                ExamForm = new byte[] { 1, 2, 3 }, // Example byte array
                OriginSize = 1024,
                ServerInfo = new ServerInformation { ServerName = "ExamServer", IP = "192.168.1.1" }
            };
        }

        [Authorize]
        private void BroadcastMessageToStudent(string message)
        {

        }

        [Authorize]
        private void BroadcastMessageToStudents(string message)
        {
            _logger.LogInformation($"Broadcasting: {message}");
            foreach (var subscriber in _subscribers.Values)
            {
                /*
                subscriber.ResponseStream.WriteAsync(new ExamUpdate
                {
                    ResponseCode = UpdateResponse.BROADCAST_INFO,
                    RecipientId = subscriber.ResponseStream.Current.RecipientId,
                    ExamId = subscriber.ResponseStream.Current.ExamId,
                    ResponseMessage = Encoding.UTF8.GetBytes(message),
                    Timestamp = Timestamp.FromDateTime(DateTime.UtcNow).ToDateTime(),
                });
                */
            }
        }
    }
}