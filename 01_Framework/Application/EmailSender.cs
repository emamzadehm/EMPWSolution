using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace _01_Framework.Application
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string title, string messageBody, string destination)
        {
            var message = new MimeMessage();

            var from = new MailboxAddress("Info", "info@azwellis.com");
            //var from = new MailboxAddress("Info", "emamzadeha@aol.com");
            
            message.From.Add(from);

            var to = new MailboxAddress("User", "emamzadehm@gmail.com");
            message.To.Add(to);

            message.Subject = title;
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<h1>{messageBody}</h1>",
            };

            message.Body = bodyBuilder.ToMessageBody();

            var client = new SmtpClient();
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            client.CheckCertificateRevocation = false;
            client.Connect("webmail.azwellis.com", 25, SecureSocketOptions.Auto);
            //client.Connect("smtp.aol.com", 465, SecureSocketOptions.Auto);
            client.Authenticate("info@azwellis.com", "Amin8191314801!");
            //client.Authenticate("emamzadeha@aol.com", "hani3205");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
