using ExamProto;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentApp
{
    public partial class ExamForm : Form
    {
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        // Dữ liệu thi
        private ExamData _data;

        // Kết nối máy chủ ExamServer
        private readonly ExamService.ExamServiceClient _client;
        private string _accessToken;

        // Kiểm tra người dùng đã hoàn thành bài thi hay chưa (cho nút Finish)
        private bool _userFinishedExam;

        public ExamForm(ExamService.ExamServiceClient client, string accessToken, ExamData data)
        {
            InitializeComponent();
            // MONKE Anticheat: Giấu cửa sổ thi khỏi phần mềm quay fim
            ExamForm.SetWindowDisplayAffinity(base.Handle, 1U);

            _client = client;
            _accessToken = accessToken;
            _data = data;
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
        }

        private void crownButtonFinish_Click(object sender, EventArgs e)
        {
            if(_userFinishedExam)
            {
                Application.Exit();
            }
            else
            {
                DialogResult result = CrownMessageBox.ShowInformation("Bạn có chắc chắn muốn hoàn thành bài thi?", "Xác nhận", ReaLTaiizor.Enum.Crown.DialogButton.YesNo);
                if (result == DialogResult.Yes)
                {
                    panel1.Hide();
                    _userFinishedExam = true;
                }
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

        }
    }
}
    

