using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamServer.Database
{
    internal class ExamDbContext
    {
        public IConfiguration Configuration;

        public ExamDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string? GetConnectionString()
        {
            return Configuration.GetConnectionString("ExamDatabase") ?? "Data Source=.;Initial Catalog=PolyTest_Database;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;";
        }
    }
}