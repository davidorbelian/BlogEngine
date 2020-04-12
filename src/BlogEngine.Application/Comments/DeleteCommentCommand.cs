using MediatR;

namespace BlogEngine.Application.Comments
{
    public sealed class DeleteCommentCommand : IRequest
    {
        public DeleteCommentCommand(string id, string articleId)
        {
            Id = id;
            ArticleId = articleId;
        }

        public string Id { get; }
        public string ArticleId { get; }
    }
}