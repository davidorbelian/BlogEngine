using MediatR;

namespace BlogEngine.Application.Articles
{
    public sealed class DeleteArticleCommand : IRequest
    {
        public DeleteArticleCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}