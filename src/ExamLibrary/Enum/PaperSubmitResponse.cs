using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Enum
{
    public enum PaperSubmitResponse
    {
        // Server
        SUBMIT_SUCCESS_CONTINUE = 1,
        SUBMIT_SUCCESS_FINAL = 2,
        SUBMIT_FAILED = 3,

        // Client
        SUBMIT_CONTINUE = 4,
        SUBMIT_FINAL = 5,
    }
}
