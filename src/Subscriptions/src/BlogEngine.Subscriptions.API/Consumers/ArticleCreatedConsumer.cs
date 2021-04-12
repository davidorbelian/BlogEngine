using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEngine.Articles.Events;
using BlogEngine.Subscriptions.API.Configuration;
using BlogEngine.Subscriptions.Application.Abstractions;
using BlogEngine.Subscriptions.Application.Requests.Subscriptions.Queries;
using MassTransit;
using MediatR;

namespace BlogEngine.Subscriptions.API.Consumers
{
    public sealed class ArticleCreatedConsumer : IConsumer<ArticleCreatedEvent>
    {
        private readonly EmailsConfiguration _emails;
        private readonly IEmailService _emailService;
        private readonly IMediator _mediator;

        public ArticleCreatedConsumer(IEmailService emailService, IMediator mediator, EmailsConfiguration emails)
        {
            _emailService = emailService;
            _mediator = mediator;
            _emails = emails;
        }

        public async Task Consume(ConsumeContext<ArticleCreatedEvent> context)
        {
            var articleCreated = context.Message;
            var emails = await GetEmails(articleCreated.HashTags);

            await Task.WhenAll(emails.Select(toEmail => _emailService.Send(
                toEmail,
                _emails.NotificationsFrom,
                articleCreated.Title,
                GetMessage(articleCreated.Title))));
        }

        private async Task<IEnumerable<string>> GetEmails(IEnumerable<string> hashTags)
        {
            var emails = await Task.WhenAll(hashTags.Select(GetEmails));
            return new HashSet<string>(emails.SelectMany(e => e));
        }

        private async Task<IEnumerable<string>> GetEmails(string hashTag)
        {
            var subscriptions = await _mediator.Send(new GetSubscriptionsByHashTagQuery(hashTag));
            return subscriptions.Select(s => s.Email);
        }

        // TODO: Use Templates?
        private static string GetMessage(string title)
        {
            return $"<h2>{title}</h2>" +
                   "Visit the Blog to read the new article.";
        }
    }
}