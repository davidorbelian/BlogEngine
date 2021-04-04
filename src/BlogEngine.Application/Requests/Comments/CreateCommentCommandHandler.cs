using System;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Abstractions;
using BlogEngine.Application.Extensions;
using BlogEngine.Domain.Entities;
using JetBrains.Annotations;
using MediatR;

namespace BlogEngine.Application.Requests.Comments
{
    [UsedImplicitly]
    public sealed class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Comment>
    {
        private readonly IBlogEngineContext _context;

        public CreateCommentCommandHandler(IBlogEngineContext context)
        {
            _context = context;
        }

        public async Task<Comment> Handle(
            CreateCommentCommand request,
            CancellationToken cancellationToken)
        {
            var article = await _context.Articles.SingleOrNotFoundExceptionAsync(request.ArticleId, cancellationToken);

            var comment = new Comment
            {
                Id = Guid.NewGuid().ToString(),
                Author = request.Author,
                Content = request.Content
            };

            article.Comments.Add(comment);

            await _context.SaveChangesAsync(cancellationToken);

            return comment;
        }
    }
}