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
        private const string DatabaseSection = "Database";

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public DatabaseConfiguration DatabaseConfiguration =>
            Configuration.GetSection(DatabaseSection).Get<DatabaseConfiguration>();

        public bool IsDevelopment => WebHostEnvironment.IsDevelopment();

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = DatabaseConfiguration.ConnectionString;

            services.AddApplication();
            services.AddSqLiteInfrastructure(connectionString);
            services.AddPresentation();
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