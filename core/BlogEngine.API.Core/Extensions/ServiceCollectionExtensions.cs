using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BlogEngine.API.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureScoped<TConfiguration>(
            this IServiceCollection services,
            IConfigurationSection section)
            where TConfiguration : class
        {
            return services
                .Configure<TConfiguration>(section)
                .AddScoped(sp => sp.GetRequiredService<IOptionsSnapshot<TConfiguration>>().Value);
        }
    }
}