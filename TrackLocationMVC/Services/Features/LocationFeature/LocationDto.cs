namespace TrackLocationMVC.Services.Features.LocationFeature;

// Dto the object used in the services layer. All the input of any methods should be dtos and the returned values as well DTOs
// This architecture is mainly focused on dumb classes which are used in services. The services are the logic of the app itself
public class LocationDto
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public DateTime CreatedAt { get; set; } 
}
