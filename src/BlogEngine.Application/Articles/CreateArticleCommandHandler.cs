using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngine.Application.Articles
{
    // ReSharper disable once UnusedMember.Global
    public sealed class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, string>
    {
        private readonly IBlogEngineContext _context;

        public CreateArticleCommandHandler(IBlogEngineContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(
            CreateArticleCommand request,
            CancellationToken cancellationToken)
        {
            var article = new Article
            {
                Title = request.Title,
                Content = request.Content
            };

            _context.Articles.Add(article);

            await _context.SaveChangesAsync(cancellationToken);

            return article.Id;
        }
    }
}