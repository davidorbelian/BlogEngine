using BlogEngine.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Infrastructure.SQLite.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqLiteInfrastructure(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddInfrastructure();

            services.AddDbContext<BlogEngineContext>(options => { options.UseSqlite(connectionString); });

            return services;
        }
    }
}