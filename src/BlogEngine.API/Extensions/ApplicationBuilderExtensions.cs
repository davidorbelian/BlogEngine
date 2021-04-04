using Microsoft.AspNetCore.Builder;

namespace BlogEngine.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDevelopmentPipeline(this IApplicationBuilder app)
        {
            return app
                .UseDeveloperExceptionPage()
                .UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogEngine API"));
        }

        public static IApplicationBuilder UseProductionPipeline(this IApplicationBuilder app)
        {
            return app
                .UseHttpsRedirection();
        }

        public static IApplicationBuilder UseApiPipeline(this IApplicationBuilder app)
        {
            return app
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}