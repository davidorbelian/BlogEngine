using System;
using BlogEngine.Events.Core.Abstractions;

namespace BlogEngine.Articles.Events
{
    public sealed record CommentAddedEvent(Guid ArticleId) : IDomainEvent;
}