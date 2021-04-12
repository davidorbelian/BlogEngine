using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Articles.Application.Abstractions;
using BlogEngine.Articles.Domain.Entities;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Articles.Application.Requests.Articles.Queries
{
    [UsedImplicitly]
    public sealed class GetArticlesByHashTagQueryHandler
        : IRequestHandler<GetArticlesByHashTagIdQuery, IEnumerable<Article>>
    {
        private readonly IArticlesContext _context;

        public GetArticlesByHashTagQueryHandler(IArticlesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> Handle(
            GetArticlesByHashTagIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Articles
                .AsNoTracking()
                .Where(a => a.HashTags.Any(ht => ht.Id.ToLower() == request.HashTagId.ToLower()))
                .Include(a => a.HashTags)
                .ToListAsync(cancellationToken);
        }
    }
}