using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BlogEngine.Events.Core.Abstractions;
using JetBrains.Annotations;

namespace BlogEngine.Domain.Core
{
    public abstract class Entity
    {
        [NotMapped]
        private readonly List<IDomainEvent> _events = new();

        public Guid Id { get; [UsedImplicitly] private init; }

        public DateTime CreateTime { get; [UsedImplicitly] private init; }
        public DateTime UpdateTime { get; [UsedImplicitly] private init; }

        public IReadOnlyCollection<IDomainEvent> Events => _events.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _events.Clear();
        }
    }
}