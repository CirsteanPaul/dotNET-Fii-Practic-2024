using TrackLocationMVC.Data.Entities;

namespace TrackLocationMVC.Data.Repositories;

public interface IFollowRepository
{ 
    public AppDbContext DbContext { get; }
    bool IsFriendWith(int userId, int friendId);
    IEnumerable<Follow> GetMyFollowers(int page, int userId);
    int GetMyFollowersCount(int userId);
    Follow? GetById(int followId);
}