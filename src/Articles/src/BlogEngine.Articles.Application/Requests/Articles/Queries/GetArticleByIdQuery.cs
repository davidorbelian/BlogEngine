using System;
using BlogEngine.Application.Core.Requests;
using BlogEngine.Articles.Domain.Entities;

namespace BlogEngine.Articles.Application.Requests.Articles.Queries
{
    public sealed record GetArticleByIdQuery(Guid Id) : Query<Article>;
}