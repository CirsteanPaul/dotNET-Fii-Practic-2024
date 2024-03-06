namespace TrackLocationMVC.Data.Entities;

public class Follow
{
    public int Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowedId { get; set; }
    public bool IsAccepted { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public User Follower { get; set; }
    public User Followed { get; set; }
}