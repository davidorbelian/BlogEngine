using BlogEngine.API.Core;
using BlogEngine.API.Core.Auth;
using BlogEngine.API.Core.Auth.Basic;
using BlogEngine.API.Core.Extensions;
using BlogEngine.Messaging.RabbitMq.Configuration;
using BlogEngine.Messaging.RabbitMq.Extensions;
using BlogEngine.Subscriptions.API.Configuration;
using BlogEngine.Subscriptions.API.Consumers;
using BlogEngine.Subscriptions.Application.Extensions;
using BlogEngine.Subscriptions.Infrastructure.Smtp.Configuration;
using BlogEngine.Subscriptions.Infrastructure.Smtp.Extensions;
using BlogEngine.Subscriptions.Infrastructure.SqlServer.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Subscriptions.API
{
    public sealed class Startup : ApiStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(configuration, webHostEnvironment) { }

        protected override string SwaggerName => "Blog Engine Subscriptions API";
        protected override string SwaggerVersion => "v1";

        protected override IAuthDefinition AuthDefinition => new BasicAuthDefinition();

        protected override void Configure(IServiceCollection services)
        {
            services
                .AddApplication()
                .AddSmtpInfrastructure(Bind<SmtpConfiguration>("Smtp"))
                .AddSqlServerInfrastructure(GetConnectionString("SqlServer"))
                .AddRabbitMqMessaging(Bind<RabbitMqConfiguration>("RabbitMq"),
                    x => x.AddConsumer<ArticleCreatedConsumer>())
                .ConfigureScoped<EmailsConfiguration>(Configuration.GetSection("Emails"));
        }
    }
}