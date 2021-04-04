using MediatR;

namespace BlogEngine.Application.Comments
{
    public sealed record CreateCommentCommand(string Author, string Content, string ArticleId) : IRequest<string>;
}