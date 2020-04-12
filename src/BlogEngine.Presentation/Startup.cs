using BlogEngine.Application.Extensions;
using BlogEngine.Infrastructure.SQLite.Extensions;
using BlogEngine.Presentation.Configurations;
using BlogEngine.Presentation.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlogEngine.Presentation
{
    public sealed class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public IConfigurationSection AuthSection => Configuration.GetSection("Auth");
        public IConfigurationSection DatabaseSection => Configuration.GetSection("Database");

        public bool IsDevelopment => WebHostEnvironment.IsDevelopment();

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = DatabaseSection.Get<DatabaseConfiguration>().ConnectionString;

            services.AddApplication();
            services.AddSqLiteInfrastructure(connectionString);
            services.AddPresentation();

            services.ConfigureScoped<AuthConfiguration>(AuthSection);
        }

        public void Configure(IApplicationBuilder app)
        {
            if (IsDevelopment)
                app.UseDevelopmentPipeline();
            else
                app.UseProductionPipeline();

            app.UsePresentationPipeline();
        }
    }
}