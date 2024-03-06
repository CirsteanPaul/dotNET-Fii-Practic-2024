namespace TrackLocation.Response;

public sealed class LocationResponse{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public DateTime CreatedAt { get; set; }
}
public sealed class FriendDetailsResponse
{
    public string Name { get; set; }
    public LocationResponse Location { get; set; }
}