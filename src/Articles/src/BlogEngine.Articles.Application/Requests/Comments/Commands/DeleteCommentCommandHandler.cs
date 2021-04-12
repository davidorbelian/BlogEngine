using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Core.Extensions;
using BlogEngine.Articles.Application.Abstractions;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Articles.Application.Requests.Comments.Commands
{
    [UsedImplicitly]
    public sealed class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IArticlesContext _context;

        public DeleteCommentCommandHandler(IArticlesContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(
            DeleteCommentCommand request,
            CancellationToken cancellationToken)
        {
            var article = await _context.Articles
                .Include(a => a.Comments)
                .SingleOrNotFoundExceptionAsync(request.ArticleId, cancellationToken);

            var comment = article.Comments.SingleOrNotFoundException(request.Id);

            article.DeleteComment(comment);

            return Unit.Value;
        }
    }
}