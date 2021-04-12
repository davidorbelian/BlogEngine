using System;
using BlogEngine.Domain.Core;
using JetBrains.Annotations;

namespace BlogEngine.Articles.Domain.Entities
{
    public sealed class Comment : Entity
    {
        [UsedImplicitly]
        private Comment() { }

        internal Comment(string author, string content)
        {
            Author = author;
            Content = content;
        }

        public string Author { get; [UsedImplicitly] private init; }
        public string Content { get; [UsedImplicitly] private init; }

        public Article Article { get; [UsedImplicitly] private init; }
        public Guid ArticleId { get; [UsedImplicitly] private init; }
    }
}