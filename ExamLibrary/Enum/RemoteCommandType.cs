using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Enum
{
    public enum RemoteCommandType
    {
        // Lệnh liên quan SQL
        SQL_NONQUERY = 0,
        SQL_SCALAR = 1,
        SQL_READER = 2,
        SQL = 3,

        // Lệnh liên quan tạo password
        REQUEST_ENCRYPTEDPASSWORD = 5,

        BROADCAST_ALL = 10,
        BROADCAST_TARGETED_EXAM = 11,
        BROADCAST_TARGETED_USER = 12
    }
}