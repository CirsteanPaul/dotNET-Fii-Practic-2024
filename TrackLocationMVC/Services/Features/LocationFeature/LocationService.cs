using TrackLocationMVC.Data.Entities;
using TrackLocationMVC.Data.Repositories;

namespace TrackLocationMVC.Services.Features.LocationFeature;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;

    public LocationService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public void SendLocation(SendLocationDto dto)
    {
        var newLocation = new Location()
        {
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            UserId = dto.UserId,
            CreatedAt = DateTime.UtcNow
        };

        _locationRepository.DbContext.Locations.Add(newLocation);
        _locationRepository.DbContext.SaveChanges();
    }
}