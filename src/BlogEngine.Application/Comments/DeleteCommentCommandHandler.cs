using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Abstractions;
using BlogEngine.Application.Exceptions;
using JetBrains.Annotations;
using MediatR;

namespace BlogEngine.Application.Comments
{
    [UsedImplicitly]
    public sealed class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IBlogEngineContext _context;

        public DeleteCommentCommandHandler(IBlogEngineContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(
            DeleteCommentCommand request,
            CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FindAsync(request.Id) ??
                          throw new CommentNotFoundException(request.Id);

            if (comment.ArticleId != request.ArticleId)
                throw new CommentNotFoundException(request.Id);

            _context.Comments.Remove(comment);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}