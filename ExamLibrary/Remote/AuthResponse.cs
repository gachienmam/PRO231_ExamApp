using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Remote
{
    public class AuthResponse
    {
        public int Response { get { return _responseCode; } set { _responseCode = value; } }

        public string Token { get { return _token == null ? string.Empty : _token; } set { _token = value; } }

        private int _responseCode {  get; set; }

        private string? _token { get; set; }
    }
}
