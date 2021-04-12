using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Core.Extensions;
using BlogEngine.Articles.Application.Abstractions;
using BlogEngine.Articles.Domain.Entities;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Articles.Application.Requests.Comments.Queries
{
    [UsedImplicitly]
    public sealed class GetCommentsByArticleIdQueryHandler
        : IRequestHandler<GetCommentsByArticleIdQuery, IEnumerable<Comment>>
    {
        private readonly IArticlesContext _context;

        public GetCommentsByArticleIdQueryHandler(IArticlesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> Handle(
            GetCommentsByArticleIdQuery request,
            CancellationToken cancellationToken)
        {
            var article = await _context.Articles
                .AsNoTracking()
                .Include(a => a.Comments)
                .SingleOrNotFoundExceptionAsync(request.ArticleId, cancellationToken);

            return article.Comments.OrderByCreateTimeDesc();
        }
    }
}