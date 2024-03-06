namespace TrackLocationMVC.Services.Features.LocationFeature;

public interface ILocationService
{
    void SendLocation(SendLocationDto dto);
}