using System;
using BlogEngine.Messaging.RabbitMq.Configuration;

namespace BlogEngine.Messaging.RabbitMq.Extensions
{
    public static class RabbitMqConfigurationExtensions
    {
        public static Uri GetUri(this RabbitMqConfiguration configuration)
        {
            return new UriBuilder {Host = configuration.Host, Port = configuration.Port, Scheme = "rabbitmq"}.Uri;
        }
    }
}