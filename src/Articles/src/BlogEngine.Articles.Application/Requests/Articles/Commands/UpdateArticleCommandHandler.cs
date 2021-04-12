using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Core.Extensions;
using BlogEngine.Articles.Application.Abstractions;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Articles.Application.Requests.Articles.Commands
{
    [UsedImplicitly]
    public sealed class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand>
    {
        private readonly IArticlesContext _context;

        public UpdateArticleCommandHandler(
            IArticlesContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(
            UpdateArticleCommand request,
            CancellationToken cancellationToken)
        {
            var article = await _context.Articles
                .Include(a => a.HashTags)
                .SingleOrNotFoundExceptionAsync(request.Id, cancellationToken);

            article.Update(request.Title, request.Content);

            return Unit.Value;
        }
    }
}