using BlogEngine.Application.Core.Requests;

namespace BlogEngine.Subscriptions.Application.Requests.Subscriptions.Commands
{
    public sealed record DeleteSubscriptionCommand(string Email) : Command;
}