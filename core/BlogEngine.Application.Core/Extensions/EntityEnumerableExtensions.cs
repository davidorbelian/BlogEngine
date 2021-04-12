using System;
using System.Collections.Generic;
using System.Linq;
using BlogEngine.Application.Core.Exceptions;
using BlogEngine.Domain.Core;

namespace BlogEngine.Application.Core.Extensions
{
    public static class EntityEnumerableExtensions
    {
        public static TEntity SingleOrNotFoundException<TEntity>(
            this IEnumerable<TEntity> source,
            Guid id)
            where TEntity : Entity
        {
            return source.SingleOrDefault(e => e.Id == id) ??
                   throw new EntityNotFoundException<TEntity>(id);
        }

        public static IEnumerable<TEntity> OrderByCreateTimeDesc<TEntity>(this IEnumerable<TEntity> source)
            where TEntity : Entity
        {
            return source.OrderByDescending(e => e.CreateTime);
        }
    }
}