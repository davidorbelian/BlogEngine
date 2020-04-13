using BlogEngine.Domain.Entities;

namespace BlogEngine.Domain.Relations
{
    public sealed class ArticleHashTag
    {
        public string ArticleId { get; set; }
        public Article Article { get; set; }

        public string HashTagId { get; set; }
        public HashTag HashTag { get; set; }
    }
}