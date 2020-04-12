using MediatR;

namespace BlogEngine.Application.Articles
{
    public sealed class UpdateArticleCommand : IRequest<string>
    {
        public UpdateArticleCommand(string id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }

        public string Id { get; }
        public string Title { get; }
        public string Content { get; }
    }
}