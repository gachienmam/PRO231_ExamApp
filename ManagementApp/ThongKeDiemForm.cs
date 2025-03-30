using ExamLibrary.Enum;
using System;
using System.Data;
using System.Net;
using System.Text;
using System.Windows.Forms;
using ManagementApp.AdminProto;
using static ManagementApp.AdminProto.AdminService;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ReaLTaiizor.Controls;
using ManagementApp.Database;
using ManagementApp.Helper;
using System.Diagnostics.Eventing.Reader;

namespace ManagementApp
{
    public partial class ThongKeDiemForm : Form
    {
        private readonly AdminServiceClient _client;
        private readonly Grpc.Core.Metadata _headers;

        private readonly GrpcDatabaseHelper _dbHelper;

        private DataTable _dataTable;

        public ThongKeDiemForm(AdminServiceClient client, Grpc.Core.Metadata headers)
        {
            InitializeComponent();
            _client = client;
            _headers = headers;

            _dbHelper = new GrpcDatabaseHelper(_client, _headers);
        }

        private async void ThongKeDiemForm_Load(object sender, EventArgs e)
        {
            await LoadDataGridView();
        }

        #region Control Action Events
        private void BUTTON_THOAT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BUTTON_XEMDS_Click(object sender, EventArgs e)
        {
            await LoadDataGridView();
        }

        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = _dataTable;
                dataGridView1.DataSource = _dataTable;

                if (CheckBoxDau.Checked && CheckBoxRot.Checked)
                {
                    // Hiển thị toàn bộ danh sách
                    dataGridView1.DataSource = dt;
                }
                else if (CheckBoxDau.Checked)
                {
                    // Hiển thị thí sinh đậu (điểm >= 5)
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "Diem >= 5";
                    dataGridView1.DataSource = dv;
                }
                else if (CheckBoxRot.Checked)
                {
                    // Hiển thị thí sinh rớt (điểm < 5)
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "Diem < 5";
                    dataGridView1.DataSource = dv;
                }
                else
                {
                    // Không chọn gì thì xóa dữ liệu hiển thị
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void BUTTON_XUATDS_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.DataSource is DataTable dt)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "CSV files (*.csv)|*.csv",
                        Title = "Lưu danh sách điểm"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder sb = new StringBuilder();
                        string[] columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
                        sb.AppendLine(string.Join(",", columnNames));

                        foreach (DataRow row in dt.Rows)
                        {
                            string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                            sb.AppendLine(string.Join(",", fields));
                        }

                        System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                        MessageBox.Show("Xuất file thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = textBoxTimKiemTheoMaThiSinh.Text.Trim();
                if (string.IsNullOrEmpty(maSV))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên để tìm kiếm.");
                    return;
                }

