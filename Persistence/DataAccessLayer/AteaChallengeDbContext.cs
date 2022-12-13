using ATEA_coding_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DataAccessLayer;

public class AteaChallengeDbContext : DbContext
{
    public AteaChallengeDbContext(DbContextOptions<AteaChallengeDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { }
    
    public virtual DbSet<DatabaseEntry> AteaChallengeDatabase { get; set; }
}