using RepositoryPattern.Database.Repository;

namespace RepositoryPattern.Repositories;

public interface IUserRepository : IRepository<User>
{
    User? GetById(int id);
}