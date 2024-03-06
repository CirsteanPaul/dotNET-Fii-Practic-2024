using TrackLocationMVC.Api.Mappers;
using TrackLocationMVC.Data.Repositories;
using TrackLocationMVC.Services.Exceptions;

namespace TrackLocationMVC.Services.Features.FollowFeature;

public class FollowService : IFollowService
{
    private readonly IFollowRepository _followRepository;

    public FollowService(IFollowRepository followRepository)
    {
        _followRepository = followRepository;
    }

    public IEnumerable<FollowDto> GetFollowers(int page, int userId)
    {
        var follows = _followRepository.GetMyFollowers(page, userId);

        return follows.Select(x => x.ToDto());
    }

    public int GetFollowersCount(int userId)
    {
        var count = _followRepository.GetMyFollowersCount(userId);

        return count;
    }

    public void AcceptFollow(int userId, int followId)
    {
        var friendship = _followRepository.GetById(followId);

        if (friendship is null)
        {
            throw new BusinessException();
        }

        if (friendship.FollowedId != userId)
        {
            throw new BusinessException();
        }

        friendship.IsAccepted = true;
        _followRepository.DbContext.Follows.Update(friendship);
    
        _followRepository.DbContext.SaveChanges();
    }
}