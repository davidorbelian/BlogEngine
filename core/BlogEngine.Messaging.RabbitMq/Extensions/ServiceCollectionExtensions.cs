using System;
using BlogEngine.Messaging.RabbitMq.Configuration;
using BlogEngine.Messaging.RabbitMq.NotificationHandlers;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Messaging.RabbitMq.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMqMessaging(
            this IServiceCollection services,
            RabbitMqConfiguration configuration,
            params Action<IServiceCollectionBusConfigurator>[] addConsumerActions)
        {
            return services
                .AddScoped(typeof(INotificationHandler<>), typeof(DomainEventHandler<>))
                .AddMassTransit(x =>
                {
                    foreach (var addConsumerAction in addConsumerActions) addConsumerAction(x);

                    x.SetKebabCaseEndpointNameFormatter();
                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host(configuration.GetUri(), h =>
                        {
                            h.Username(configuration.Username);
                            h.Password(configuration.Password);
                        });

                        cfg.ConfigureEndpoints(context);
                    });
                })
                .AddMassTransitHostedService();
        }
    }
}