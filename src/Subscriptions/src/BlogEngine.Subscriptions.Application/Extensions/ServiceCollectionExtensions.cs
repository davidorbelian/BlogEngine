using BlogEngine.Subscriptions.Application.Abstractions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Subscriptions.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services
                .AddMediatR(typeof(ISubscriptionsContext));
        }
    }
}