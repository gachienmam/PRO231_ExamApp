using ManagementApp.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ManagementApp.AdminProto.AdminService;

namespace ManagementApp
{
    public partial class DoiMatKhauForm : Form
    {
        private readonly AdminServiceClient _client;
        private readonly Grpc.Core.Metadata _headers;

        private GrpcDatabaseHelper _dbHelper;

        public DoiMatKhauForm(AdminServiceClient client, Grpc.Core.Metadata headers)
        {
            InitializeComponent();

            _client = client;
            _headers = headers;

            _dbHelper = new GrpcDatabaseHelper(_client, _headers);
        }

        private void BUTTONDOIMATKHAU_Click(object sender, EventArgs e)
        {

        }
    }
}
