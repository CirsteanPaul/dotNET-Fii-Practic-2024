using Microsoft.EntityFrameworkCore;
using TrackLocationMVC.Data.Entities;

namespace TrackLocationMVC.Data.Repositories;

public class UserRepository : IUserRepository
{

    public UserRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public AppDbContext DbContext { get; }

    public User? GetUserById(int userId)
    {
        return DbContext.Users.Include(u => u.Locations).FirstOrDefault(x => x.Id == userId);
    }

    public User? GetByName(string name)
    {
        return DbContext.Users.FirstOrDefault(u => u.Name == name);
    }
}