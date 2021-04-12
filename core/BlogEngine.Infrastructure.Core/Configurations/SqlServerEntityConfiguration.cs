using BlogEngine.Domain.Core;

namespace BlogEngine.Infrastructure.Core.Configurations
{
    public abstract class SqlServerEntityConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : Entity
    {
        protected sealed override string GetUtcDateTimeFunction { get; } = "getutcdate()";
    }
}