using BlogEngine.Application;
using BlogEngine.Domain.Entities;
using BlogEngine.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Infrastructure
{
    public sealed class BlogEngineContext : DbContext, IBlogEngineContext
    {
        public BlogEngineContext(DbContextOptions<BlogEngineContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}