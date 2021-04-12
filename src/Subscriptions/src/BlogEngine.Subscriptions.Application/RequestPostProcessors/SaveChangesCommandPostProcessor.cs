using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Core.Requests;
using BlogEngine.Subscriptions.Application.Abstractions;
using MediatR.Pipeline;

namespace BlogEngine.Subscriptions.Application.RequestPostProcessors
{
    // TODO: Make this Generic for IDbContext
    public sealed class SaveChangesCommandPostProcessor<TCommand, TResponse>
        : IRequestPostProcessor<TCommand, TResponse>
        where TCommand : Command<TResponse>
    {
        private readonly ISubscriptionsContext _context;

        public SaveChangesCommandPostProcessor(ISubscriptionsContext context)
        {
            _context = context;
        }

        public async Task Process(TCommand request, TResponse response, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}