using ManagementApp.CustomControls;
using ReaLTaiizor.Child.Crown;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Docking.Crown;
using ReaLTaiizor.Native;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public QuanLyDeThiForm(AdminServiceClient client, Grpc.Core.Metadata headers)
        {
            InitializeComponent();
            _client = client;
            _headers = headers;

            // Thêm bộ lọc sự kiện cuộn chuột
            Application.AddMessageFilter(new ControlScrollFilter());
        }

        private void QuanLyDeThiForm_Load(object sender, EventArgs e)
        {
            LoadExamTreeView();
            LoadStatusComboBox();
        }

        private void LoadExamTreeView()
        {
            examTreeView.Nodes.Clear();
            int childCount = 0;

            for (int i = 0; i < 9; i++)
            {
                CrownTreeNode node = new($"SD180{i}")
                {
                    ExpandedIcon = Properties.Resources.folder_16x,
                    Icon = Properties.Resources.folder_Closed_16xLG
                };

                for (int x = 0; x < 10; x++)
                {
                    CrownTreeNode childNode = new($"SD180{i}-De{childCount}")
                    {
                        Icon = Properties.Resources.document_16xLG
                    };
                    childCount++;
                    node.Nodes.Add(childNode);
                }

                examTreeView.Nodes.Add(node);
            }
        }

        private void LoadStatusComboBox()
        {
            cbStatus.Items.Clear();
            cbStatus.Items.Add(new CrownDropDownItem("Được thi"));
            cbStatus.Items.Add(new CrownDropDownItem("Không được thi"));
            cbStatus.SelectedItem = cbStatus.Items[0];
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF Files|*.pdf|Word Files|*.docx|All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = ofd.FileName;
                    txtFilePath.Text = selectedFilePath;
                    lblValidFile.Text = IsValidExamFile(selectedFilePath) ? "Hợp lệ" : "Không hợp lệ";
                }
            }
        }

        private bool IsValidExamFile(string filePath)
        {
            return File.Exists(filePath) && (filePath.EndsWith(".pdf") || filePath.EndsWith(".docx"));
        }

        private void btnSaveExam_Click(object sender, EventArgs e)
        {
            string examCode = txtExamCode.Text;
            string creatorCode = txtCreatorCode.Text;
            string password = txtExamPassword.Text;
            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = dtpEndTime.Value;
            string status = cbStatus.SelectedItem.ToString();
            bool isValidFile = lblValidFile.Text == "Hợp lệ";

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

            if (string.IsNullOrEmpty(selectedFilePath) || !isValidFile)
            {
                MessageBox.Show("File đề thi không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Giả lập lưu dữ liệu (Thực tế sẽ lưu vào DB)
            MessageBox.Show($"Đã lưu đề thi:\nMã đề: {examCode}\nNgười tạo: {creatorCode}\nTrạng thái: {status}\nFile: {selectedFilePath}",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteExam_Click(object sender, EventArgs e)
        {
            txtExamCode.Clear();
            txtCreatorCode.Clear();
            txtExamPassword.Clear();
            txtFilePath.Clear();
            lblValidFile.Text = "Chưa chọn";
            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now.AddHours(1);
            cbStatus.SelectedItem = cbStatus.Items[0];

            MessageBox.Show("Đã xóa thông tin đề thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sectionPanelEditor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
