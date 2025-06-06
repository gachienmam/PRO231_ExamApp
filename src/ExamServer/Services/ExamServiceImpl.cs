﻿using ExamServer.Helper;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ServerDatabaseLibrary.Database;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using ExamServer.ExamProto;
using ManagementServer.Helper;
using ExamLibrary.Question;
using ExamLibrary.Remote;
using ExamLibrary.Enum;
using Newtonsoft.Json;
using ExamLibrary.Helper;
using System.Text.Json.Nodes;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Runtime.InteropServices;
using ExamLibrary.Question.Types;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace ExamServer.Services
{
    internal class ExamServiceImpl : ExamProto.ExamService.ExamServiceBase
    {
        private readonly string _examPaperPath = "ExamPapers/";
        private readonly string _submitPaperPath = "SubmitPapers/";

        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ExamServiceImpl> _logger;

        // Truy cập dữ liệu cho BUS -> DAL
        private DatabaseHelper _databaseHelper;

        // Cho server
        private ServerDatabaseLibrary.Database.DAL.DeThi _dalDeThi;
        private ServerDatabaseLibrary.Database.DAL.ThiSinh _dalThiSinh;
        private ServerDatabaseLibrary.Database.DAL.KetQuaThi _dalKetQuaThi;

        private PolyTestJWT _jwtHelper;

        public ExamServiceImpl(IConfiguration configuration, ILogger<ExamServiceImpl> logger, IMemoryCache cache)
        {
            _configuration = configuration;
            _logger = logger;
            _cache = cache;

            _databaseHelper = new DatabaseHelper(_configuration.GetConnectionString("ExamDatabase") ?? "");
            _dalDeThi = new ServerDatabaseLibrary.Database.DAL.DeThi(_databaseHelper);

            _dalThiSinh = new ServerDatabaseLibrary.Database.DAL.ThiSinh(_databaseHelper);

            _dalKetQuaThi = new ServerDatabaseLibrary.Database.DAL.KetQuaThi(_databaseHelper);

            _jwtHelper = new PolyTestJWT(_configuration);
        }

        public override async Task<AuthResponse> ExamAuthenticateUser(AuthRequest request, ServerCallContext context)
        {
            //if (request.ThiSinhId == null || request.Password == null)
            //{
            //    return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Invalid credentials" };
            //}
            //var userTable = await Task.Run(() => _dalThiSinh.GetThiSinhByMaThiSinh(request.ThiSinhId));
            //var user = await Task.Run(() => JArray.FromObject(userTable)[0].ToObject<ServerDatabaseLibrary.Database.DTO.ThiSinh>());
            //if (user == null || PasswordEncryption.VerifyPassword(request.Password, user.MatKhau))
            //{
            //    return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Invalid credentials" };
            //}

            //string token = _jwtHelper.GenerateJwtToken(user); // Implement token generation
            //return new AuthResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = "Success", AccessToken = token };
            ////return new AuthResponse { ResponseCode = 200, ResponseMessage = "Success", AccessToken = ""};
            if (request.ThiSinhId == null || request.Password == null)
            {
                return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Invalid credentials" };
            }
            var userTable = await Task.Run(() => _dalThiSinh.GetThiSinhByMaThiSinh(request.ThiSinhId));
            if (userTable.Rows.Count > 0)
            {
                if (userTable.Rows[0]["TrangThai"].ToString().Trim() == "1")
                {
                    var user = await Task.Run(() => JArray.FromObject(userTable)[0].ToObject<ServerDatabaseLibrary.Database.DTO.ThiSinh>());
                    if (user == null || !PasswordEncryption.VerifyPassword(request.Password, user.MatKhau))
                    {
                        return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Invalid credentials" };
                    }

                    string token = _jwtHelper.GenerateJwtToken(user); // Implement token generation

                    // DEBUG
                    //string token = _jwtHelper.GenerateJwtToken(new ServerDatabaseLibrary.Database.DTO.NguoiDung(request.Email, "Joe Biden", "ND001", "Pass", "Admin"));

                    return new AuthResponse { ResponseCode = (int)HttpStatusCode.OK, ResponseMessage = "Success", AccessToken = token };
                }
                else
                {
                    return new AuthResponse { ResponseCode = (int)HttpStatusCode.Locked, ResponseMessage = "Tài khoản của bạn đã bị khóa! Xin liên lạc với quản trị viên" };
                }
            }
            else
            {
                return new AuthResponse { ResponseCode = (int)HttpStatusCode.Unauthorized, ResponseMessage = "Bạn đã nhập sai thông tin đăng nhập. Xin nhập lại" };
            }
        }

        [Authorize]
        public override async Task<ExamData> GetExamData(ExamRequest request, ServerCallContext context)
        {
            //string danhSachThiCacheKey = $"DanhSachThi_{request.ExamCode}";
            var examDataTable = await Task.Run(() => _dalDeThi.GetDeThiByMaDe(request.ExamCode));
            var ketQuaThi = await Task.Run(() => _dalKetQuaThi.GetBangDiemTheoMaDeAndMaThiSinh(request.ExamCode, request.ThiSinhId));

            if (ketQuaThi.Rows.Count > 0 && ketQuaThi.Rows[0]["MaThiSinh"].ToString() == request.ThiSinhId)
            {
                return new ExamData { ResponseCode = (int)HttpStatusCode.Conflict };
            }

            // Kiểm tra bài có tồn tại hay không
            if (examDataTable != null || examDataTable.Rows.Count > 0)
            {
                // Để chìa khóa lưu giữ bộ nhớ tạm
                string examCacheKey = $"Exam_{request.ExamCode}_{examDataTable.Rows[0]["ThoiGianBatDau"].ToString()}";

                // Kiểm tra thí sinh có trong danh sách thi hay không
                if (!string.IsNullOrWhiteSpace(examDataTable.Rows[0]["DanhSachThi"].ToString().Trim()))
                {
                    JArray dsThiArray = JArray.Parse(examDataTable.Rows[0]["DanhSachThi"].ToString());
                    if (!dsThiArray.Any(obj => obj["MaThiSinh"] != null && obj["MaThiSinh"].ToString() == request.ThiSinhId))
                    {
                        return new ExamData { ResponseCode = (int)HttpStatusCode.MethodNotAllowed };
                    }
                }
                // Kiểm tra trạng thái bài
                if (examDataTable.Rows[0]["TrangThai"].ToString().Trim() == "1" || DateTime.Now < DateTime.Parse(examDataTable.Rows[0]["ThoiGianKetThuc"].ToString()))
                {
                    // Kiểm tra thí sinh đã nhập đúng mật khẩu đề
                    if (examDataTable.Rows[0]["MatKhau"].ToString().Trim() == request.ExamPassword)
                    {
                        // Load bài thi nếu không tồn tại trong bộ nhớ tạm
                        if (!_cache.TryGetValue(examCacheKey, out ExamData examData))
                        {
                            //Lấy file từ DeThi.ViTriFileDe đưa từ excel sang dữ liệu thi
                            var exam = ExcelExamHelper.ReadFromFileIntoPaper(examDataTable.Rows[0]["ViTriFileDe"].ToString());
                            if (exam == null)
                            {
                                return new ExamData { ResponseCode = (int)HttpStatusCode.NotFound }; // Not Found
                            }

                            exam.ExamCode = request.ExamCode;

                            ServerInformation serverInfo = new ServerInformation()
                            {
                                IP = "192.168.110.1",
                                ServerName = Environment.MachineName,
                                Port = 50051,
                                Version = "Ilovegainhatban"
                            };

                            // Xáo trộn câu hỏi
                            if(exam.OptionShuffleMultipleChoice == true)
                            {
                                Random random = new Random();
                                for (var i = exam.QMultipleChoice.Count - 1; i > 0; i--)
                                {
                                    var randomIndex = random.Next(i + 1); //maxValue (i + 1) is EXCLUSIVE
                                    var temp = exam.QMultipleChoice[i];
                                    exam.QMultipleChoice[i] = exam.QMultipleChoice[randomIndex];
                                    exam.QMultipleChoice[randomIndex] = temp;
                                }
                            }

                            examData = new ExamData
                            {
                                ResponseCode = (int)HttpStatusCode.OK,
                                ExamPaper = ByteString.CopyFrom(GZip.CompressJson(JsonConvert.SerializeObject(exam))),
                                ServerInformation = JsonConvert.SerializeObject(serverInfo)
                            };

                            _logger.LogInformation(JsonConvert.SerializeObject(exam));

                            // Lưu trong bộ nhớ tạm trong thời gian thi + 4 phút (đề phòng thí sinh không lưu bài kịp)
                            _cache.Set(examCacheKey, examData, TimeSpan.FromSeconds(120));
                        }
                        // Tạo kết quả thi ban đầu
                        bool insertKetQua = await Task.Run(() => _dalKetQuaThi.InsertKetQuaThi(request.ThiSinhId, request.ExamCode, 0, DateTime.Now, DateTime.Parse(examDataTable.Rows[0]["ThoiGianKetThuc"].ToString()), false));
                        if (!insertKetQua)
                        {
                            return new ExamData { ResponseCode = (int)HttpStatusCode.InternalServerError };
                        }
                        return examData ?? new ExamData { ResponseCode = (int)HttpStatusCode.NotFound };
                    }
                    else
                    {
                        return new ExamData { ResponseCode = (int)HttpStatusCode.NotFound };
                    }
                }
                else
                {
                    return new ExamData { ResponseCode = (int)HttpStatusCode.NotFound };
                }
            }
            else
            {
                return new ExamData { ResponseCode = (int)HttpStatusCode.NotFound, ExamPaper = null, ServerInformation = null };
            }
        }

        [Authorize]
        public override async Task<PaperSubmissionResponse> SubmitPaper(PaperSubmission request, ServerCallContext context)
        {
            var examDataTable = await Task.Run(() => _dalDeThi.GetDeThiByMaDe(request.ExamCode));
            // Kiểm tra bài có tồn tại hay không
            if (examDataTable != null || examDataTable.Rows.Count > 0)
            {
                string examCacheKey = $"Exam_{request.ExamCode}_{examDataTable.Rows[0]["ThoiGianBatDau"].ToString()}";
                // Load bài thi nếu không tồn tại trong bộ nhớ tạm
                if (!_cache.TryGetValue(examCacheKey, out ExamData examData))
                {
                    //Lấy file từ DeThi.ViTriFileDe đưa từ excel sang dữ liệu thi
                    var exam = ExcelExamHelper.ReadFromFileIntoPaper(examDataTable.Rows[0]["ViTriFileDe"].ToString());
                    if (exam == null)
                    {
                        return new PaperSubmissionResponse { ResponseCode = (int)PaperSubmitResponse.SUBMIT_FAILED, ResponseMessage = "Exam not found" }; // Not Found
                    }

                    exam.ExamCode = request.ExamCode;

                    ServerInformation serverInfo = new ServerInformation()
                    {
                        IP = "192.168.110.1",
                        ServerName = Environment.MachineName,
                        Port = 50051,
                        Version = "Ilovegainhatban"
                    };

                    // Xáo trộn câu hỏi
                    if (exam.OptionShuffleMultipleChoice == true)
                    {
                        Random random = new Random();
                        for (var i = exam.QMultipleChoice.Count - 1; i > 0; i--)
                        {
                            var randomIndex = random.Next(i + 1); //random từ 0 < randomIndex < i
                            var temp = exam.QMultipleChoice[i];
                            exam.QMultipleChoice[i] = exam.QMultipleChoice[randomIndex];
                            exam.QMultipleChoice[randomIndex] = temp;
                        }
                    }

                    examData = new ExamData
                    {
                        ResponseCode = (int)HttpStatusCode.OK,
                        ExamPaper = ByteString.CopyFrom(GZip.CompressJson(JsonConvert.SerializeObject(exam))),
                        ServerInformation = JsonConvert.SerializeObject(serverInfo)
                    };

                    _logger.LogInformation(JsonConvert.SerializeObject(exam));

                    // Lưu trong bộ nhớ tạm 30s để dành thời gian chấm bài (đề phòng máy chủ bị quá tải)
                    _cache.Set(examCacheKey, examData, TimeSpan.FromSeconds(30));
                }

                Paper examPaper = JsonConvert.DeserializeObject<Paper>(GZip.DecompressJson(examData.ExamPaper.ToByteArray()));
                SubmitPaper submitPaper = JsonConvert.DeserializeObject<SubmitPaper>(GZip.DecompressJson(request.StudentSubmitPaper.ToByteArray()));
                if (examPaper != null && submitPaper != null)
                {
                    int correctAnswers = ExamGrader.GetCorrectAnswersFromGradeExamResult(ExamGrader.GradeExam(examPaper.QMultipleChoice, submitPaper.SubmissionPaper.QMultipleChoice));
                    float points = ((float)correctAnswers / (float)examPaper.QMultipleChoice.Count) * 10;

                    if (request.SubmissionType == (int)PaperSubmitResponse.SUBMIT_CONTINUE)
                    {
                        _logger.LogInformation($"PaperSubmit CONTINUE RECEIVED DATA: {GZip.DecompressJson(request.StudentSubmitPaper.ToByteArray())}");
                        _dalKetQuaThi.UpdateKetQuaThi(request.ThiSinhId, request.ExamCode, points, DateTime.Now, false);
                        _logger.LogInformation($"PaperSubmit CONTINUE SUBMITTED: ThiSinhId: {request.ThiSinhId}, ExamCode: {request.ExamCode}, Points: {points:0.0##}, Correct: {correctAnswers}");
                        return new PaperSubmissionResponse { ResponseCode = (int)PaperSubmitResponse.SUBMIT_SUCCESS_CONTINUE, ResponseMessage = "Submission received" };
                    }

                    if (request.SubmissionType == (int)PaperSubmitResponse.SUBMIT_FINAL)
                    {
                        _logger.LogInformation($"PaperSubmit FINAL RECEIVED DATA: {GZip.DecompressJson(request.StudentSubmitPaper.ToByteArray())}");
                        _dalKetQuaThi.UpdateKetQuaThi(request.ThiSinhId, request.ExamCode, points, DateTime.Now, true);
                        _logger.LogInformation($"PaperSubmit FINAL SUBMITTED: ThiSinhId: {request.ThiSinhId}, ExamCode: {request.ExamCode}, Points: {points:0.0##}, Correct: {correctAnswers}, FinalTime: {DateTime.Now}");
                        return new PaperSubmissionResponse { ResponseCode = (int)PaperSubmitResponse.SUBMIT_SUCCESS_FINAL, ResponseMessage = "Submission received. End exam" };
                    }

                    _logger.LogInformation($"PaperSubmit FAILED (Invalid submission type): ThiSinhId: {request.ThiSinhId}, ExamCode: {request.ExamCode}, Points: {points:0.0##}, Correct: {correctAnswers}, Time: {DateTime.Now}");
                    return new PaperSubmissionResponse { ResponseCode = (int)PaperSubmitResponse.SUBMIT_FAILED, ResponseMessage = "Exam data not loaded for grading gg mr bit" };
                }
            }
            _logger.LogInformation($"PaperSubmit FAILED to load exam data: ThiSinhId: {request.ThiSinhId}, ExamCode: {request.ExamCode}, Points: NONE, Correct: NONE, Time: {DateTime.Now}");
            return new PaperSubmissionResponse { ResponseCode = (int)PaperSubmitResponse.SUBMIT_FAILED, ResponseMessage = "Exam data not loaded for grading gg mr bit" };
        }

        [Authorize]
        public override async Task StreamExamUpdates(ExamUpdateRequest request, IServerStreamWriter<ExamUpdate> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                var update = new ExamUpdate
                {
                    ResponseCode = (int)HttpStatusCode.OK,
                    ExamCode = request.ExamCode,
                    Timestamp = Timestamp.FromDateTime(DateTime.UtcNow),
                    ResponseMessage = ""
                };

                await responseStream.WriteAsync(update);
                await Task.Delay(5000); // Send update every 5 seconds
            }
        }
    }
}