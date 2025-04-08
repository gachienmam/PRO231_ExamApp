using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Enum
{
    public enum UpdateResponse
    {
        SUBSCRIBE_BROADCAST = 0,
        UNSUBSCRIBE_BROADCAST = 1,
        BROADCAST_INFO = 2,
        BROADCAST_WARNING = 3,

        //
        // Custom responses
        //

        // Broadcast message

        // Private broadcast
        BROADCAST_INFO_PRIVATE = 4,
        BROADCAST_WARNING_PRIVATE = 5,
    }
}
