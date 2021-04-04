using System.Collections.Generic;
using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngine.Application.Requests.Articles
{
    public sealed record GetArticlesByHashTagIdQuery(string HashTagId) : IRequest<IEnumerable<Article>>;
}