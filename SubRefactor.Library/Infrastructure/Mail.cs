using System;
using System.IO;
using System.Net.Mail;

namespace SubRefactor.Library.Infrastructure
{
    public class Mail
    {
        public void SendMail(string smtpClientUrl, int port, string fromEmail, string toEmail, string subject, string body, Stream attachment, string attachmentName)
        {
            try
            {
                var mail = new MailMessage();
                var smtpClient = new SmtpClient(smtpClientUrl);
                mail.From = new MailAddress(fromEmail, "SubRefactor");
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.ReplyToList.Add(new MailAddress("contact@subrefactor.com"));
               
                attachment.Position = 0;
                mail.Attachments.Add(new Attachment(attachment, attachmentName));

                smtpClient.Port = port;
                smtpClient.Credentials = new System.Net.NetworkCredential("translate@subrefactor.com", "rqrqweowqq");
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static Stream CopyStream(Stream inputStream)
        {
            const int readSize = 256;
            var buffer = new byte[readSize];
            var ms = new MemoryStream();

            var count = inputStream.Read(buffer, 0, readSize);
            while (count > 0)
            {
                ms.Write(buffer, 0, count);
                count = inputStream.Read(buffer, 0, readSize);
            }

            ms.Seek(0, SeekOrigin.Begin);
            inputStream.Seek(0, SeekOrigin.Begin);

            return ms;
        }  
    }
}
