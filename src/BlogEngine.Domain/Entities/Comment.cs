using BlogEngine.Domain.Core;

namespace BlogEngine.Domain.Entities
{
    public sealed class Comment : Entity
    {
        public string Author { get; set; }
        public string Content { get; set; }

        public Article Article { get; set; }
        public string ArticleId { get; set; }
    }
}