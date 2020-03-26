using System;

namespace BlogEngine.Application.Exceptions
{
    public sealed class ArticleNotFoundException : Exception
    {
        public ArticleNotFoundException(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}