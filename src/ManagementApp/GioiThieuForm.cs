using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementApp
{
    public partial class GioiThieuForm : Form
    {
        public GioiThieuForm()
        {
            InitializeComponent();
        }

        private void GioiThieuForm_Load(object sender, EventArgs e)
        {
            textBoxAuthors.Text =
                "Nhóm 2: Pupu và những người bạn (SD1802)\r\n\r\n" +
                "Cao Đặng Thành Đạt - TD00792\r\n" +
                "Phạm Hồng Khoa - TD00752\r\n" +
                "Vũ Thiên Trường - TD00877\r\n" +
                "Vũ Văn Thành - TD00701\r\n" +
                "Trần Công Hoàng Phúc - TD00840\r\n" +
                "Đinh Văn Tâm - TD00823";
        }
    }
}
