using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Subscriptions.Application.Abstractions;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Subscriptions.Application.Requests.Subscriptions.Queries
{
    [UsedImplicitly]
    public sealed class GetSubscriptionCountByHashTagQueryHandler
        : IRequestHandler<GetSubscriptionCountByHashTagQuery, int>
    {
        private readonly ISubscriptionsContext _context;

        public GetSubscriptionCountByHashTagQueryHandler(ISubscriptionsContext context)
        {
            _context = context;
        }

        public Task<int> Handle(GetSubscriptionCountByHashTagQuery request, CancellationToken cancellationToken)
        {
            return _context.Subscriptions
                .AsNoTracking()
                .Where(s => s.HashTags.Any(ht => ht.Id.ToLower() == request.HashTag.ToLower()))
                .CountAsync(cancellationToken);
        }
    }
}