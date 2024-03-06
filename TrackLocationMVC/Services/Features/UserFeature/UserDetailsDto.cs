using TrackLocationMVC.Services.Features.LocationFeature;

namespace TrackLocationMVC.Services.Features.UserFeature;

public class UserDetailsDto
{
    public string Name { get; set; } = string.Empty;
    public LocationDto? Location { get; set; }
}