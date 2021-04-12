using System;
using BlogEngine.Application.Core.Requests;
using BlogEngine.Articles.Domain.Entities;

namespace BlogEngine.Articles.Application.Requests.Comments.Commands
{
    public sealed record CreateCommentCommand(string Author, string Content, Guid ArticleId) : Command<Comment>;
}