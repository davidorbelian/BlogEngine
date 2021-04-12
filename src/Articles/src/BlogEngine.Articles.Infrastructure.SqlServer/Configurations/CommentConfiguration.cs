using BlogEngine.Articles.Domain.Entities;
using BlogEngine.Infrastructure.Core.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEngine.Articles.Infrastructure.SqlServer.Configurations
{
    public sealed class CommentConfiguration : SqlServerEntityConfiguration<Comment>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Comment> builder) { }
    }
}