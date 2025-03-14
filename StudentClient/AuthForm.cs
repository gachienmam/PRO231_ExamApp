using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthClient
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var authRequest = new AuthRequest { Username = "student1", Password = "pass123" };
            var authResponse = examClient.AuthenticateUser(authRequest);

            if (authResponse.ResponseCode == 200)
            {
                string token = authResponse.Token;
                Console.WriteLine("Authenticated! Token: " + token);
            }
        }
    }
}