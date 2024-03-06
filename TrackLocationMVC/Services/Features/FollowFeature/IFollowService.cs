namespace TrackLocationMVC.Services.Features.FollowFeature;

public interface IFollowService
{
    IEnumerable<FollowDto> GetFollowers(int page, int userId);
    int GetFollowersCount(int userId);
    void AcceptFollow(int userId, int followId);
}