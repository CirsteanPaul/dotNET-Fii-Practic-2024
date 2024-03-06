using TrackLocationMVC.Api.Mappers;
using TrackLocationMVC.Data.Repositories;
using TrackLocationMVC.Services.Exceptions;

namespace TrackLocationMVC.Services.Features.UserFeature;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IFollowRepository _followRepository;
    
    public UserService(IUserRepository userRepository, IFollowRepository followRepository)
    {
        _userRepository = userRepository;
        _followRepository = followRepository;
    }

    public void ChangePassword(ChangePasswordDto dto)
    {
        var user = _userRepository.GetUserById(dto.UserId);

        if (user is null)
        {
            throw new BusinessException();
        }

        user.Password = dto.NewPassword;

        _userRepository.DbContext.Users.Update(user);
        _userRepository.DbContext.SaveChanges();
    }
    
    public UserDetailsDto GetFriendDetails(int friendId, int userId)
    {
        var friendship = _followRepository.IsFriendWith(userId, friendId);
    
        if (!friendship)
        {
            throw new BusinessException();
        }

        var friend = _userRepository.GetUserById(friendId);
        
        return friend.ToDto()!;
    }
}