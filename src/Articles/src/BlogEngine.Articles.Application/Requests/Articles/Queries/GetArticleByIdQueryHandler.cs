using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Core.Extensions;
using BlogEngine.Articles.Application.Abstractions;
using BlogEngine.Articles.Domain.Entities;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Articles.Application.Requests.Articles.Queries
{
    [UsedImplicitly]
    public sealed class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Article>
    {
        private readonly IArticlesContext _context;

        public GetArticleByIdQueryHandler(IArticlesContext context)
        {
            _context = context;
        }

        public async Task<Article> Handle(
            GetArticleByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Articles
                .AsNoTracking()
                .Include(a => a.Comments)
                .Include(a => a.HashTags)
                .SingleOrNotFoundExceptionAsync(request.Id, cancellationToken);
        }
    }
}