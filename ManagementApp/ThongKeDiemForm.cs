using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BUTTON_THOAT_Click(object sender, EventArgs e)
        {

        }

        private void crownGroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
