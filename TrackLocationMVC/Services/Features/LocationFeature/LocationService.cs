using TrackLocationMVC.Data.Entities;
using TrackLocationMVC.Data.Repositories;

namespace TrackLocationMVC.Services.Features.LocationFeature;

// This is for example a service used only to add a new entry to the database.
// Of course this service will use the interface ILocationService.
public class LocationService : ILocationService
{
    // This will be a repository. Basically is the service which is responsible with the management
    // of the location entity in the database.
    // More on this in the next course.
    private readonly ILocationRepository _locationRepository;

    // Dependency injection as in the controller.
    public LocationService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    // The method used in the LocationController.
    // We receive a DTO and return void.
    public void SendLocation(SendLocationDto dto)
    {
        // We just map the dto to the entity location(entity is the class which represents the exact table in the database)
        var newLocation = new Location()
        {
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            UserId = dto.UserId,
            CreatedAt = DateTime.UtcNow
        };

        // We add the new location to the locations table.
        _locationRepository.DbContext.Locations.Add(newLocation);
        // And finally we save the changes in the database.
        _locationRepository.DbContext.SaveChanges();
    }
}