using TrackLocationMVC.Api.Models.LocationModels;
using TrackLocationMVC.Data.Entities;
using TrackLocationMVC.Services.Features.LocationFeature;

namespace TrackLocationMVC.Api.Mappers;

// A mappers is a class which just parse data to an object to another object.
// This methods should always be dumb methods and never contain complicated logic.
// This classes/methods can be created as static because we don't care about an instance. They are more like utility functions.
public static class LocationMapper
{
    // So from the method we can see that this method will transform a LocationModel to a SendLocationDto.
    // We will append the userId as well to the dto.
    // The keyword this is used so this method will be a extension method:
    // More details: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
    // As the first line of this article says an extension method is a method added to a class already existing without modifying the class itself.
    // That being said because we have this method the LocationModel object will have a method called ToDto(int) -> SendLocationDto
    public static SendLocationDto ToDto(this LocationModel model, int userId)
    {
        // Here we just create the new object which should be returned and map the properties from 
        // the LocationModel instance to a SendLocation instance.
        // Look around the project and see that the mappers look similar to each other. 
        return new SendLocationDto()
        {
            Latitude = model.Latitude,
            Longitude = model.Longitude,
            UserId = userId
        };
    }
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
}