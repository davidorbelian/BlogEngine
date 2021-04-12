using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Core.Exceptions;
using BlogEngine.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Application.Core.Extensions
{
    public static class EntityQueryableExtensions
    {
        public static async Task<TEntity> SingleOrNotFoundExceptionAsync<TEntity>(
            this IQueryable<TEntity> source,
            Guid id,
            CancellationToken cancellationToken)
            where TEntity : Entity
        {
            return await source.SingleOrDefaultAsync(e => e.Id == id, cancellationToken) ??
                   throw new EntityNotFoundException<TEntity>(id);
        }

        public static async Task<TEntity> SingleOrNotFoundExceptionAsync<TEntity>(
            this IQueryable<TEntity> source,
            Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken)
            where TEntity : Entity
        {
            return await source.SingleOrDefaultAsync(expression, cancellationToken) ??
                   throw new EntityNotFoundException<TEntity>();
        }

        public static IQueryable<TEntity> OrderByCreateTimeDesc<TEntity>(this IQueryable<TEntity> source)
            where TEntity : Entity
        {
            return source.OrderByDescending(e => e.CreateTime);
        }
    }
}