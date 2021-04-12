using System.Collections.Generic;
using BlogEngine.Events.Core.Abstractions;

namespace BlogEngine.Articles.Events
{
    public sealed record ArticleCreatedEvent(
        string Title,
        IEnumerable<string> HashTags) : IDomainEvent;
}