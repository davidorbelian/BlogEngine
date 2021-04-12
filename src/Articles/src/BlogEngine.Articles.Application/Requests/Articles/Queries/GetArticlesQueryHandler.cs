using System.Collections.Generic;
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
    public sealed class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, IEnumerable<Article>>
    {
        private readonly IArticlesContext _context;

        public GetArticlesQueryHandler(IArticlesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> Handle(
            GetArticlesQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Articles
                .AsNoTracking()
                .Include(a => a.HashTags)
                .OrderByCreateTimeDesc()
                .ToListAsync(cancellationToken);
        }
    }
}