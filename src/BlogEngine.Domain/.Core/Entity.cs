using System;

// ReSharper disable UnusedAutoPropertyAccessor.Local
namespace BlogEngine.Domain.Core
{
    public abstract class Entity
    {
        public string Id { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}