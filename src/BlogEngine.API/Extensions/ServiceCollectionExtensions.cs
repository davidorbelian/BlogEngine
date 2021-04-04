using System;
using BlogEngine.API.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace BlogEngine.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string BasicAuthScheme = "BasicAuthentication";

        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services
                .AddAuthentication(BasicAuthScheme)
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(BasicAuthScheme, null);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "BlogEngine API", Version = "v1"});

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                });
            });

            return services;
        }

        public static IServiceCollection ConfigureScoped<TConfiguration>(
            this IServiceCollection services,
            IConfigurationSection section)
            where TConfiguration : class, new()
        {
            return services
                .Configure<TConfiguration>(section)
                .AddScoped(sp => sp.GetRequiredService<IOptionsSnapshot<TConfiguration>>().Value);
        }
    }
}