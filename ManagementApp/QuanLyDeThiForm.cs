using ManagementApp.AdminProto;
using ManagementApp.CustomControls;
using ManagementApp.Database;
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
        private readonly List<CrownDockContent> _tools = new();
        private readonly TreeViewControl _dockTreeView;
        private string selectedFilePath = "";

        private readonly AdminServiceClient _client;
        private readonly Grpc.Core.Metadata _headers;

        private DataTable _dataTable;
        private CrownTreeView _tree;
        private GrpcDatabaseHelper _dbHelper;

        public QuanLyDeThiForm(AdminServiceClient client, Grpc.Core.Metadata headers)
        {
            InitializeComponent();
            _client = client;
            _headers = headers;

            _dbHelper = new GrpcDatabaseHelper(_client, _headers);
            // Thêm bộ lọc sự kiện cuộn chuột
            Application.AddMessageFilter(new ControlScrollFilter());
        }

        private async void QuanLyDeThiForm_Load(object sender, EventArgs e)
        {
            await LoadTreeViewDataAsync();
            LoadStatusComboBox();
        }

        private void LoadStatusComboBox()
        {
            cbStatus.Items.Clear(); 
            cbStatus.Items.Add(new CrownDropDownItem("Không được thi"));
            cbStatus.Items.Add(new CrownDropDownItem("Được thi"));
            cbStatus.SelectedItem = cbStatus.Items[0];
        }

        private async void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel|*.xlsx|All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    stripProgressBar.Visible = false;
                    stripProgressBar.Value = 0;
                    statusLabel.Text = "Đã tải: 0%";
                    stripProgressBar.Visible = true;
                    //lblValidFile.Text = await UploadFileAsync(filePath);

                    // Hide
                    txtViTriFileDe.Text = ofd.FileName;
                    stripProgressBar.Visible = false;
                    stripProgressBar.Value = 0;
                    statusLabel.Text = "Đang đợi";
                    //lblValidFile.Text = IsValidExamFile(selectedFilePath) ? "Yes" : "No";
                    txtValidFile.Text = "Yes";
                    
                }
            }
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
                        await call.RequestStream.WriteAsync(new UploadExamFileChunk { Data = Google.Protobuf.ByteString.CopyFrom(buffer, 0, bytesRead) });
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
                MessageBox.Show($"gRPC Error during upload: {ex.Status.Detail}", "gRPC Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during upload: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
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

        private bool IsValidExamFile(string filePath)
        {
            return File.Exists(filePath) && (filePath.EndsWith(".pdf") || filePath.EndsWith(".docx"));
        }

        private void btnSaveExam_Click(object sender, EventArgs e)
        {
            string examCode = txtMaDe.Text;
            string creatorCode = txtMaNguoiDung.Text;
            string password = txtMatKhauDe.Text;
            DateTime startTime = dtpThoiGianBatDau.Value;
            DateTime endTime = dtpThoiGianKetThuc.Value;
            int status = cbStatus.Items.IndexOf(cbStatus.SelectedItem);
            bool isValidFile = txtValidFile.Text == "Yes";

            if (string.IsNullOrWhiteSpace(examCode) || string.IsNullOrWhiteSpace(creatorCode) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đề thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            _dbHelper.ExecuteSqlNonQuery("EXEC sp_InsertDeThi MaDe, MaNguoiDung, MatKhau, ThoiGianBatDau, ThoiGianKetThuc, TrangThai, DanhSachThi, ViTriFileDe");
            // Giả lập lưu dữ liệu (Thực tế sẽ lưu vào DB)
            MessageBox.Show($"Đã lưu đề thi:\nMã đề: {examCode}\nNgười tạo: {creatorCode}\nTrạng thái: {status}\nFile: {selectedFilePath}",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteExam_Click(object sender, EventArgs e)
        {
            ResetValues();

            MessageBox.Show("Đã xóa thông tin đề thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThemDe_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void ResetValues()
        {
            txtMaDe.Clear();
            txtMaNguoiDung.Clear();
            txtMatKhauDe.Clear();
            txtViTriFileDe.Clear();
            txtValidFile.Text = "Chưa chọn";
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

        private void examTreeView_Click(object sender, EventArgs e)
        {
            if(_dataTable != null)
            {
                foreach (DataRow row in _dataTable.Rows)
                {
                    try
                    {
                        if (examTreeView.SelectedNodes[0].Text == row["MaDe"].ToString())
                        {
                            txtMaDe.Text = row["MaDe"].ToString();
                            txtMaNguoiDung.Text = row["MaNguoiDung"].ToString();
                            txtMatKhauDe.Text = row["MatKhau"].ToString();
                            dtpThoiGianBatDau.Value = DateTime.Parse(row["ThoiGianBatDau"].ToString());
                            dtpThoiGianKetThuc.Value = DateTime.Parse(row["ThoiGianKetThuc"].ToString());
                            cbStatus.SelectedItem = cbStatus.Items[int.Parse(row["TrangThai"].ToString())];
                            txtViTriFileDe.Text = row["ViTriFileDe"].ToString();
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
            }
        }
    }
}
