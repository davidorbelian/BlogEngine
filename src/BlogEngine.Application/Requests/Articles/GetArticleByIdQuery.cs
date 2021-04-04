using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngine.Application.Requests.Articles
{
    public sealed record GetArticleByIdQuery(string Id) : IRequest<Article>;
}