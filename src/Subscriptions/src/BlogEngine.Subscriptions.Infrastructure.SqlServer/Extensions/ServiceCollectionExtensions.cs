using BlogEngine.Infrastructure.Core.Extensions;
using BlogEngine.Subscriptions.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Subscriptions.Infrastructure.SqlServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlServerInfrastructure(
            this IServiceCollection services,
            string connectionString)
        {
            return services
                .AddInfrastructureCore<ISubscriptionsContext, SubscriptionsContext>(o =>
                    o.UseSqlServer(connectionString));
        }
    }
}