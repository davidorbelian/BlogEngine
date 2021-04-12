using System;
using BlogEngine.API.Core.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BlogEngine.API.Core.Auth.Basic
{
    public sealed class BasicAuthDefinition : IAuthDefinition
    {
        public string Name => "basic";

        public OpenApiSecurityScheme OpenApiSecurityScheme => new()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "basic",
            In = ParameterLocation.Header,
            Description = "Basic Authorization header using the Bearer scheme."
        };

        public OpenApiSecurityRequirement OpenApiSecurityRequirement => new()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "basic"
                    }
                },
                Array.Empty<string>()
            }
        };

        public void Configure(IServiceCollection services, IConfigurationSection authSection)
        {
            services
                .AddSingleton(new BasicAuthConfiguration(authSection["Username"], authSection["Password"]))
                .AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("BasicAuthentication", null);
        }
    }
}