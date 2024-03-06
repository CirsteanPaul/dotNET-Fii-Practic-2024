using TrackLocationMVC.Api.Models.LocationModels;

namespace TrackLocationMVC.Api.Models.UserModels;


public sealed class UserDetails
{
    public string Name { get; set; }
    public LocationResponse Location { get; set; }
}