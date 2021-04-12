using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Subscriptions.Application.Abstractions;
using BlogEngine.Subscriptions.Domain.Entities;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Subscriptions.Application.Requests.Subscriptions.Queries
{
    [UsedImplicitly]
    public sealed class
        GetSubscriptionsByHashTagQueryHandler
        : IRequestHandler<GetSubscriptionsByHashTagQuery, IEnumerable<Subscription>>
    {
        private readonly ISubscriptionsContext _context;

        public GetSubscriptionsByHashTagQueryHandler(ISubscriptionsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subscription>> Handle(
            GetSubscriptionsByHashTagQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Subscriptions
                .AsNoTracking()
                .Where(s => s.HashTags.Any(ht => ht.Id.ToLower() == request.HashTag.ToLower()))
                .ToListAsync(cancellationToken);
        }
    }
}