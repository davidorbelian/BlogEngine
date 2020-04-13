using BlogEngine.Application.Abstractions;
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
        public DbSet<HashTag> HashTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleHashTagConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new HashTagConfiguration());
        }
    }
}