using System.ComponentModel.DataAnnotations;

namespace TrackLocationMVC.Api.Models.UserModels;

public class ChangePasswordRequest
{
    [Required]
    [MinLength(4)]
    public string NewPassword { get; set; }  
}