using TrackLocationMVC.Api.Models.FollowModels;
using TrackLocationMVC.Data.Entities;
using TrackLocationMVC.Services.Features.FollowFeature;

namespace TrackLocationMVC.Api.Mappers;

public static class FollowMapper
{
    public static FollowDto ToDto(this Follow entity)
    {
        if (entity is null)
        {
            return null;
        }

        return new FollowDto()
        {
            Id = entity.Id,
            IsAccepted = entity.IsAccepted,
            CreatedAt = entity.CreatedAt,
            FollowedId = entity.FollowedId,
            FollowerId = entity.FollowerId,
            Follower = entity.Follower,
            Followed = entity.Followed
        };
    }
    
    public static FollowModel ToModel(this FollowDto dto)
    {
        if (dto is null)
        {
            return null;
        }

        return new FollowModel()
        {
            Id = dto.Id,
            IsAccepted = dto.IsAccepted,
            CreatedAt = dto.CreatedAt,
            FollowedId = dto.FollowedId,
            FollowerId = dto.FollowerId,
        };
    }
}