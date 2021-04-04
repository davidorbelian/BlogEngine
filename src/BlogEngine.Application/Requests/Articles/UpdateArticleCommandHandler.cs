using System;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Abstractions;
using BlogEngine.Application.Extensions;
using BlogEngine.Domain.Relations;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Application.Requests.Articles
{
    [UsedImplicitly]
    public sealed class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, string>
    {
        private readonly IBlogEngineContext _context;
        private readonly IHashTagParser _hashTagParser;

        public UpdateArticleCommandHandler(
            IBlogEngineContext context,
            IHashTagParser hashTagParser)
        {
            _context = context;
            _hashTagParser = hashTagParser;
        }

        public async Task<string> Handle(
            UpdateArticleCommand request,
            CancellationToken cancellationToken)
        {
            var article = await _context.Articles
                .Include(a => a.HashTags)
                .SingleOrNotFoundExceptionAsync(request.Id, cancellationToken);

            article.Title = request.Title;
            article.Content = request.Content;
            article.UpdateTime = DateTime.UtcNow;

            article.HashTags.Clear();

            var hashTagIds = _hashTagParser.Parse(request.Content);

            foreach (var hashTagId in hashTagIds)
            {
                var articleHashTag = new ArticleHashTag {HashTagId = hashTagId};

                article.HashTags.Add(articleHashTag);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return article.Id;
        }
    }
}