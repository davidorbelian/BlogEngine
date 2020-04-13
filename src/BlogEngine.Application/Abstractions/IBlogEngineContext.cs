using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Application.Abstractions
{
    public interface IBlogEngineContext
    {
        DbSet<Article> Articles { get; }
        DbSet<Comment> Comments { get; }
        DbSet<HashTag> HashTags { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}