                DataTable dt = _dataTable;
                dataGridView1.DataSource = _dataTable;
                if (dt != null)
                {
                    DataView dv = new DataView(dt);
                    dv.RowFilter = $"MaThiSinh = '{maSV}'";
                    dataGridView1.DataSource = dv;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để tìm kiếm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        #endregion

        #region Function
        private async Task LoadDataGridView()
        {
            _dataTable = await _dbHelper.ExecuteSqlReaderAsync("SELECT * FROM KetQuaThi");
            dataGridView1.DataSource = _dataTable;
        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void crownSectionPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonTimKiemTheoDe_Click(object sender, EventArgs e)
        {
            try
            {
                string maDe = textBoxTimKiemTheoMaDe.Text.Trim();
                if (string.IsNullOrEmpty(maDe))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên để tìm kiếm.");
                    return;
                }

                DataTable dt = _dataTable;
                dataGridView1.DataSource = _dataTable;
                if (dt != null)
                {
                    DataView dv = new DataView(dt);
                    dv.RowFilter = $"MaDe = '{maDe}'";
                    dataGridView1.DataSource = dv;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để tìm kiếm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void buttonGuiMail_Click(object sender, EventArgs e)
        {
            if(dataGridView1.DataSource.GetType() == typeof(DataView))
            {
                foreach (DataRow row in ((DataView)dataGridView1.DataSource).ToTable().Rows)
                {
                    float diem = float.Parse(row["Diem"].ToString());
                    bool isPassed = diem > 5;
                    SendMailToThiSinh(row["MaDe"].ToString(), _dbHelper.ExecuteSqlReader($"SELECT Email FROM ThiSinh WHERE MaThiSinh = '{row["MaThiSinh"]}'").Rows[0]["Email"].ToString(), diem, isPassed);
                }
            }
            else
            {
                foreach (DataRow row in ((DataTable)dataGridView1.DataSource).Rows)
                {
                    float diem = float.Parse(row["Diem"].ToString());
                    bool isPassed = diem > 5;
                    SendMailToThiSinh(row["MaDe"].ToString(), _dbHelper.ExecuteSqlReader($"SELECT Email FROM ThiSinh WHERE MaThiSinh = '{row["MaThiSinh"]}'").Rows[0]["Email"].ToString(), diem, isPassed);
                }
            }
            
        }

        private void SendMailToThiSinh(string maDe, string email, float diem, bool isPassed)
        {
            string PassOrFail = isPassed ? "Pass" : "Fail";
            string emailBody = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>PolyTest System</title>\r\n    <style>\r\n        body {{\r\n            font-family: Segoe UI, sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }}\r\n        .container {{\r\n            width: 100%;\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            background-color: #ffffff;\r\n            padding: 20px;\r\n            border-radius: 8px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }}\r\n        .header {{\r\n            text-align: center;\r\n            padding: 20px 0;\r\n            background-color: #007BFF;\r\n            color: #ffffff;\r\n            border-radius: 8px 8px 0 0;\r\n        }}\r\n        .headerImage {{\r\n            text-align: center\r\n        }}\r\n\t.headerImage img{{\r\n            padding: 20px;            \r\n            border-radius: 128px;\r\n            width: 256px;\r\n\t}}\r\n        .header h1 {{\r\n            margin: 0;\r\n        }}\r\n        .results-table {{\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n            margin-top: 20px;\r\n        }}\r\n        .results-table th, .results-table td {{\r\n            border: 1px solid #ddd;\r\n            padding: 8px;\r\n            text-align: left;\r\n        }}\r\n        .results-table th {{\r\n            background-color: #f2f2f2;\r\n        }}\r\n\r\n        .content {{\r\n            padding: 20px;\r\n            color: #333333;\r\n        }}\r\n        .content p {{\r\n            line-height: 1.6;\r\n        }}\r\n        .content .password-block {{\r\n            display: flex;\r\n            justify-content: center;\r\n            align-items: center;\r\n        }}\r\n        .footer {{\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            background-color: #f4f4f4;\r\n            color: #777777;\r\n            border-radius: 0 0 8px 8px;\r\n        }}\r\n        .footer p {{\r\n            margin: 0;\r\n        }}\r\n        .password {{\r\n            display: inline-block;\r\n            padding: 10px 20px;\r\n            margin: 20px 0;\r\n            background-color: #007BFF;\r\n            color: #ffffff;\r\n            text-decoration: none;\r\n            border-radius: 5px;\r\n        }}\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"headerImage\">\r\n           <img class=\"headerImage\" src=\"cid:logoImage\"/>\r\n        </div>\r\n        <div class=\"header\">\r\n            <h1>PolyTest System</h1>\r\n            <h2>By Pupu và những người bạn (Nhóm 2) </h2>\r\n        </div>\r\n        <div class=\"content\">\r\n            <p>Xin chào {email},</p>\r\n            <p>Chúc mừng bạn đã thi xong bài thi {maDe}.</p>\r\n            <p>Ở dưới là kết quả của bạn:</p>\r\n            <table class=\"results-table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>Loại</th>\r\n                    <th>Điểm</th>\r\n                    <th>Kết quả</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n                <tr>\r\n                    <td>MultipleChoice</td>\r\n                    <td>{diem}</td>\r\n                    <td>{PassOrFail}</td>\r\n                </tr>\r\n                </tbody>\r\n        </table>\r\n\r\n            <p>Sau khi nhận được email này, vui hay buồn thì không biết</p>\r\n            <p>Trân trọng, <br>PolyTest</p>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p>&copy; 2025 Nhóm 2. Bảo lưu mọi quyền. Trộm thì ra đường gặp nhiều xui xẻo</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>";
            EmailHelper.SendMail(email, $"Kết quả thi đề {maDe}", emailBody);
        }
    }
}