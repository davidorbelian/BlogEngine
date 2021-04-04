using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Abstractions;
using BlogEngine.Application.Extensions;
using BlogEngine.Domain.Entities;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Application.Requests.Articles
{
    [UsedImplicitly]
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
            return await _context.Articles
                .Include(a => a.Comments)
                .Include(a => a.HashTags)
                .SingleOrNotFoundExceptionAsync(request.Id, cancellationToken);
        }
    }
}