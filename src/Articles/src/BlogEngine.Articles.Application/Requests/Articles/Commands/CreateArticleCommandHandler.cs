using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Articles.Application.Abstractions;
using BlogEngine.Articles.Domain.Entities;
using JetBrains.Annotations;
using MediatR;

namespace BlogEngine.Articles.Application.Requests.Articles.Commands
{
    [UsedImplicitly]
    public sealed class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Article>
    {
        private readonly IArticlesContext _context;

        public CreateArticleCommandHandler(
            IArticlesContext context)
        {
            _context = context;
        }

        public Task<Article> Handle(
            CreateArticleCommand request,
            CancellationToken cancellationToken)
        {
            var article = new Article(request.Title, request.Content);

            _context.Articles.Add(article);

            return Task.FromResult(article);
        }
    }
}