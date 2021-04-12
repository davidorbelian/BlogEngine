using System;
using BlogEngine.Application.Core.Requests;

namespace BlogEngine.Articles.Application.Requests.Articles.Commands
{
    public sealed record DeleteArticleCommand(Guid Id) : Command;
}