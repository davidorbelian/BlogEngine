using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlogEngine.API.Core.Extensions
{
    public static class HostExtensions
    {
        public static IHost UpdateDatabase<TContext>(this IHost host, Action<DatabaseFacade> migrate)
            where TContext : DbContext
        {
            using var scope = host.Services.CreateScope();

            migrate(scope.ServiceProvider.GetRequiredService<TContext>().Database);

            return host;
        }
    }
}