using System.Net;
using System.Net.Mail;
using BlogEngine.Subscriptions.Application.Abstractions;
using BlogEngine.Subscriptions.Infrastructure.Smtp.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Subscriptions.Infrastructure.Smtp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSmtpInfrastructure(
            this IServiceCollection services,
            SmtpConfiguration configuration)
        {
            return services
                .AddSingleton(CreateSmtpClient(configuration))
                .AddSingleton<IEmailService, SmtpEmailService>();
        }

        private static SmtpClient CreateSmtpClient(SmtpConfiguration configuration)
        {
            var client = new SmtpClient
            {
                Host = configuration.Host,
                Port = configuration.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            if (!string.IsNullOrEmpty(configuration.Username) && !string.IsNullOrEmpty(configuration.Password))
                client.Credentials = new NetworkCredential(configuration.Username, configuration.Password);

            return client;
        }
    }
}