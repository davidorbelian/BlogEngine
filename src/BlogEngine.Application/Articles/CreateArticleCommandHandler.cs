using System;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Abstractions;
using BlogEngine.Domain.Entities;
using BlogEngine.Domain.Relations;
using JetBrains.Annotations;
using MediatR;

namespace BlogEngine.Application.Articles
{
    [UsedImplicitly]
    public sealed class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, string>
    {
        private readonly IBlogEngineContext _context;
        private readonly IHashTagParser _hashTagParser;

        public CreateArticleCommandHandler(
            IBlogEngineContext context,
            IHashTagParser hashTagParser)
        {
            _context = context;
            _hashTagParser = hashTagParser;
        }

        public async Task<string> Handle(
            CreateArticleCommand request,
            CancellationToken cancellationToken)
        {
            var article = new Article
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                Content = request.Content
            };

            var hashTagIds = _hashTagParser.Parse(request.Content);

            foreach (var hashTagId in hashTagIds)
            {
                var hashTag = new HashTag {Id = hashTagId};
                var articleHashTag = new ArticleHashTag {HashTag = hashTag};

                article.HashTags.Add(articleHashTag);
            }

            _context.Articles.Add(article);

            await _context.SaveChangesAsync(cancellationToken);

            return article.Id;
        }
    }
}