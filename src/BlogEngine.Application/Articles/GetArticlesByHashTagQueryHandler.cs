using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Abstractions;
using BlogEngine.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Application.Articles
{
    // ReSharper disable once UnusedMember.Global
    public sealed class GetArticlesByHashTagQueryHandler
        : IRequestHandler<GetArticlesByHashTagQuery, IEnumerable<Article>>
    {
        private readonly IBlogEngineContext _context;

        public GetArticlesByHashTagQueryHandler(IBlogEngineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> Handle(
            GetArticlesByHashTagQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Articles
                .Where(a => a.HashTags.Any(ht => ht.HashTagId.ToLower() == request.HashTag.ToLower()))
                .ToListAsync(cancellationToken);
        }
    }
}