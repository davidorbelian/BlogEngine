using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Domain.Core;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BlogEngine.Infrastructure.Core.Dispatchers
{
    public sealed class DomainEventsDispatcher : SaveChangesInterceptor
    {
        private readonly IMediator _mediator;

        public DomainEventsDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            return SavedChangesAsync(eventData, result).GetAwaiter().GetResult();
        }

        public override async ValueTask<int> SavedChangesAsync(
            SaveChangesCompletedEventData eventData,
            int result,
            CancellationToken cancellationToken = new())
        {
            await DispatchDomainEventsAsync(eventData.Context.ChangeTracker);

            return result;
        }

        private async Task DispatchDomainEventsAsync(ChangeTracker changeTracker)
        {
            var domainEntities = changeTracker
                .Entries<Entity>()
                .Select(x => x.Entity)
                .Where(x => x.Events.Any())
                .ToList();

            foreach (var entity in domainEntities)
            {
                var events = entity.Events.ToArray();

                entity.ClearDomainEvents();

                foreach (var domainEvent in events) await _mediator.Publish(domainEvent).ConfigureAwait(false);
            }
        }
    }
}