namespace TrackLocationMVC.Services.Features.LocationFeature;

public class SendLocationDto
{
    public int UserId { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}