using System.Net.Mail;
using System.Threading.Tasks;
using BlogEngine.Subscriptions.Application.Abstractions;

namespace BlogEngine.Subscriptions.Infrastructure.Smtp
{
    public sealed class SmtpEmailService : IEmailService
    {
        private readonly SmtpClient _client;

        public SmtpEmailService(SmtpClient client)
        {
            _client = client;
        }

        public Task Send(string to, string from, string subject, string body)
        {
            return _client.SendMailAsync(new MailMessage(from, to, subject, body));
        }
    }
}