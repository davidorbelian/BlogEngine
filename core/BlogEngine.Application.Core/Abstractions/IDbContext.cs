using System.Threading;
using System.Threading.Tasks;

namespace BlogEngine.Application.Core.Abstractions
{
    public interface IDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}