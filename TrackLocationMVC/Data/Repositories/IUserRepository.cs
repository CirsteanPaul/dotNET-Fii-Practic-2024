using TrackLocationMVC.Data.Entities;

namespace TrackLocationMVC.Data.Repositories;

public interface IUserRepository
{
    AppDbContext DbContext { get; }
    User? GetUserById(int userId);
    User? GetByName(string name);
}