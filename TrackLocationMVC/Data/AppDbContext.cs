using Microsoft.EntityFrameworkCore;
using TrackLocationMVC.Data.Entities;

public sealed class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Follow> Follows { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
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