using TrackLocationMVC.Data.Entities;

namespace TrackLocationMVC.Data.Repositories;

public class FollowRepository : IFollowRepository
{
    public FollowRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public AppDbContext DbContext { get; }

    public bool IsFriendWith(int userId, int friendId)
    {
        return DbContext.Follows.Any(x => x.FollowerId == userId && x.FollowedId == friendId && x.IsAccepted == true);
    }

    public IEnumerable<Follow> GetMyFollowers(int page, int userId)
    {
        return DbContext.Follows
            .Where(x => x.FollowedId == userId)
            .OrderBy(x => x.CreatedAt)
            .Skip((page - 1) * 10)
            .Take(10)
            .ToList();
    }

    public int GetMyFollowersCount(int userId)
    {
        return DbContext.Follows
            .Count(x => x.FollowedId == userId);
    }

    public Follow? GetById(int followId)
    {
        return DbContext.Follows.FirstOrDefault(x => x.Id == followId);
    }
}