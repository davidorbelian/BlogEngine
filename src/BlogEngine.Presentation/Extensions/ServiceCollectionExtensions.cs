using BlogEngine.Presentation.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BlogEngine.Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string BasicAuthScheme = "BasicAuthentication";

        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services
                .AddAuthentication(BasicAuthScheme)
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(BasicAuthScheme, null);

            services
                .AddControllers();

            return services;
        }

        public static IServiceCollection ConfigureScoped<TConfiguration>(this IServiceCollection services,
            IConfigurationSection section)
            where TConfiguration : class, new()
        {
            return services
                .Configure<TConfiguration>(section)
                .AddScoped(sp => sp.GetRequiredService<IOptionsSnapshot<TConfiguration>>().Value);
        }
    }
}