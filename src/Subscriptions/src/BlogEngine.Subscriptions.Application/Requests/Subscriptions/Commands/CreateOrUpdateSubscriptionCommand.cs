using System.Collections.Generic;
using BlogEngine.Application.Core.Requests;

namespace BlogEngine.Subscriptions.Application.Requests.Subscriptions.Commands
{
    public sealed record CreateOrUpdateSubscriptionCommand(string Email, IEnumerable<string> HashTags) : Command;
}