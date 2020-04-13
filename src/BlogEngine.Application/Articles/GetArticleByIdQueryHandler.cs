using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Abstractions;
using BlogEngine.Application.Exceptions;
using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngine.Application.Articles
{
    // ReSharper disable once UnusedMember.Global
    public sealed class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Article>
    {
        private readonly IBlogEngineContext _context;

        public GetArticleByIdQueryHandler(IBlogEngineContext context)
        {
            _context = context;
        }

        public async Task<Article> Handle(
            GetArticleByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Articles.FindAsync(request.Id) ??
                   throw new ArticleNotFoundException(request.Id);
        }
    }
}