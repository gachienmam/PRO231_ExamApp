using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Enum
{
    public enum GenericResponse
    {
        // Exam: Exam
        EXAM_NEW = 0,
        EXAM_RETAKE = 1,
        EXAM_FINISHED = 2,
        EXAM_DOES_NOT_EXIST = 3,
        EXAM_BLOCKED_MACHINE = 4,
        EXAM_BLOCKED_STUDENT = 5,

        // Exam: Account
        EXAM_ALREADY_REGISTERED = 10,
        EXAM_REGISTER_STUDENT_FAILED = 11,
        
        // Auth
        AUTH_SUCCESS = 20,
        AUTH_STUDENT_LOGIN_FAILED = 21,
        AUTH_STUDENT_DOES_NOT_EXIST = 22,

        // Admin: Commands
        CMD_SUCCESS = 30,
        CMD_FAILED = 31,

        // Admin: Upload
        UPLOAD_SUCCESS = 40,
        UPLOAD_FAILED = 41
    }
}