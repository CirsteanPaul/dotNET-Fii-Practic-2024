namespace TrackLocationMVC.Api.Models.LocationModels;

public sealed class LocationResponse{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public DateTime CreatedAt { get; set; }
}
