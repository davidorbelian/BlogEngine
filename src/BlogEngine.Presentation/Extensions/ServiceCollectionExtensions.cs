using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }
    }
}