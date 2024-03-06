namespace TrackLocationMVC.Services.Features.UserFeature;

public interface IUserService
{
    void ChangePassword(ChangePasswordDto dto);
    UserDetailsDto GetFriendDetails(int friendId, int userId);
}