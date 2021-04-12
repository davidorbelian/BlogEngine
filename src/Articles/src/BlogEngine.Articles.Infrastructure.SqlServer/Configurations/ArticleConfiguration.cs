using BlogEngine.Articles.Domain.Entities;
using BlogEngine.Infrastructure.Core.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEngine.Articles.Infrastructure.SqlServer.Configurations
{
    public sealed class ArticleConfiguration : SqlServerEntityConfiguration<Article>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Article> builder)
        {
            builder.OwnsMany(a => a.HashTags);
            builder.HasMany(a => a.Comments).WithOne(c => c.Article).HasForeignKey(c => c.ArticleId);
        }
    }
}