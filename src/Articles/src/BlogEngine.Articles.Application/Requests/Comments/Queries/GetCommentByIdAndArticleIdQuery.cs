using System;
using BlogEngine.Application.Core.Requests;
using BlogEngine.Articles.Domain.Entities;

namespace BlogEngine.Articles.Application.Requests.Comments.Queries
{
    public sealed record GetCommentByIdAndArticleIdQuery(Guid Id, Guid ArticleId) : Query<Comment>;
}