using TrackLocationMVC.Data.Entities;

namespace TrackLocationMVC.Api.Models.FollowModels;

public sealed class FollowModel
{
    public int Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowedId { get; set; }
    public bool IsAccepted { get; set; }
    public DateTime CreatedAt { get; set; }
}