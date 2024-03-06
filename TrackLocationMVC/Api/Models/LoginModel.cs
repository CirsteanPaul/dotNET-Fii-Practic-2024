using System.ComponentModel.DataAnnotations;

namespace TrackLocationMVC.Api.Models;

public sealed class LoginModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}