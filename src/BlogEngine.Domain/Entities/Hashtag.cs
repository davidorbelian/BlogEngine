using System.Collections.Generic;
using BlogEngine.Domain.Core;
using BlogEngine.Domain.Relations;

namespace BlogEngine.Domain.Entities
{
    public sealed class HashTag : Entity
    {
        public ICollection<ArticleHashTag> Articles { get; } = new HashSet<ArticleHashTag>();
    }
}