using Microsoft.AspNetCore.Builder;

namespace BlogEngine.Presentation.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDevelopmentPipeline(this IApplicationBuilder app)
        {
            return app
                .UseDeveloperExceptionPage();
        }

        public static IApplicationBuilder UseProductionPipeline(this IApplicationBuilder app)
        {
            return app
                .UseHttpsRedirection();
        }

        public static IApplicationBuilder UsePresentationPipeline(this IApplicationBuilder app)
        {
            return app
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}