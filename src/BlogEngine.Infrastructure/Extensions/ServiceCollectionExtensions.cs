using BlogEngine.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IBlogEngineContext, BlogEngineContext>();

            return services;
        }
    }
}