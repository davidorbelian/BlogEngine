using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngine.Application.Articles
{
    public sealed record GetArticleByIdQuery(string Id) : IRequest<Article>;
}