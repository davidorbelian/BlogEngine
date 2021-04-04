using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngine.Application.Requests.Comments
{
    public sealed record GetCommentByIdAndArticleIdQuery(string Id, string ArticleId) : IRequest<Comment>;
}