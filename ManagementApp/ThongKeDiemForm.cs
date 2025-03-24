using AdminProto;
using ExamLibrary.Enum;
using System;
using System.Data;
using System.Net;
using System.Text;
using System.Windows.Forms;
using static AdminProto.AdminService;

namespace ManagementApp
{
    public partial class ThongKeDiemForm : Form
    {
        private readonly AdminServiceClient _client;
        private readonly string _accessToken;

        public ThongKeDiemForm(AdminServiceClient client, string accessToken)
        {
            InitializeComponent();
            _client = client;
            _accessToken = accessToken;
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
                    Command = "SELECT * FROM KETQUA"
                };

                var response = _client.ExecuteRemoteCommand(request);

                if (response.ResponseCode == (int)HttpStatusCode.OK)
                {
                    DataTable dataTable = ConvertToDataTable(response.ResponseMessage);
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show($"Lỗi: {response.ResponseMessage}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
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
                DataTable dt = (DataTable)dataGridView1.DataSource;
                if (dt != null)
                {
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "Diem >= 5"; // Giả sử cột Diem tồn tại
                    dataGridView1.DataSource = dv;
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
                    dv.RowFilter = $"MaSV = '{maSV}'";
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