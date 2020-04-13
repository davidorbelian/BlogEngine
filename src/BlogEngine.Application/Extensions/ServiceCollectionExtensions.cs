using BlogEngine.Application.Abstractions;
using BlogEngine.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IBlogEngineContext));

            services.AddSingleton<IHashTagParser, RegexHashTagParser>();

            return services;
        }
    }
}