using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Core.Requests;
using BlogEngine.Articles.Application.Abstractions;
using MediatR.Pipeline;

namespace BlogEngine.Articles.Application.RequestPostProcessors
{
    // TODO: Make this Generic for IDbContext
    public sealed class
        SaveChangesCommandPostProcessor<TCommand, TResponse> : IRequestPostProcessor<TCommand, TResponse>
        where TCommand : Command<TResponse>
    {
        private readonly IArticlesContext _context;

        public SaveChangesCommandPostProcessor(IArticlesContext context)
        {
            _context = context;
        }

        public async Task Process(TCommand request, TResponse response, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}