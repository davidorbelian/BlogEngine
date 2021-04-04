using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Abstractions;
using BlogEngine.Domain.Entities;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Application.Requests.Articles
{
    [UsedImplicitly]
    public sealed class GetArticlesByHashTagQueryHandler
        : IRequestHandler<GetArticlesByHashTagIdQuery, IEnumerable<Article>>
    {
        private readonly IBlogEngineContext _context;

        public GetArticlesByHashTagQueryHandler(IBlogEngineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> Handle(
            GetArticlesByHashTagIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Articles
                .Where(a => a.HashTags.Any(ht => ht.HashTagId.ToLower() == request.HashTagId.ToLower()))
                .Include(a => a.HashTags)
                .ToListAsync(cancellationToken);
        }
    }
}