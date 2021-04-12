using BlogEngine.API.Core.Auth;
using BlogEngine.API.Core.Extensions;
using BlogEngine.API.Core.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace BlogEngine.API.Core
{
    public abstract class ApiStartup
    {
        protected ApiStartup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        protected IConfiguration Configuration { get; }
        protected IWebHostEnvironment WebHostEnvironment { get; }

        protected abstract string SwaggerName { get; }
        protected abstract string SwaggerVersion { get; }

        protected abstract IAuthDefinition AuthDefinition { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleware>();

            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerVersion, new OpenApiInfo {Title = SwaggerName, Version = SwaggerVersion});

                if (AuthDefinition == null)
                    return;

                c.AddSecurityDefinition(AuthDefinition.Name, AuthDefinition.OpenApiSecurityScheme);
                c.AddSecurityRequirement(AuthDefinition.OpenApiSecurityRequirement);
            });

            AuthDefinition?.Configure(services, Configuration.GetSection("Auth"));

            Configure(services);
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            if (WebHostEnvironment.IsDevelopment())
                applicationBuilder
                    .UseDeveloperExceptionPage()
                    .UseSwagger()
                    .UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{SwaggerVersion}/swagger.json", SwaggerName));

            applicationBuilder
                .UseMiddleware<ExceptionMiddleware>()
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }

        protected abstract void Configure(IServiceCollection services);

        public string GetConnectionString(string name)
        {
            return Configuration.GetConnectionString(name);
        }

        public T Bind<T>(string sectionPath)
            where T : class, new()
        {
            return Configuration.GetSection(sectionPath).Bind<T>();
        }
    }
}