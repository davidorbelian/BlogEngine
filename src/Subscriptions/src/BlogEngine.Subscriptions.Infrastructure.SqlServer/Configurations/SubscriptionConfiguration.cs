using BlogEngine.Infrastructure.Core.Configurations;
using BlogEngine.Subscriptions.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEngine.Subscriptions.Infrastructure.SqlServer.Configurations
{
    public sealed class SubscriptionConfiguration : SqlServerEntityConfiguration<Subscription>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasIndex(s => s.Email).IsUnique();
            builder.OwnsMany(s => s.HashTags);
        }
    }
}