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
                string maSV = textBoxTimKiem.Text.Trim();
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
                string maDe = TextBoxTimKimTheoDe.Text.Trim();
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

        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}