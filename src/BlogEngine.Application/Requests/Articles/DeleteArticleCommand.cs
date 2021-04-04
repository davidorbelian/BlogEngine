using MediatR;

namespace BlogEngine.Application.Requests.Articles
{
    public sealed record DeleteArticleCommand(string Id) : IRequest;
}