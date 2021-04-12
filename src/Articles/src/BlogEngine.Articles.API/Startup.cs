using BlogEngine.API.Core;
using BlogEngine.API.Core.Auth;
using BlogEngine.API.Core.Auth.Basic;
using BlogEngine.Articles.Application.Extensions;
using BlogEngine.Articles.Infrastructure.SqlServer.Extensions;
using BlogEngine.Messaging.RabbitMq.Configuration;
using BlogEngine.Messaging.RabbitMq.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Articles.API
{
    public sealed class Startup : ApiStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(configuration, webHostEnvironment) { }

        protected override string SwaggerName => "BlogEngine Articles API";
        protected override string SwaggerVersion => "v1";

        protected override IAuthDefinition AuthDefinition => new BasicAuthDefinition();

        protected override void Configure(IServiceCollection services)
        {
            services
                .AddApplication()
                .AddSqlServerInfrastructure(GetConnectionString("SqlServer"))
                .AddRabbitMqMessaging(Bind<RabbitMqConfiguration>("RabbitMq"));
        }
    }
}