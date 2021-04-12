using BlogEngine.Application.Core.Abstractions;
using BlogEngine.Subscriptions.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Subscriptions.Application.Abstractions
{
    public interface ISubscriptionsContext : IDbContext
    {
        DbSet<Subscription> Subscriptions { get; }
    }
}