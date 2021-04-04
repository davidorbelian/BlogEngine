using System.Collections.Generic;
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
    public sealed class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, IEnumerable<Article>>
    {
        private readonly IBlogEngineContext _context;

        public GetArticlesQueryHandler(IBlogEngineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> Handle(
            GetArticlesQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Articles
                .Include(a => a.HashTags)
                .OrderByCreateTimeDesc()
                .ToListAsync(cancellationToken);
        }
    }
}