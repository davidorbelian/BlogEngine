using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Core.Extensions;
using BlogEngine.Subscriptions.Application.Abstractions;
using BlogEngine.Subscriptions.Domain.Entities;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Subscriptions.Application.Requests.Subscriptions.Queries
{
    [UsedImplicitly]
    public sealed class GetSubscriptionByEmailQueryHandler
        : IRequestHandler<GetSubscriptionByEmailQuery, Subscription>
    {
        private readonly ISubscriptionsContext _context;

        public GetSubscriptionByEmailQueryHandler(ISubscriptionsContext context)
        {
            _context = context;
        }

        public Task<Subscription> Handle(GetSubscriptionByEmailQuery request, CancellationToken cancellationToken)
        {
            return _context.Subscriptions
                .AsNoTracking()
                .SingleOrNotFoundExceptionAsync(s => s.Email == request.Email, cancellationToken);
        }
    }
}