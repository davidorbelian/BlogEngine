using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IBlogEngineContext));

            return services;
        }
    }
}