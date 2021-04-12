using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Events.Core.Abstractions;
using JetBrains.Annotations;
using MassTransit;
using MediatR;

namespace BlogEngine.Messaging.RabbitMq.NotificationHandlers
{
    [UsedImplicitly]
    public sealed class DomainEventHandler<TEvent> : INotificationHandler<TEvent>
        where TEvent : class, IDomainEvent
    {
        private readonly IPublishEndpoint _endpoint;

        public DomainEventHandler(IPublishEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        public Task Handle(TEvent notification, CancellationToken cancellationToken)
        {
            return _endpoint.Publish(notification, cancellationToken);
        }
    }
}