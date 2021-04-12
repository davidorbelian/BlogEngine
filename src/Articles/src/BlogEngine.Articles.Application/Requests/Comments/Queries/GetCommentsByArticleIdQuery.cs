using System;
using System.Collections.Generic;
using BlogEngine.Application.Core.Requests;
using BlogEngine.Articles.Domain.Entities;

namespace BlogEngine.Articles.Application.Requests.Comments.Queries
{
    public sealed record GetCommentsByArticleIdQuery(Guid ArticleId) : Query<IEnumerable<Comment>>;
}