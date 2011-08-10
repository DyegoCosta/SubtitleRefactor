using System;
using System.IO;
using System.Net.Mail;

namespace SubRefactor.Library.Infrastructure
{
    public class Mail
    {
        public void SendMail(string smtpClient, string fromEmail, string toEmail, string subject, string body, Stream attachment, string attachmentName)
        {
            try
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient(smtpClient);
                mail.From = new MailAddress(fromEmail, "SubRefactor");
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                
                mail.Attachments.Add(new Attachment(attachment, attachmentName));

                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential("dyego.costa@live.com", "4141230211");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
