using System.Collections.Generic;
using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngine.Application.Articles
{
    public sealed class GetArticlesByHashTagQuery : IRequest<IEnumerable<Article>>
    {
        public GetArticlesByHashTagQuery(string hashTag)
        {
            HashTag = hashTag;
        }

        public string HashTag { get; }
    }
}