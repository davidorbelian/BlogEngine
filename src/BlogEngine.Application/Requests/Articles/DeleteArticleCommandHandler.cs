using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Abstractions;
using BlogEngine.Application.Exceptions;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Application.Requests.Articles
{
    [UsedImplicitly]
    public sealed class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand>
    {
        private readonly IBlogEngineContext _context;

        public DeleteArticleCommandHandler(IBlogEngineContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(
            DeleteArticleCommand request,
            CancellationToken cancellationToken)
        {
            var article = await _context.Articles.FindAsync(request.Id) ??
                          throw new ArticleNotFoundException(request.Id);

            var comments = await _context.Comments
                .Where(c => c.ArticleId == request.Id)
                .ToListAsync(cancellationToken);

            _context.Comments.RemoveRange(comments);
            _context.Articles.Remove(article);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}