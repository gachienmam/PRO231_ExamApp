using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementApp.AdminService;

namespace ManagementApp.Services
{
    internal class AdminClient
    {
        private readonly Admi _client;

        public AdminClient(string grpcServerUrl)
        {
            var channel = GrpcChannel.ForAddress(grpcServerUrl);
            _client = new AdminService.AdminServiceClient(channel);
        }

        public async Task<bool> UploadExamPaper(string accessToken, string examId, string filePath)
        {
            using var call = _client.UploadExamPaper();
            byte[] fileData = File.ReadAllBytes(filePath);

            await call.RequestStream.WriteAsync(new ExamPaperChunk
            {
                AccessToken = accessToken,
                ExamId = examId,
                FileChunk = Google.Protobuf.ByteString.CopyFrom(fileData),
                IsLastChunk = true
            });

            await call.RequestStream.CompleteAsync();
            var response = await call.ResponseAsync;

            return response.ResponseCode == 200;
        }

        public async Task<string> ExecuteAdminCommand(string accessToken, string command)
        {
            var request = new CommandRequest
            {
                AccessToken = accessToken,
                Command = command
            };

            var response = await _client.ExecuteAdminCommandAsync(request);
            return response.ResponseMessage;
        }
    }
}
