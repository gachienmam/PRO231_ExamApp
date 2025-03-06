using System;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Remote
{
    public class AuthRequest
    {
        public DateTime StartDate
        {
            get
            {
                return this._startTime;
            }
            set
            {
                this._startTime = value;
            }
        }

        public string Username
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public string Machine
        {
            get
            {
                return this._machine;
            }
            set
            {
                this._machine = value;
            }
        }

        public string ExamCode
        {
            get
            {
                return this._examCode;
            }
            set
            {
                this._examCode = value;
            }
        }
        private DateTime _startTime;

        private string _username;

        private string _password;

        private string _machine;

        private string _examCode;
    }
}
