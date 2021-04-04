using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Abstractions;
using BlogEngine.Application.Exceptions;
using BlogEngine.Application.Extensions;
using BlogEngine.Domain.Entities;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Application.Requests.Comments
{
    [UsedImplicitly]
    public sealed class GetCommentsByArticleIdQueryHandler
        : IRequestHandler<GetCommentsByArticleIdQuery, IEnumerable<Comment>>
    {
        private readonly IBlogEngineContext _context;

        public GetCommentsByArticleIdQueryHandler(IBlogEngineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> Handle(
            GetCommentsByArticleIdQuery request,
            CancellationToken cancellationToken)
        {
            if (!await _context.Articles.AnyAsync(a => a.Id == request.ArticleId, cancellationToken))
                throw new EntityNotFoundException<Article>(request.ArticleId);

            return await _context.Comments
                .Where(c => c.ArticleId == request.ArticleId)
                .OrderByCreateTimeDesc()
                .ToListAsync(cancellationToken);
        }
    }
}