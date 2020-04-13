using BlogEngine.Domain.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEngine.Infrastructure.Configurations
{
    public sealed class ArticleHashTagConfiguration : IEntityTypeConfiguration<ArticleHashTag>
    {
        public void Configure(EntityTypeBuilder<ArticleHashTag> builder)
        {
            builder.HasKey(aht => new {aht.ArticleId, aht.HashTagId});
        }
    }
}