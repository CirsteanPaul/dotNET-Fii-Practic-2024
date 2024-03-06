using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Database.Repository;

namespace RepositoryPattern.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public User? GetById(int id)
    {
        return Context.Users.FirstOrDefault(x => x.Id == id);
    }
}