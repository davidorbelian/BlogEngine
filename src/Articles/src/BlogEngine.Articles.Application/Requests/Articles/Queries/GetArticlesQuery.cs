using System.Collections.Generic;
using BlogEngine.Application.Core.Requests;
using BlogEngine.Articles.Domain.Entities;

namespace BlogEngine.Articles.Application.Requests.Articles.Queries
{
    public sealed record GetArticlesQuery : Query<IEnumerable<Article>>;
}