using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackLocationMVC.Services.Exceptions;

namespace TrackLocationMVC.Api.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    protected int UserId { get; private set; }

    protected void ValidateUser()
    {
        if (HttpContext is null || HttpContext.User is null)
        {
            throw new AuthorizationException();
        }

        var currentUser = HttpContext.Request.Query;
        if (!currentUser.TryGetValue("code", out var values))
        {
            throw new AuthorizationException();
        }

        var code = values.ToString();

        if (!code.StartsWith("Secret code "))
        {
            throw new AuthorizationException();
        }

        var userIdString = code.Split(" ").Last();
        if (!int.TryParse(userIdString, out var userId))
        {
            throw new AuthorizationException();
        }

        UserId = userId;
    }
}