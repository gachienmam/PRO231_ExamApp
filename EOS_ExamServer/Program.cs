using Grpc.AspNetCore;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Xml.Linq;

/*
 * EOS - Exam Server
 * 3-6-2025
 * 
 * by monke
 */ 

namespace EOS_ExamServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddGrpc();

            var app = builder.Build();
            
            //app.MapGrpcService<>();

            app.Run();

            SendToConsole($"EOS server (gRPC) started at https://{serverAddr}:5001/", CommandStatus.START_SERVER, true);
            //Console.ReadKey();
            //Console.WriteLine("\r\n");

            CommandHandler();
            SendToConsole($"Server stopped. Fuck you", CommandStatus.STOP_SERVER, true);
        }

        #region Strings / Variables

        public static string serverAddr = "127.0.0.1";

        public static string directory_AppRoot = AppDomain.CurrentDomain.BaseDirectory;

        public static string directory_StudentData = directory_AppRoot + "\\studentdata";

        public static string directory_Database = directory_AppRoot + "\\database";

        public static string directory_Logs = directory_AppRoot + "\\logs";

        public static string? serverBroadcast { get; set; }

        public static bool IsHandlingCommands { get; set; } = false;

        #endregion

        #region Enumerables
        public enum RegisterStatus
        {
            NEW,
            RE_ASSIGN,
            FINISHED,
            REGISTERED,
            REGISTER_ERROR,
            EXAM_CODE_NOT_EXISTS,
            NOT_ALLOW_MACHINE,
            NOT_ALLOW_STUDENT,
            LOGIN_FAILED
        }

        public enum CommandStatus
        {
            //Server status
            START_SERVER,
            STOP_SERVER,
            INFO,
            WARNING,
            ERROR,

            // Client <-> Server exam status (vanilla EOS protocol)
            NEW,
            RE_ASSIGN,
            FINISHED,
            REGISTERED,
            REGISTER_ERROR,
            EXAM_CODE_NOT_EXISTS,
            NOT_ALLOW_MACHINE,
            NOT_ALLOW_STUDENT,
            LOGIN_FAILED,

            // Client <-> Server: Communication specific statuses
            DATA_RECIEVED,
            DATA_SENT,
            CONN_TERMINATED,
            CONN_ESTABLISHED
        }
        #endregion

        #region Functions
        public static void CommandHandler()
        {
            do
            {
                Console.Write("\r\n> ");
                string? command = Console.ReadLine();
                string[] cmd = command.Split(' ');
                //SendToLog($"Recieved command: {command}", CommandStatus.INFO);
                switch (cmd[0])
                {
                    default:
                        {
                            SendToConsole($"Command not found: {command}", CommandStatus.ERROR, false);
                            break;
                        }
                    case var s when command.StartsWith("broadcast "):
                        {
                            if(cmd.Length > 1)
                            {
                                serverBroadcast = cmd[1];
                                SendToConsole($"broadcast: {cmd[1]}", CommandStatus.INFO, true);
                                //int var1 = Convert.ToInt32(Console.ReadLine());
                                //Thread setBCMsg = new Thread(() => SetBroadcastMessage(_serverBroadcast, var1));
                                //setBCMsg.Start();
                            }

                            break;
                        }
                    case "list-exam":
                        {
                            SendToConsole("List of exams (from database):", CommandStatus.INFO, true);
                            XDocument examDatabaseXml = XDocument.Load($"{directory_Database}\\examdb.xml");
                            foreach (XElement element in examDatabaseXml.Descendants("Exam"))
                            {

                            }
                            break;
                        }
                    case "info":
                        {
                            SendToConsole($"EOS ExamServer ({(Assembly.GetExecutingAssembly().GetName().Version?.ToString() == null ? "unknownVersion" : Assembly.GetExecutingAssembly().GetName().Version?.ToString())}), by monkegaming", CommandStatus.INFO, false);
                            break;
                        }
                    case "exit":
                        {
                            IsHandlingCommands = false;
                            return;
                        }
                }
            } while (IsHandlingCommands == true);
        }

        public static void SendToConsole(string cmd, CommandStatus commandStatus, bool logToFile)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("hh:mm:ss")} {commandStatus.ToString()}] " + cmd);
            if (logToFile is true)
            {
                //FileStream logFile = new FileStream(directory_AppRoot + $"\\logs\\log-{DateTime.Now.ToString("yyyy-MM-dd")}.log", FileMode.Open);
                //logFile.Write($"[{commandStatus.ToString()}] " + cmd);
                File.AppendAllText($"{directory_AppRoot}\\logs\\log-{DateTime.Now.ToString("yyyy-MM-dd")}.log", $"[{DateTime.Now.ToString("hh:mm:ss")} {commandStatus}] " + cmd + Environment.NewLine);
            }
        }
        #endregion
    }
}
