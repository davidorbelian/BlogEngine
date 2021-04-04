using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Exceptions;
using BlogEngine.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Application.Extensions
{
    public static class EntityQueryableExtensions
    {
        public static Task<TEntity> SingleOrNotFoundExceptionAsync<TEntity>(
            this IQueryable<TEntity> source,
            string id,
            CancellationToken cancellationToken)
            where TEntity : Entity
        {
            return source.SingleOrDefaultAsync(e => e.Id == id, cancellationToken) ??
                   throw new EntityNotFoundException<TEntity>(id);
        }
    }
}