using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp
{
    class Shared
    {
        public static string? AccessToken = null;
        public static string ServerIP = "https://localhost:5000";

        public static bool ValidateToken(string token)
        {
            return false;
        }
    }
}
