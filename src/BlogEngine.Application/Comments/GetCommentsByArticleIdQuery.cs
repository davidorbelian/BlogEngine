using System.Collections.Generic;
using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngine.Application.Comments
{
    public sealed class GetCommentsByArticleIdQuery : IRequest<IEnumerable<Comment>>
    {
        public GetCommentsByArticleIdQuery(string articleId)
        {
            ArticleId = articleId;
        }

        public string ArticleId { get; }
    }
}