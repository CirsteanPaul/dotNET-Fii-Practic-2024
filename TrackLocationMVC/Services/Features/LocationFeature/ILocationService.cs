namespace TrackLocationMVC.Services.Features.LocationFeature;

// We need an interface for our service implementation (best practice) + needed for dependency injection.
public interface ILocationService
{
    void SendLocation(SendLocationDto dto);
}