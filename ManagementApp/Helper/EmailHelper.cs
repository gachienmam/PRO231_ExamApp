using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp.Helper
{
    internal class EmailHelper
    {
        public void SendMail(string email, string header, string content)
        {
            try
            {
                //Confirmation After Click the Button
                MessageBox.Show("Mot Email cap nhat mat khau da duoc goi toi ban!");

                //Now we must create a new Smtp client to send our email.
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);   //smtp.gmail.com // For Gmail
                //Authentication.
                //This is where the valid email account comes into play. You must have a valid email
                //account(with password) to give our program a place to send the mail from.
                NetworkCredential cred = new NetworkCredential("datcdttd00792@fpt.edu.vn", "jhzpnixjjeinxmhr");
                //To send an email we must first create a new mailMessage(an email) to send.
                MailMessage Msg = new MailMessage()
                {
                    From = new MailAddress("datcdttd00792@fpt.edu.vn"),
                    Subject = $"[PolyTest System] {header}",
                    Body = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>N2 QLBH SOF2051</title>\r\n    <style>\r\n        body {{\r\n            font-family: Segoe UI, sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }}\r\n        .container {{\r\n            width: 100%;\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            background-color: #ffffff;\r\n            padding: 20px;\r\n            border-radius: 8px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }}\r\n        .header {{\r\n            text-align: center;\r\n            padding: 20px 0;\r\n            background-color: #007BFF;\r\n            color: #ffffff;\r\n            border-radius: 8px 8px 0 0;\r\n        }}\r\n        .headerImage {{\r\n            text-align: center\r\n        }}\r\n\t.headerImage img{{\r\n            padding: 20px;            \r\n            border-radius: 128px;\r\n            width: 256px;\r\n\t}}\r\n        .header h1 {{\r\n            margin: 0;\r\n        }}\r\n        .content {{\r\n            padding: 20px;\r\n            color: #333333;\r\n        }}\r\n        .content p {{\r\n            line-height: 1.6;\r\n        }}\r\n        .footer {{\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            background-color: #f4f4f4;\r\n            color: #777777;\r\n            border-radius: 0 0 8px 8px;\r\n        }}\r\n        .footer p {{\r\n            margin: 0;\r\n        }}\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"headerImage\">\r\n           <img class=\"headerImage\" src=\"cid:logoImage\"/>\r\n        </div>\r\n        <div class=\"header\">\r\n            <h1>Quản lý bán hàng</h1>\r\n            <h2>By Nhóm 2</h2>\r\n        </div>\r\n        <div class=\"content\">\r\n            <p>Xin chào {email},</p>\r\n            <p>Tài khoản của bạn đã có hành động thay đổi mật khẩu.</p>\r\n            <p>Nếu đây không phải là bạn, xin hãy liên lạc Admin ngay nhé</p>\r\n            <p>Trân trọng,<br>Nhóm 2</p>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p>&copy; 2025 Nhóm 2. Bảo lưu mọi quyền. Trộm thì ra đường gặp nhiều xui xẻo</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>"
                };
                // Recipient e-mail address.
                Msg.To.Add(email);
                Msg.IsBodyHtml = true;

                // Add logo image hihi
                Attachment logoImage = new Attachment($"{Environment.CurrentDirectory}\\Resources\\logoImage.png");
                logoImage.ContentId = "logoImage";
                logoImage.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                logoImage.ContentDisposition.Inline = true;
                Msg.Attachments.Add(logoImage);
                // Send our account login details to the client.
                client.Credentials = cred;
                //Enabling SSL(Secure Sockets Layer, encyription) is reqiured by most email providers to send mail
                client.EnableSsl = true;
                client.Send(Msg);// Send our email.
            }
            catch (Exception ex)
            {
                // If Mail Doesnt Send Error Mesage Will Be Displayed
                MessageBox.Show(ex.Message);
            }
        }
    }
}
