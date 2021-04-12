using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Subscriptions.Application.Abstractions;
using BlogEngine.Subscriptions.Domain.Entities;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Subscriptions.Application.Requests.Subscriptions.Commands
{
    [UsedImplicitly]
    public sealed class CreateOrUpdateSubscriptionCommandHandler
        : IRequestHandler<CreateOrUpdateSubscriptionCommand>
    {
        private readonly ISubscriptionsContext _context;

        public CreateOrUpdateSubscriptionCommandHandler(ISubscriptionsContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateOrUpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var existingSubscription = await _context.Subscriptions
                .SingleOrDefaultAsync(s => s.Email == request.Email, cancellationToken);

            if (existingSubscription == null)
            {
                var subscription = new Subscription(request.Email, request.HashTags);
                _context.Subscriptions.Add(subscription);
            }
            else
            {
                existingSubscription.Update(request.HashTags);
            }

            return Unit.Value;
        }
    }
}