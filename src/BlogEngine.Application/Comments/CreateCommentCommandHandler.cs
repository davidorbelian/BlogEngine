using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Exceptions;
using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngine.Application.Comments
{
    // ReSharper disable once UnusedMember.Global
    public sealed class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, string>
    {
        private readonly IBlogEngineContext _context;

        public CreateCommentCommandHandler(IBlogEngineContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(
            CreateCommentCommand request,
            CancellationToken cancellationToken)
        {
            var article = await _context.Articles.FindAsync(request.ArticleId) ??
                          throw new ArticleNotFoundException(request.ArticleId);

            var comment = new Comment
            {
                Author = request.Author,
                Content = request.Content
            };

            article.Comments.Add(comment);

            await _context.SaveChangesAsync(cancellationToken);

            return comment.Id;
        }
    }
}