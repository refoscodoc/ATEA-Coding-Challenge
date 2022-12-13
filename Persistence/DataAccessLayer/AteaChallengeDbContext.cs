using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.DataAccessLayer;

public class AteaChallengeDbContext : DbContext
{
    public AteaChallengeDbContext(DbContextOptions<AteaChallengeDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { }
    
    public virtual DbSet<DatabaseEntry> AteaChallengeDatabase { get; set; }
}