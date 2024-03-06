namespace TrackLocationMVC.Api.Models.FollowModels;

public class FollowResponse
{
    public IEnumerable<FollowModel> Items { get; set; }
    public int Page { get; set; }
}