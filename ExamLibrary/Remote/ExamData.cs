using System;
using ExamLibrary.Question;

namespace ExamLibrary.Remote
{
    public class ExamData
    {
        public RegisterStatus RegStatus;

        public Paper ExamPaper;

        public SubmitPaper SubmitPaper;

        public byte[] GUI;

        public int OriginSize;

        public ServerInformation ServerInfo;

        public RegisterData RegData;
    }
}