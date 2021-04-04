using System.Collections.Generic;
using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngine.Application.Requests.Articles
{
    public sealed record GetArticlesByHashTagQuery(string HashTag) : IRequest<IEnumerable<Article>>;
}