using ATEA_coding_challenge.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.DataAccessLayer;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories;

public class AteaChallengeRepository : IAteaChallengeRepository
{
    private readonly AteaChallengeDbContext _ateaChallengeDbContext;

    public AteaChallengeRepository(AteaChallengeDbContext ateaChallengeDbContext)
    {
        _ateaChallengeDbContext = ateaChallengeDbContext;
    }

    public async Task<List<DatabaseEntry>> Get()
    {
        return await _ateaChallengeDbContext
            .AteaChallengeDatabase
            .OrderByDescending(x => x.Timestamp)
            .Take(5)
            .ToListAsync();
    }

    public async Task<DatabaseEntry> GetById(Guid id)
    {
        return await _ateaChallengeDbContext
            .AteaChallengeDatabase
            .FirstAsync(x => x.Id == id);
    }

    public async Task<DatabaseEntry> Save(DatabaseEntry entity)
    {
        await _ateaChallengeDbContext.AteaChallengeDatabase.AddAsync(entity);
        return entity;
    }

    public async Task<List<DatabaseEntry>> SaveAll(string[] args)
    {
        var result = new List<DatabaseEntry>();
        foreach (var arg in args)
        {
            var entry = new DatabaseEntry
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.Now,
                Entry = arg
            };
            await _ateaChallengeDbContext.AddAsync(entry);
            result.Add(entry);
        }
        await _ateaChallengeDbContext.SaveChangesAsync();
        return result;
    }
}