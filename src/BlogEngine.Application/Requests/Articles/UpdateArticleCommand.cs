using MediatR;

namespace BlogEngine.Application.Requests.Articles
{
    public sealed record UpdateArticleCommand(string Id, string Title, string Content) : IRequest;
}