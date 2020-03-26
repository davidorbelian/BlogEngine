using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Exceptions;
using BlogEngine.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

// ReSharper disable UnusedMember.Global
namespace BlogEngine.Application.Comments
{
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
                throw new ArticleNotFoundException(request.ArticleId);

            return await _context.Comments.Where(c => c.ArticleId == request.ArticleId).ToListAsync(cancellationToken);
        }
    }
}