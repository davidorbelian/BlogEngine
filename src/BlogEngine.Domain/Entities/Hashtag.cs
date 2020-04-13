using System.Collections.Generic;
using BlogEngine.Domain.Core;
using BlogEngine.Domain.Relations;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
namespace BlogEngine.Domain.Entities
{
    public sealed class HashTag : Entity
    {
        public ICollection<ArticleHashTag> Articles { get; private set; } = new HashSet<ArticleHashTag>();
    }
}