using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Remote
{
    public enum RegisterStatus
    {
        // Exam: New test
        NEW,

        // Exam: Retake
        RETAKE,

        // Exam: Already finished
        FINISHED,
        REGISTERED,
        REGISTER_ERROR,
        EXAM_CODE_NOT_EXISTS,
        NOT_ALLOW_MACHINE,
        NOT_ALLOW_STUDENT,
        LOGIN_FAILED
    }
}
