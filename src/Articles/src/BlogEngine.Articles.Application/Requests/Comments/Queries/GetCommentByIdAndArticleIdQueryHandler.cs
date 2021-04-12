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
    public sealed class
        GetCommentByIdAndArticleIdQueryHandler : IRequestHandler<GetCommentByIdAndArticleIdQuery, Comment>
    {
        private readonly IArticlesContext _context;

        public GetCommentByIdAndArticleIdQueryHandler(IArticlesContext context)
        {
            _context = context;
        }

        public async Task<Comment> Handle(
            GetCommentByIdAndArticleIdQuery request,
            CancellationToken cancellationToken)
        {
            var article = await _context.Articles
                .AsNoTracking()
                .Include(a => a.Comments)
                .SingleOrNotFoundExceptionAsync(request.ArticleId, cancellationToken);

            var comment = article.Comments.SingleOrNotFoundException(request.Id);

            return comment;
        }
    }
}