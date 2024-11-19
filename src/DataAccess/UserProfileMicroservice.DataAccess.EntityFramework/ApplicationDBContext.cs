using Microsoft.EntityFrameworkCore;
using UserProfileMicroservice.DataAccess.Entities;

namespace UserProfileMicroservice.DataAccess.EntityFramework;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserProfile> UserProfiles { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.Entity<UserProfile>()
        .HasQueryFilter(x => !x.SoftDeleted);
    }
}
