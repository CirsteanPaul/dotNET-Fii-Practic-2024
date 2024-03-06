using Microsoft.EntityFrameworkCore;

namespace TrackLocation;

public sealed class Database : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Follow> Follows { get; set; }
    
    public Database(DbContextOptions<Database> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<Location>().HasKey(u => u.Id);
        modelBuilder.Entity<Follow>().HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Locations)
            .WithOne(l => l.User);

        modelBuilder.Entity<Follow>()
            .HasOne<User>(f => f.Follower)
            .WithOne();
        
        modelBuilder.Entity<Follow>()
            .HasOne<User>(f => f.Followed)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
    }
}