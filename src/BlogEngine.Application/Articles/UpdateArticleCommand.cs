using MediatR;

namespace BlogEngine.Application.Articles
{
    public sealed record UpdateArticleCommand(string Id, string Title, string Content) : IRequest<string>;
}