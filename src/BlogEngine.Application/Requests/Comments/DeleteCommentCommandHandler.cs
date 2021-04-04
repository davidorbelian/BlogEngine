using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Abstractions;
using BlogEngine.Application.Exceptions;
using BlogEngine.Application.Extensions;
using BlogEngine.Domain.Entities;
using JetBrains.Annotations;
using MediatR;

namespace BlogEngine.Application.Requests.Comments
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
            var comment = await _context.Comments.SingleOrNotFoundExceptionAsync(request.Id, cancellationToken);

            if (comment.ArticleId != request.ArticleId)
                throw new EntityNotFoundException<Comment>(request.Id);

            _context.Comments.Remove(comment);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}