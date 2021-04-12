using System.Collections.Generic;
using BlogEngine.Application.Core.Requests;
using BlogEngine.Subscriptions.Domain.Entities;

namespace BlogEngine.Subscriptions.Application.Requests.Subscriptions.Queries
{
    public sealed record GetSubscriptionsByHashTagQuery(string HashTag) : Query<IEnumerable<Subscription>>;
}