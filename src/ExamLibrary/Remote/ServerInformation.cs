using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace ExamLibrary.Remote
{
    public class ServerInformation
    {
        public ServerInformation() { }

        public ServerInformation(string ip, int port, string serverName, string version, string allowed_ip_range)
        {
            _ip = ip;
            _port = port;
            _serverName = serverName;
            _version = version;
            _allowed_ip_range = allowed_ip_range;
        }

        public string IP
        {
            get
            {
                return _ip;
            }
            set
            {
                _ip = value;
            }
        }

        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        public string ServerName
        {
            get
            {
                return _serverName;
            }
            set
            {
                _serverName = value;
            }
        }

        public string Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }

        public string MonitorIP
        {
            get
            {
                return _monitor_IP;
            }
            set
            {
                _monitor_IP = value;
            }
        }

        public int MonitorPort
        {
            get
            {
                return _monitor_port;
            }
            set
            {
                _monitor_port = value;
            }
        }

        public string AllowedIpRange
        {
            get
            {
                return _allowed_ip_range;
            }
            set
            {
                _allowed_ip_range = value;
            }
        }

        private string _ip;

        private int _port;

        private string _serverName;

        private string _version;

        private string _monitor_IP;

        private int _monitor_port;

        private string _allowed_ip_range;
    }
}
