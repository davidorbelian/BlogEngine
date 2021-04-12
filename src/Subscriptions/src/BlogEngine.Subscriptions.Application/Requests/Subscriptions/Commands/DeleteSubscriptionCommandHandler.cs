using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Core.Extensions;
using BlogEngine.Subscriptions.Application.Abstractions;
using JetBrains.Annotations;
using MediatR;

namespace BlogEngine.Subscriptions.Application.Requests.Subscriptions.Commands
{
    [UsedImplicitly]
    public sealed class DeleteSubscriptionCommandHandler
        : IRequestHandler<DeleteSubscriptionCommand>
    {
        private readonly ISubscriptionsContext _context;

        public DeleteSubscriptionCommandHandler(ISubscriptionsContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _context.Subscriptions
                .SingleOrNotFoundExceptionAsync(s => s.Email == request.Email, cancellationToken);

            _context.Subscriptions.Remove(subscription);

            return Unit.Value;
        }
    }
}