using static ReaLTaiizor.Helper.CrownHelper;
using System.Configuration;
using Grpc.Net.Client;
using ExamProto;

namespace StudentApp
{
    public partial class DangNhapForm : Form
    {
        //private readonly ExamService _client;
        private readonly string _serverAddress;

        #region Constructor
        public DangNhapForm()
        {
            InitializeComponent();
        }

        public DangNhapForm(string serverAddress)
        {
            InitializeComponent();
            _serverAddress = serverAddress;

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var channel = GrpcChannel.ForAddress("https://localhost:5001",
                new GrpcChannelOptions { HttpHandler = handler });
            //_client = new AdminServiceClient(channel);
        }

        private void DangNhapForm_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["AppTheme"] == "light")
            {
                ThemeProvider.Theme = new LightTheme();
                Invalidate();
                Refresh();
            }
            else
            {
                ThemeProvider.Theme = new DarkTheme();
                Invalidate();
                Refresh();
            }
            this.Text += _serverAddress;
        }
        #endregion


        private void btnDangNhap_Click(object sender, EventArgs e)
        {

        }
    }
}
