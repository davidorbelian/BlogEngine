using System;
using BlogEngine.Articles.Application.Abstractions;
using BlogEngine.Infrastructure.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Articles.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> connectionOptions,
            params Action<DbContextOptionsBuilder>[] additionalOptions)
        {
            return services.AddInfrastructureCore<IArticlesContext, ArticlesContext>(connectionOptions,
                additionalOptions);
        }
    }
}