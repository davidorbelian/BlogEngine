using MediatR;

namespace BlogEngine.Application.Requests.Comments
{
    public sealed record DeleteCommentCommand(string Id, string ArticleId) : IRequest;
}