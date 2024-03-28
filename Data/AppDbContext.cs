using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().Property(u => u.Username).HasMaxLength(30);
        modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(30);
        modelBuilder.Entity<User>().Property(u => u.Password).HasMaxLength(30);
    }
}