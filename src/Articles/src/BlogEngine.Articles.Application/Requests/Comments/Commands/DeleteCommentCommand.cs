using System;
using BlogEngine.Application.Core.Requests;

namespace BlogEngine.Articles.Application.Requests.Comments.Commands
{
    public sealed record DeleteCommentCommand(Guid Id, Guid ArticleId) : Command;
}