using ExamLibrary.Remote;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS_ExamServer.Services
{
    internal class ExamService : ExamServiceBase
    {
        public Task<ExamData> Login(string username, ServerCallContext context)
        {
        }
    }
}