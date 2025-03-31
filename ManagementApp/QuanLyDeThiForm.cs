using Grpc.Core;
using Grpc.Net.Client;
using ManagementApp.AdminProto;
using ManagementApp.CustomControls;
using ManagementApp.Database;
using ManagementApp.Helper;
using MiniExcelLibs;
using Newtonsoft.Json;
using ReaLTaiizor.Child.Crown;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Docking.Crown;
using ReaLTaiizor.Native;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using static ManagementApp.AdminProto.AdminService;

namespace ManagementApp
{
    public partial class QuanLyDeThiForm : Form
    {
        //private readonly List<CrownDockContent> _tools = new();
        //private readonly TreeViewControl _dockTreeView;

        private readonly AdminServiceClient _client;
        private readonly Grpc.Core.Metadata _headers;

        private DataTable _dataTable;
        private CrownTreeView _tree;
        private GrpcDatabaseHelper _dbHelper;

        private bool _isEditingExam;

        private string _currentUserEmail;
        private string _currentMaNguoiDung;

        public QuanLyDeThiForm(AdminServiceClient client, Grpc.Core.Metadata headers, string currentUserEmail)
        {
            InitializeComponent();
            _client = client;
            _headers = headers;

            _currentUserEmail = currentUserEmail;

            _dbHelper = new GrpcDatabaseHelper(_client, _headers);
            // Thêm bộ lọc sự kiện cuộn chuột
            Application.AddMessageFilter(new ControlScrollFilter());
        }

        private async void QuanLyDeThiForm_Load(object sender, EventArgs e)
        {
            _currentMaNguoiDung = _dbHelper.ExecuteSqlReader($"SELECT * FROM NguoiDung WHERE Email = '{_currentUserEmail}'").Rows[0]["MaNguoiDung"].ToString();
            await LoadTreeViewDataAsync();
            LoadStatusComboBox();
            ResetValues();
        }

