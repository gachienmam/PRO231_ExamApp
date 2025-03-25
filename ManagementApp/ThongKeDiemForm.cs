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

namespace ManagementApp
{
    public partial class ThongKeDiemForm : Form
    {
        private readonly AdminServiceClient _client;
        private readonly string _accessToken;
        private readonly Grpc.Core.Metadata _headers;

        public ThongKeDiemForm(AdminServiceClient client, string accessToken)
        {
            InitializeComponent();
            _client = client;
            _accessToken = accessToken;
            _headers = new Grpc.Core.Metadata
                {
                    { "Authorization", $"Bearer {_accessToken}" }
                };
        }

        private void BUTTON_THOAT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BUTTON_XEMDS_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new CommandRequest()
                {
                    RequestCode = (int)RemoteCommandType.SQL,
                    Command = "SELECT * FROM KetQuaThi"
                };

                var response = _client.ExecuteRemoteCommand(request, _headers);

                if (response.ResponseCode == (int)HttpStatusCode.OK)
                {
                    DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(response.ResponseMessage);
                    //DataTable dataTable = ConvertToDataTable(response.ResponseMessage);
                    if (dataTable == null)
                    {
                        CrownMessageBox.ShowError($"Lỗi khi hiển thị bảng: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                    }
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    CrownMessageBox.ShowError($"Lỗi: {response.ResponseMessage}", "Lỗi chạy SQL", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                }
            }
            catch (Exception ex)
            {
                CrownMessageBox.ShowError($"Lỗi: {ex.Message}", "Lỗi kết nối", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
            }
        }

        private DataTable ConvertToDataTable(string data)
        {
            DataTable dataTable = new DataTable();
            string[] rows = data.Split('\n');
            if (rows.Length > 0)
            {
                string[] headers = rows[0].Split(',');
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }

                for (int i = 1; i < rows.Length; i++)
                {
                    string[] cells = rows[i].Split(',');
                    dataTable.Rows.Add(cells);
                }
            }
            return dataTable;
        }

        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt;

                // Kiểm tra nếu DataSource đang là DataView thì lấy bảng gốc
                if (dataGridView1.DataSource is DataView dvSource)
                {
                    dt = dvSource.Table;
                }
                else
                {
                    dt = (DataTable)dataGridView1.DataSource;
                }

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
                string maSV = textBoxTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(maSV))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên để tìm kiếm.");
                    return;
                }

                DataTable dt = (DataTable)dataGridView1.DataSource;
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
    }
}