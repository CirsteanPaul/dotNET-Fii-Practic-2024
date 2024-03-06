using TrackLocationMVC.Api.Models.LocationModels;
using TrackLocationMVC.Data.Entities;
using TrackLocationMVC.Services.Features.LocationFeature;

namespace TrackLocationMVC.Api.Mappers;

public static class LocationMapper
{
    public static LocationDto? ToDto(this Location? entity)
    {
        if (entity is null)
        {
            return null;
        }

        return new LocationDto()
        {
            Latitude = entity.Latitude,
            Longitude = entity.Longitude
        };
    }
    
    public static LocationResponse ToModel(this LocationDto? entity)
    {
        if (entity is null)
        {
            return null;
        }

        return new LocationResponse()
        {
            Latitude = entity.Latitude,
            Longitude = entity.Longitude
        };
    }

    public static SendLocationDto ToDto(this LocationModel model, int userId)
    {
        return new SendLocationDto()
        {
            Latitude = model.Latitude,
            Longitude = model.Longitude,
            UserId = userId
        };
    }
}