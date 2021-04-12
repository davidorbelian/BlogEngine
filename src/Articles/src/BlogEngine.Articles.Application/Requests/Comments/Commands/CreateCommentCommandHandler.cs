using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Core.Extensions;
using BlogEngine.Articles.Application.Abstractions;
using BlogEngine.Articles.Domain.Entities;
using JetBrains.Annotations;
using MediatR;

namespace BlogEngine.Articles.Application.Requests.Comments.Commands
{
    [UsedImplicitly]
    public sealed class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Comment>
    {
        private readonly IArticlesContext _context;

        public CreateCommentCommandHandler(IArticlesContext context)
        {
            _context = context;
        }

        public async Task<Comment> Handle(
            CreateCommentCommand request,
            CancellationToken cancellationToken)
        {
            var article = await _context.Articles
                .SingleOrNotFoundExceptionAsync(request.ArticleId, cancellationToken);

            article.AddComment(request.Author, request.Content);

            return article.Comments.Single();
        }
    }
}