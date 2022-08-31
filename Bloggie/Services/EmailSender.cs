using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace Bloggie.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mail = new MailMessage(_configuration["EmailUserName"], email, subject, htmlMessage);
            mail.IsBodyHtml = true;

            using (var client = new SmtpClient("mail.kod.fun", 587))
            {
                client.Credentials = new NetworkCredential(_configuration["EmailUserName"], _configuration["EmailPassword"]);
                client.EnableSsl = true;
                await client.SendMailAsync(mail);
            }
        }
    }
}
