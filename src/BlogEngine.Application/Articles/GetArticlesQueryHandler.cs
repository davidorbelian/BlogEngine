using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Application.Articles
{
    // ReSharper disable once UnusedMember.Global
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
            return await _context.Articles.ToListAsync(cancellationToken);
        }
    }
}