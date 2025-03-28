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
        public static void SendMail(string email, string emailSubject, string emailBody)
        {
            try
            {
                //MessageBox.Show("Mot Email cap nhat mat khau da duoc goi toi ban!");

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
                    Subject = $"[PolyTest System] {emailSubject}",
                    Body = emailBody,
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
                //Enabling SSL(Secure Sockets Layer, encryption) is reqiured by most email providers to send mail
                client.EnableSsl = true;
                client.Send(Msg);// Send our email.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
