using System;
using BlogEngine.Domain.Core;

namespace BlogEngine.Application.Core.Exceptions
{
    public abstract class EntityNotFoundException : Exception
    {
        protected EntityNotFoundException(string entityName) :
            base($"{entityName} not found.") { }

        protected EntityNotFoundException(string entityName, Guid id) :
            base($"{entityName} with ID: {id} not found.") { }
    }


    public sealed class EntityNotFoundException<TEntity> : EntityNotFoundException
        where TEntity : Entity
    {
        public EntityNotFoundException() : base(typeof(TEntity).Name) { }
        public EntityNotFoundException(Guid id) : base(typeof(TEntity).Name, id) { }
    }
}