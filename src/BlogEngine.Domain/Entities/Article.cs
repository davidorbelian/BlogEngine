using System.Collections.Generic;
using BlogEngine.Domain.Core;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
namespace BlogEngine.Domain.Entities
{
    public sealed class Article : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public ICollection<Comment> Comments { get; private set; } = new HashSet<Comment>();
    }
}