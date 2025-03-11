using ExamLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Remote
{
    public class ExamUpdate
    {
        public UpdateResponse ResponseCode;

        public string ExamId;

        public string RecipientId;

        public DateTime Timestamp;

        public byte[] ResponseMessage;
    }
}
