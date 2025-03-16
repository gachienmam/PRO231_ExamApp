using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Enum
{
    public enum RemoteCommandType
    {
        SQL = 0,

        BROADCAST_ALL = 1,
        BROADCAST_TARGETED_EXAM = 2,
        BROADCAST_TARGETED_USER = 3
    }
}
