using TrackLocationMVC.Data.Entities;

namespace TrackLocationMVC.Services.Features.FollowFeature;

public class FollowDto
{
    public int Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowedId { get; set; }
    public bool IsAccepted { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public User Follower { get; set; }
    public User Followed { get; set; }
}