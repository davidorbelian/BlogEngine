using BlogEngine.Application.Core.Requests;
using BlogEngine.Subscriptions.Domain.Entities;

namespace BlogEngine.Subscriptions.Application.Requests.Subscriptions.Queries
{
    public sealed record GetSubscriptionByEmailQuery(string Email) : Query<Subscription>;
}