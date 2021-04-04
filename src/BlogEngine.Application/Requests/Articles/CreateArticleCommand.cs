using MediatR;

namespace BlogEngine.Application.Requests.Articles
{
    public sealed record CreateArticleCommand(string Title, string Content) : IRequest<string>;
}