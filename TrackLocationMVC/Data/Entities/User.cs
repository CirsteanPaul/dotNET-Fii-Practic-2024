namespace TrackLocationMVC.Data.Entities;

public sealed class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public IEnumerable<Location> Locations { get; set; }
}