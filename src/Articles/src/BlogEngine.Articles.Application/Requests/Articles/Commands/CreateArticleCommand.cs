using BlogEngine.Application.Core.Requests;
using BlogEngine.Articles.Domain.Entities;

namespace BlogEngine.Articles.Application.Requests.Articles.Commands
{
    public sealed record CreateArticleCommand(string Title, string Content) : Command<Article>;
}