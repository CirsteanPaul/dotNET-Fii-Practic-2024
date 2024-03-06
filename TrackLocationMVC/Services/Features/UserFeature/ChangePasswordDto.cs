namespace TrackLocationMVC.Services.Features.UserFeature;

public class ChangePasswordDto
{
    public int UserId { get; set; }
    public string NewPassword { get; set; } = string.Empty;
}