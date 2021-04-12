using BlogEngine.Application.Core.Requests;

namespace BlogEngine.Subscriptions.Application.Requests.Subscriptions.Queries
{
    public sealed record GetSubscriptionCountByHashTagQuery(string HashTag) : Query<int>;
}