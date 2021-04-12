using System.Collections.Generic;
using System.Linq;
using BlogEngine.Articles.Events;
using BlogEngine.Domain.Common.ValueObjects;
using BlogEngine.Domain.Core;
using JetBrains.Annotations;

namespace BlogEngine.Articles.Domain.Entities
{
    public sealed class Article : Entity
    {
        private readonly ICollection<Comment> _comments = new HashSet<Comment>();
        private readonly ICollection<HashTag> _hashTags = new HashSet<HashTag>();

        [UsedImplicitly]
        private Article() { }

        public Article(string title, string content)
        {
            Title = title;
            Content = content;

            foreach (var hashTag in HashTag.Parse(content)) _hashTags.Add(hashTag);

            AddDomainEvent(new ArticleCreatedEvent(Title, HashTags.Select(ht => ht.Id)));
        }

        public string Title { get; private set; }
        public string Content { get; private set; }

        public IReadOnlyCollection<Comment> Comments => _comments.ToList();
        public IReadOnlyCollection<HashTag> HashTags => _hashTags.ToList();

        public void Update(string title, string content)
        {
            Title = title;
            Content = content;

            _hashTags.Clear();

            foreach (var hashTag in HashTag.Parse(content)) _hashTags.Add(hashTag);
        }

        public void AddComment(string author, string content)
        {
            _comments.Add(new Comment(author, content));

            AddDomainEvent(new CommentAddedEvent(Id));
        }

        public void DeleteComment(Comment comment)
        {
            _comments.Remove(comment);
        }
    }
}