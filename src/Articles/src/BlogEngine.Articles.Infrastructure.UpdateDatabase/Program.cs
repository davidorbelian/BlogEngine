using System.Threading.Tasks;
using BlogEngine.Articles.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlogEngine.Articles.Infrastructure.UpdateDatabase
{
    internal class Program
    {
        private const string DefaultConnection =
            "Server=(localdb)\\MSSQLLocalDB; Database=Articles; Integrated Security=true";

        private static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            var connection = configuration.GetConnectionString("Default") != null
                ? configuration.GetConnectionString("Default")
                : DefaultConnection;

            await using var context = new ArticlesContext(GetOptions(connection));
            await context.Database.MigrateAsync();
        }

        private static DbContextOptions<ArticlesContext> GetOptions(string connection)
        {
            return new DbContextOptionsBuilder<ArticlesContext>().UseSqlServer(connection).Options;
        }
    }
}