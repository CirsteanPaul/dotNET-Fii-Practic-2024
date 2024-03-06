// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;

var context = new AppDbContext();

context.Users.Add(new User() { Name = "Paul" });
context.Users.Add(new User() { Name = "George" });
context.Users.Add(new User() { Name = "Vlad" });
context.Grades.Add(new Grade() { Id = 1, Mark = 5, UserId = "Paul"});
context.Grades.Add(new Grade() { Id = 2, Mark = 2, UserId = "George"});
context.Grades.Add(new Grade() { Id = 3, Mark = 10, UserId = "Vlad"});
context.Grades.Add(new Grade() { Id = 4, Mark = 7, UserId = "Paul"});
context.SaveChanges();

var context2 = new AppDbContext();

var allUsers = context2.Users.Include(u => u.Grades).ToList();
// daca nu se pune include nu se populeaza grades.

foreach (var user in allUsers)
{
    Console.WriteLine(user.Name);
    foreach (var grade in user.Grades)
    {
        Console.Write($"{grade.Mark}, ");
    }
    Console.WriteLine();
}

var allGrades = context2.Grades.ToList();

Console.WriteLine();
foreach (var grade in allGrades)
{
    Console.WriteLine($"{grade.Mark} {grade.User.Name}");
    
}

class User
{
    public string Name { get; set; }
    public IEnumerable<Grade> Grades { get; set; } = new List<Grade>();
}

class Grade
{
    public int Id { get; set; }
    public int Mark { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}
class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Grade> Grades { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("test");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Name);
        modelBuilder.Entity<Grade>().HasKey(u => u.Id);
        
        // obligatoriu orice obiect din baza de date trebuie sa aiba o cheie de o anumita forma.
        
        modelBuilder.Entity<Grade>().HasOne(u => u.User)
            .WithMany(g => g.Grades);
        
        // merge cu nicio relatie desi ar fi bine sa fie relatii.
    }
}