using System.Collections.Generic;
using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngine.Application.Comments
{
    public sealed record GetCommentsByArticleIdQuery(string ArticleId) : IRequest<IEnumerable<Comment>>;
}