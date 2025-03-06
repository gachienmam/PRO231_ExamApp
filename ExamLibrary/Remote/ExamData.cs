using System;
using ExamLibrary.Enum;
using ExamLibrary.Question;

namespace ExamLibrary.Remote
{
    public class ExamData
    {
        public GenericResponse RegStatus;

        public Paper ExamPaper;
            
        public byte[] ExamForm;

        public int OriginSize;

        public ServerInformation ServerInfo;
    }
}