using System;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Abstractions;
using BlogEngine.Application.Exceptions;
using BlogEngine.Domain.Relations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Application.Articles
{
    // ReSharper disable once UnusedMember.Global
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
                              .SingleOrDefaultAsync(a => a.Id == request.Id, cancellationToken) ??
                          throw new ArticleNotFoundException(request.Id);

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