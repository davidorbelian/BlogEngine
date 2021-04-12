using BlogEngine.Application.Core.Abstractions;
using BlogEngine.Articles.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Articles.Application.Abstractions
{
    public interface IArticlesContext : IDbContext
    {
        DbSet<Article> Articles { get; }
    }
}