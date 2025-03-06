using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Enum
{
    public enum GenericResponse
    {
        // Exam: Exam
        EXAM_NEW = 1,
        EXAM_RETAKE = 2,
        EXAM_FINISHED = 3,
        EXAM_DOES_NOT_EXIST = 4,
        EXAM_BLOCKED_MACHINE = 5,
        EXAM_BLOCKED_STUDENT = 6,

        // Exam: Account
        EXAM_ALREADY_REGISTERED = 7,
        EXAM_REGISTER_STUDENT_FAILED = 8,
        
        // Auth
        AUTH_SUCCESS = 9,
        AUTH_STUDENT_LOGIN_FAILED = 10,
        AUTH_STUDENT_DOES_NOT_EXIST = 11
    }
}