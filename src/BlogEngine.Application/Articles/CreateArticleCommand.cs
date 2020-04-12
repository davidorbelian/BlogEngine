using MediatR;

namespace BlogEngine.Application.Articles
{
    public sealed class CreateArticleCommand : IRequest<string>
    {
        public CreateArticleCommand(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; }
        public string Content { get; }
    }
}