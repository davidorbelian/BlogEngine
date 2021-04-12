using BlogEngine.Articles.Application.Abstractions;
using BlogEngine.Articles.Domain.Entities;
using BlogEngine.Articles.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Articles.Infrastructure
{
    public sealed class ArticlesContext : DbContext, IArticlesContext
    {
        public ArticlesContext(DbContextOptions<ArticlesContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}