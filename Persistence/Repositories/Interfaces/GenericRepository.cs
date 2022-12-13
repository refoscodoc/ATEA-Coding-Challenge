using Microsoft.EntityFrameworkCore;
using Persistence.DataAccessLayer;
using Persistence.Models;

namespace Persistence.Repositories.Interfaces;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AteaChallengeDbContext _dbContext;

    public GenericRepository(AteaChallengeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<T>> Get()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<DatabaseEntry> Save(DatabaseEntry entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}