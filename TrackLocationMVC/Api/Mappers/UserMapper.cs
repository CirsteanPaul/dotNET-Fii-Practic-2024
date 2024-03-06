using TrackLocationMVC.Api.Models.UserModels;
using TrackLocationMVC.Data.Entities;
using TrackLocationMVC.Services.Features.UserFeature;

namespace TrackLocationMVC.Api.Mappers;

public static class UserMapper
{
    public static ChangePasswordDto? ToDto(this ChangePasswordRequest request, int userId)
    {
        return new ChangePasswordDto()
        {
            NewPassword = request.NewPassword,
            UserId = userId
        };
    }

    public static UserDetailsDto? ToDto(this User? entity)
    {
        if (entity is null)
        {
            return null;
        }

        return new UserDetailsDto()
        {
            Name = entity.Name,
            Location = entity.Locations.LastOrDefault().ToDto() ?? null
        };
    }

    public static UserDetails ToModel(this UserDetailsDto dto)
    {
        return new UserDetails()
        {
            Name = dto.Name,
            Location = dto.Location.ToModel()
        };
    }
}