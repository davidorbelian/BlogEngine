using System;
using BlogEngine.Application.Core.Abstractions;
using BlogEngine.Infrastructure.Core.Dispatchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Infrastructure.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureCore<TContextAbstraction, TContextImplementation>(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> connectionOptions,
            params Action<DbContextOptionsBuilder>[] additionalOptions)
            where TContextAbstraction : class, IDbContext
            where TContextImplementation : DbContext, TContextAbstraction
        {
            services.AddScoped<DomainEventsDispatcher>();
            services.AddScoped<TContextAbstraction, TContextImplementation>();
            services.AddDbContext<TContextImplementation>((sp, o) =>
            {
                o.AddInterceptors(sp.GetRequiredService<DomainEventsDispatcher>());

                connectionOptions(o);

                foreach (var additionalOption in additionalOptions) additionalOption(o);
            });

            return services;
        }
    }
}