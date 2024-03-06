namespace TrackLocation;

public sealed class Location
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public User User { get; set; }
}