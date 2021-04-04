using System;
using BlogEngine.Domain.Core;

namespace BlogEngine.Application.Exceptions
{
    public sealed class EntityNotFoundException<TEntity> : Exception
        where TEntity : Entity
    {
        public EntityNotFoundException(string id) : base($"{typeof(TEntity).Name} with ID: {id} not found.") { }
    }
}