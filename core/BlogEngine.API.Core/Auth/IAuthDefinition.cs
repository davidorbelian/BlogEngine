using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BlogEngine.API.Core.Auth
{
    public interface IAuthDefinition
    {
        public string Name { get; }
        public OpenApiSecurityScheme OpenApiSecurityScheme { get; }
        public OpenApiSecurityRequirement OpenApiSecurityRequirement { get; }

        public void Configure(IServiceCollection services, IConfigurationSection configuration);
    }
}