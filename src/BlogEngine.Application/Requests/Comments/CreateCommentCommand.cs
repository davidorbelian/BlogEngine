using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngine.Application.Requests.Comments
{
    public sealed record CreateCommentCommand(string Author, string Content, string ArticleId) : IRequest<Comment>;
}