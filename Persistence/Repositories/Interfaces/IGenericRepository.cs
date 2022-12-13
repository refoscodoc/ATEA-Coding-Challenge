using Persistence.Models;

namespace Persistence.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> Get();
    Task<T> GetById(Guid id);
    Task<DatabaseEntry> Save(DatabaseEntry entity);
}