        private async void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                try
                {
                    ofd.Filter = "Excel|*.xlsx|All Files|*.*";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (ofd.SafeFileName == $"{txtMaDe.Text}.xlsx")
                        {
                            ExcelExamHelper.TestReadFromFileIntoPaper(ofd.FileName);
                            string filePath = ofd.FileName;
                            stripProgressBar.Visible = false;
                            stripProgressBar.Value = 0;
                            statusLabel.Text = "Đã tải: 0%";
                            stripProgressBar.Visible = true;
                            txtViTriFileDe.Text = await UploadFileAsync(filePath);

                            // Hide
                            //txtViTriFileDe.Text = ofd.FileName;
                            stripProgressBar.Visible = false;
                            stripProgressBar.Value = 0;
                            statusLabel.Text = "Đang đợi";
                            //txtValidFile.Text = IsValidExamFile(txtViTriFileDe.Text) ? "Yes" : "No";
                            if (!string.IsNullOrWhiteSpace(txtViTriFileDe.Text))
                            {
                                txtValidFile.Text = "Yes";
                                btnDownloadFile.Enabled = true;
                            }
                            else
                            {
                                txtValidFile.Text = "No";
                                btnDownloadFile.Enabled = false;
                            }
                            MessageBox.Show("Đã tải lên thành công!", "Lỗi chọn file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Tên tệp tin đề phải trùng với mã đề!", "Lỗi chọn file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Tệp tin đề thi của bạn không hợp lệ!", "Lỗi chọn file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSelectDanhSachThi_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                try
                {
                    ofd.Filter = "Excel|*.xlsx|All Files|*.*";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (ofd.SafeFileName == $"DST_{txtMaDe.Text}.xlsx")
                        {
                            string filePath = ofd.FileName;
                            if((string)ExcelExamHelper.ReadFirstValueFromExcel(filePath, "Thong Tin", "MaThiSinh") == null)
                            {
                                MessageBox.Show("Tệp tin danh sách thi của bạn không hợp lệ!", "Lỗi chọn file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            txtViTriDanhSachThi.Text = ofd.SafeFileName;
                            var dsMaThiSinh = MiniExcel.Query(filePath, useHeaderRow: true).ToList();
                            txtDanhSachThi.Text = JsonConvert.SerializeObject(dsMaThiSinh);
                        }
                        else
                        {
                            MessageBox.Show("Tên tệp tin đề phải được đặt như sau: DST_(mã đề).xlsx", "Lỗi chọn file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Tệp tin danh sách thi của bạn không hợp lệ!", "Lỗi chọn file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnDownloadFile_Click(object sender, EventArgs e)
        {
            string examCode = txtMaDe.Text;
            if (string.IsNullOrWhiteSpace(examCode))
            {
                MessageBox.Show("Không có mã đề thi để tải!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnDownloadFile.Enabled = false;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel|*.xlsx|All Files|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    await DownloadFileAsync(examCode, sfd.FileName);
                }
            }
            btnDownloadFile.Enabled = true;
            MessageBox.Show("Đã tải file đề thi về máy!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveExam_Click(object sender, EventArgs e)
        {
            string examCode = txtMaDe.Text;
            string creatorCode = txtMaNguoiDung.Text;
            string password = txtMatKhauDe.Text;
            string danhSachThi = txtDanhSachThi.Text;
            DateTime startTime = dtpThoiGianBatDau.Value;
            DateTime endTime = dtpThoiGianKetThuc.Value;
            int status = cbStatus.Items.IndexOf(cbStatus.SelectedItem);
            bool isValidFile = txtValidFile.Text == "Yes";

            if (string.IsNullOrWhiteSpace(examCode) || string.IsNullOrWhiteSpace(creatorCode) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(danhSachThi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đề thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(startTime < DateTime.Now)
            {
                MessageBox.Show("Thời gian bất đầu phải lớn hơn thời gian hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (startTime >= endTime)
            {
                MessageBox.Show("Thời gian kết thúc phải lớn hơn thời gian bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtValidFile.Text) || !isValidFile)
            {
                MessageBox.Show("File đề thi không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_isEditingExam)
            {
                int query = _dbHelper.ExecuteSqlNonQuery($"EXEC sp_UpdateDeThi @MaDe = '{examCode}', @MaNguoiDung = '{creatorCode}', @MatKhau = '{password}', @ThoiGianBatDau = '{startTime.ToString("yyyy-MM-dd HH:mm:ss")}', @ThoiGianKetThuc = '{endTime.ToString("yyyy-MM-dd HH:mm:ss")}', @TrangThai = '{status}', @DanhSachThi = '{danhSachThi}', @ViTriFileDe = '{txtViTriFileDe.Text}'");
                if (query > 0)
                {
                    MessageBox.Show($"Đã sửa đề thi:\nMã đề: {examCode}\nNgười tạo: {creatorCode}\nTrạng thái: {status}\nFile: {txtViTriFileDe.Text}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Không thể lưu đề thi. Dữ liệu chưa đuọc lưu vào hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int query = _dbHelper.ExecuteSqlNonQuery($"EXEC sp_InsertDeThi @MaDe = '{examCode}', @MaNguoiDung = '{creatorCode}', @MatKhau = '{password}', @ThoiGianBatDau = '{startTime.ToString("yyyy-MM-dd HH:mm:ss")}', @ThoiGianKetThuc = '{endTime.ToString("yyyy-MM-dd HH:mm:ss")}', @TrangThai = '{status}', @DanhSachThi = '{danhSachThi}', @ViTriFileDe = '{txtViTriFileDe.Text}'");
                if (query > 0)
                {
                    MessageBox.Show($"Đã lưu đề thi:\nMã đề: {examCode}\nNgười tạo: {creatorCode}\nTrạng thái: {status}\nFile: {txtViTriFileDe.Text}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Không thể lưu đề thi. Dữ liệu chưa đuọc lưu vào hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadTreeViewData();
        }

        private void btnDeleteExam_Click(object sender, EventArgs e)
        {
            string examCode = txtMaDe.Text;

            if (string.IsNullOrWhiteSpace(examCode))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đề thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int query = _dbHelper.ExecuteSqlNonQuery($"EXEC sp_DeleteDeThi @MaDe = '{examCode}'");
            if (query > 0)
            {
                MessageBox.Show($"Đã xóa đề thi:\nMã đề: {examCode}",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Không thể xóa đề thi. Dữ liệu chưa đuọc lưu vào hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ResetValues();
            LoadTreeViewData();
        }

        private void btnThemDe_Click(object sender, EventArgs e)
        {
            ResetValues();
            _isEditingExam = false;
        }

        private void examTreeView_Click(object sender, EventArgs e)
        {
            if (_dataTable != null)
            {
                foreach (DataRow row in _dataTable.Rows)
                {
                    try
                    {
                        if (examTreeView.SelectedNodes[0].Text == row["MaDe"].ToString())
                        {
                            _isEditingExam = true;
                            txtMaDe.Text = row["MaDe"].ToString();
                            txtMaNguoiDung.Text = row["MaNguoiDung"].ToString();
                            txtMatKhauDe.Text = row["MatKhau"].ToString();
                            dtpThoiGianBatDau.Value = DateTime.Parse(row["ThoiGianBatDau"].ToString());
                            dtpThoiGianKetThuc.Value = DateTime.Parse(row["ThoiGianKetThuc"].ToString());
                            txtViTriDanhSachThi.Text = string.IsNullOrWhiteSpace(row["DanhSachThi"].ToString()) ? "Chưa có danh sách" : "Danh sách tồn tại";
                            txtDanhSachThi.Text = row["DanhSachThi"].ToString();
                            cbStatus.SelectedItem = cbStatus.Items[int.Parse(row["TrangThai"].ToString())];
                            txtViTriFileDe.Text = row["ViTriFileDe"].ToString();
                            if (!string.IsNullOrWhiteSpace(txtViTriFileDe.Text))
                            {
                                txtValidFile.Text = "Yes";
                                btnDownloadFile.Enabled = true;
                            }
                            else
                            {
                                txtValidFile.Text = "Chưa chọn";
                                btnDownloadFile.Enabled = false;
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                CrownMessageBox.ShowWarning("Xin đợi dữ liệu tải trước khi chọn!", "Đang tải dữ liệu đề thi");
                _isEditingExam = false;
            }
        }

        #region Function
        private void LoadStatusComboBox()
        {
            cbStatus.Items.Clear();
            cbStatus.Items.Add(new CrownDropDownItem("Không được thi"));
            cbStatus.Items.Add(new CrownDropDownItem("Được thi"));
            cbStatus.SelectedItem = cbStatus.Items[0];
        }

        private void ResetValues()
        {
            _isEditingExam = false;
            txtMaDe.Clear();
            txtMaNguoiDung.Text = _currentMaNguoiDung;
            txtMatKhauDe.Clear();
            txtViTriFileDe.Clear();
            txtValidFile.Text = "Chưa chọn";
            btnDownloadFile.Enabled = false;
            txtViTriDanhSachThi.Clear();
            txtDanhSachThi.Clear();
            dtpThoiGianBatDau.Value = DateTime.Now;
            dtpThoiGianKetThuc.Value = DateTime.Now.AddHours(1);
            cbStatus.SelectedItem = cbStatus.Items[0];
        }

        private async Task LoadTreeViewDataAsync()
        {
            _dataTable = await _dbHelper.ExecuteSqlReaderAsync("SELECT * FROM DeThi");

            examTreeView.Nodes.Clear();

            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                CrownTreeNode node = new(_dataTable.Rows[i]["MaDe"].ToString())
                {
                    Icon = Properties.Resources.document_16xLG
                };

                examTreeView.Nodes.Add(node);
            }

            _tree = examTreeView;
        }
        private void LoadTreeViewData()
        {
            _dataTable = _dbHelper.ExecuteSqlReader("SELECT * FROM DeThi");

            examTreeView.Nodes.Clear();

            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                CrownTreeNode node = new(_dataTable.Rows[i]["MaDe"].ToString())
                {
                    Icon = Properties.Resources.document_16xLG
                };

                examTreeView.Nodes.Add(node);
            }

            _tree = examTreeView;
        }

        private async Task<string> UploadFileAsync(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                {
                    CrownMessageBox.ShowError("Xin chọn file hợp lệ.", "Error");
                    return string.Empty;
                }

                long totalBytes = new FileInfo(filePath).Length;
                long bytesUploaded = 0;

                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var call = _client.UploadExamPaper(_headers);

                    byte[] buffer = new byte[4096]; // Buffer
                    int bytesRead;

                    while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await call.RequestStream.WriteAsync(new UploadRequest { ExamId = txtMaDe.Text, Data = Google.Protobuf.ByteString.CopyFrom(buffer, 0, bytesRead) });
                        bytesUploaded += bytesRead;

                        // Cập nhật thanh quá trình
                        UpdateProgressBar(bytesUploaded, totalBytes);
                    }

                    await call.RequestStream.CompleteAsync();

                    var response = await call.ResponseAsync;
                    if (response.ResponseCode == (int)HttpStatusCode.OK)
                    {
                        return response.ResponseMessage;
                    }
                    else
                    {
                        MessageBox.Show($"Đã xảy ra lỗi khi gửi file: {response.ResponseMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return response.ResponseMessage;
                    }
                }
            }
            catch (Grpc.Core.RpcException ex)
            {
                MessageBox.Show($"gRPC Error: {ex.Status.Detail}", "gRPC Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có một lỗi xảy ra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private async Task DownloadFileAsync(string examId, string destinationFilePath)
        {
            try
            {
                var request = new DownloadRequest { ExamId = examId };
                using (var response = _client.DownloadExamPaper(request, _headers))
                {
                    using (FileStream fileStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                    {
                        await foreach (var responseChunk in response.ResponseStream.ReadAllAsync())
                        {
                            fileStream.Write(responseChunk.Data.ToByteArray());
                        }
                    }
                }
            }
            catch (RpcException ex)
            {
                MessageBox.Show($"gRPC Error: {ex.Status.Detail}", "gRPC Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có một lỗi xảy ra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProgressBar(long bytesUploaded, long totalBytes)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<long, long>(UpdateProgressBar), bytesUploaded, totalBytes);
            }
            else
            {
                if (totalBytes > 0)
                {
                    int percentage = (int)((double)bytesUploaded / totalBytes * 100);
                    stripProgressBar.Value = Math.Min(percentage, stripProgressBar.Maximum);
                    statusLabel.Text = $"Đã tải: {percentage}%";
                }
                else
                {
                    stripProgressBar.Value = 0;
                    statusLabel.Text = "Đang đợi";
                }
            }
        }
        #endregion
    }
}