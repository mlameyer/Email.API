using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Email.API.Repositories
{
    public class SendEmailRepository : ISendEmailRepository
    {
        public void SendEmail(string name, string sendEmailAddress, string subject, string message)
        {
            string userName = "zuckwheat@hotmail.com";
            string passWord = "Ml74108520*";
            string server = "smtp-mail.outlook.com";
            int port = 587;//587

            SmtpClient client = new SmtpClient(server, port);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(userName, passWord);

            MailAddress from = new MailAddress(userName);
            MailAddress to = new MailAddress("matthew.lameyer@gmail.com");
            MailMessage msg = new MailMessage(from, to)
            {
                Body = sendEmailAddress + "===>" + name + "===>" + message
            };
            // Include some non-ASCII characters in body and subject.
            msg.Body += Environment.NewLine;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.Subject = subject;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            
            client.Send(msg);

            msg.Dispose();
        }
    }
}
