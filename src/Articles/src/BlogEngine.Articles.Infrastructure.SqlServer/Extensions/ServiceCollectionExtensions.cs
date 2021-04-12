using BlogEngine.Articles.Application.Abstractions;
using BlogEngine.Infrastructure.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Articles.Infrastructure.SqlServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlServerInfrastructure(
            this IServiceCollection services,
            string connectionString)
        {
            return services.AddInfrastructureCore<IArticlesContext, ArticlesContext>(o =>
                o.UseSqlServer(connectionString));
        }
    }
}