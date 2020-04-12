using System;

namespace BlogEngine.Application.Exceptions
{
    public sealed class CommentNotFoundException : Exception
    {
        public CommentNotFoundException(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}