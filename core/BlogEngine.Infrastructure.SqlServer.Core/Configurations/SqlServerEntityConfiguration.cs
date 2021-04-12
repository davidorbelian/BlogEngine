using BlogEngine.Domain.Core;
using BlogEngine.Infrastructure.Core.Configurations;

namespace BlogEngine.Infrastructure.SqlServer.Core.Configurations
{
    public abstract class SqlServerEntityConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : Entity
    {
        protected sealed override string GetUtcDateTimeFunction { get; } = "getutcdate()";
    }
}