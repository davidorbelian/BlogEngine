using MediatR;

namespace BlogEngine.Application.Articles
{
    public sealed record CreateArticleCommand(string Title, string Content) : IRequest<string>;
}