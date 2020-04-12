using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Exceptions;
using MediatR;

namespace BlogEngine.Application.Articles
{
    // ReSharper disable once UnusedMember.Global
    public sealed class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, string>
    {
        private readonly IBlogEngineContext _context;

        public UpdateArticleCommandHandler(IBlogEngineContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(
            UpdateArticleCommand request,
            CancellationToken cancellationToken)
        {
            var article = await _context.Articles.FindAsync(request.Id) ??
                          throw new ArticleNotFoundException(request.Id);

            article.Title = request.Title;
            article.Content = request.Content;

            await _context.SaveChangesAsync(cancellationToken);

            return article.Id;
        }
    }
}