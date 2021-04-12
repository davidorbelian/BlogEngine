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
    public sealed class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand>
    {
        private readonly IArticlesContext _context;

        public DeleteArticleCommandHandler(IArticlesContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(
            DeleteArticleCommand request,
            CancellationToken cancellationToken)
        {
            var article = await _context.Articles
                .Include(a => a.Comments)
                .SingleOrNotFoundExceptionAsync(request.Id, cancellationToken);

            _context.Articles.Remove(article);

            return Unit.Value;
        }
    }
}