using MediatR;

namespace BlogEngine.Application.Articles
{
    public sealed record DeleteArticleCommand(string Id) : IRequest;
}