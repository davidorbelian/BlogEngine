using MediatR;

namespace BlogEngine.Application.Comments
{
    public sealed record DeleteCommentCommand(string Id, string ArticleId) : IRequest;
}