using TrackLocationMVC.Api.Mappers;
using TrackLocationMVC.Data.Repositories;
using TrackLocationMVC.Services.Exceptions;

namespace TrackLocationMVC.Services.Features.FollowFeature;

// Here we will find the business logic for the FollowController class
public class FollowService : IFollowService
{
    // This will be the Data Access Layer object which corresponds with the Follows SQL table.
    // Here we will define all operations done to the follows table.
    private readonly IFollowRepository _followRepository;

    // Dependency injection
    public FollowService(IFollowRepository followRepository)
    {
        _followRepository = followRepository;
    }

    // For example we have the logic to get the my followers page.
    // We may have multiple pages so that is why we use page variable.
    // In the Service layer we use DTOs and Entites.
    // In this case Follow is the entity(SQL table) and FollowDto.
    // DTO - Data Transfer Object.
    public IEnumerable<FollowDto> GetFollowers(int page, int userId)
    {
        // We get the data from the database.
        var follows = _followRepository.GetMyFollowers(page, userId);

        // We convert them to the FollowDto class.
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