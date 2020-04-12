using MediatR;

namespace BlogEngine.Application.Comments
{
    // ReSharper disable once UnusedMember.Global
    public sealed class CreateCommentCommand : IRequest<string>
    {
        public CreateCommentCommand(string author, string content, string articleId)
        {
            Author = author;
            Content = content;
            ArticleId = articleId;
        }

        public string Author { get; }
        public string Content { get; }

        public string ArticleId { get; }
    }
}