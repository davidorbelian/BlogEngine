using System;

// ReSharper disable UnusedAutoPropertyAccessor.Local
namespace BlogEngine.Domain.Core
{
    public abstract class Entity
    {
        protected Entity()
        {
            var time = DateTime.UtcNow;

            CreateTime = time;
            UpdateTime = time;
        }

        public string Id { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}