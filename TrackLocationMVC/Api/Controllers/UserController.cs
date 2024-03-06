using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TrackLocationMVC.Api.Mappers;
using TrackLocationMVC.Api.Models.UserModels;
using TrackLocationMVC.Services.Features.UserFeature;

namespace TrackLocationMVC.Api.Controllers;

[Route("/api/user")]
public class UserController : AuthController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPut("password")]
    public ActionResult ChangePassword(string code, ChangePasswordRequest request)
    {
        ValidateUser();
        
        _userService.ChangePassword(request.ToDto(UserId));
        
        return Ok();
    }
    
    [HttpGet("friend-details")]
    public ActionResult<UserDetails> GetFriendDetails(string? code, [Required] int friendId)
    {
        ValidateUser();

        var details = _userService.GetFriendDetails(friendId, UserId);
        return Ok(details.ToModel());
    }
}