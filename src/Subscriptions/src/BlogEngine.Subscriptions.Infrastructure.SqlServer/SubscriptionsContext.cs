using BlogEngine.Subscriptions.Application.Abstractions;
using BlogEngine.Subscriptions.Domain.Entities;
using BlogEngine.Subscriptions.Infrastructure.SqlServer.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Subscriptions.Infrastructure.SqlServer
{
    public sealed class SubscriptionsContext : DbContext, ISubscriptionsContext
    {
        public SubscriptionsContext(DbContextOptions<SubscriptionsContext> options) : base(options) { }

        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
        }
    }
}