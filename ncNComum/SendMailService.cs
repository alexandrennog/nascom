using System.Net;
using System.Net.Mail;

namespace ncNComum
{
    public class SendMailService
    {
        private string _from;
        private string _to;
        private string _password;
        private string _subject;
        private string _body;

        public SendMailService(string from, string to, string password, string subject, string body)
        {
            _from = from;
            _to = to;
            _password = password;
            _subject = subject;
            _body = body;
        }

        public void Send()
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Credentials = new NetworkCredential(_from, _password)
            };

            using (var message = new MailMessage(_from, _to)
            {
                Subject = _subject,
                Body = _body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
