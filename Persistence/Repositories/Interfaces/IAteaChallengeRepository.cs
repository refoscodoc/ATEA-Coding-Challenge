using Persistence.Models;

namespace Persistence.Repositories.Interfaces;

public interface IAteaChallengeRepository : IGenericRepository<DatabaseEntry>
{
    Task<List<DatabaseEntry>> SaveAll(string[] args);
}