using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngine.Application.Articles
{
    public sealed class GetArticleByIdQuery : IRequest<Article>
    {
        public GetArticleByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}