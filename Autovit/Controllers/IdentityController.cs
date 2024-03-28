using Microsoft.AspNetCore.Mvc;
using Services.Features.Identity;

namespace Autovit.Controllers;

[ApiController]
[Route("api/identity")]
public sealed class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        var token = _identityService.Login(username, password);

        return Ok(token);
    }
    
    [HttpPost("register")]
    public ActionResult Register(string username, string password, string email)
    {
        _identityService.Register(username, password, email);

        return Ok();
    }
}