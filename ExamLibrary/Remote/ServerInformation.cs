using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace ExamLibrary.Remote
{
    internal class ServerInformation
    {
        public ServerInformation() { }

        public ServerInformation(string ip, int port, string serverName, string version, string allowed_ip_range)
        {
            this._ip = ip;
            this._port = port;
            this._serverName = serverName;
            this._version = version;
            this._allowed_ip_range = allowed_ip_range;
        }

        public string IP
        {
            get
            {
                return this._ip;
            }
            set
            {
                this._ip = value;
            }
        }

        public int Port
        {
            get
            {
                return this._port;
            }
            set
            {
                this._port = value;
            }
        }

        public string ServerName
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public string Version
        {
            get
            {
                return this._version;
            }
            set
            {
                this._version = value;
            }
        }

        public string MonitorIP
        {
            get
            {
                return this._monitor_IP;
            }
            set
            {
                this._monitor_IP = value;
            }
        }

        public int MonitorPort
        {
            get
            {
                return this._monitor_port;
            }
            set
            {
                this._monitor_port = value;
            }
        }

        public string AllowedIpRange
        {
            get
            {
                return this._allowed_ip_range;
            }
            set
            {
                this._allowed_ip_range = value;
            }
        }

        private string _ip;

        private int _port;

        private string _name;

        private string _version;

        private string _monitor_IP;

        private int _monitor_port;

        private string _allowed_ip_range;
    }
}
