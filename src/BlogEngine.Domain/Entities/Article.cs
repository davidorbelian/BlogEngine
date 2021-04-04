using System.Collections.Generic;
using BlogEngine.Domain.Core;
using BlogEngine.Domain.Relations;

namespace BlogEngine.Domain.Entities
{
    public sealed class Article : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public ICollection<Comment> Comments { get; } = new HashSet<Comment>();
        public ICollection<ArticleHashTag> HashTags { get; } = new HashSet<ArticleHashTag>();
    }
}