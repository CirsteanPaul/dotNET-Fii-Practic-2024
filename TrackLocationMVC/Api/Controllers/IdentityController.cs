using Microsoft.AspNetCore.Mvc;
using TrackLocationMVC.Services.Features.IdentityFeature;

namespace TrackLocationMVC.Api.Controllers;

[Route("api/identity")]
[ApiController]
public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost]
    public ActionResult<string> Login(string name, string password)
    {
        return Ok(_identityService.Login(new IdentityDto()
        {
            Username = name,
            Password = password
        }));

    }
    
    [HttpPost("register")]
    public ActionResult Register(string name, string password)
    {
        _identityService.Register(new IdentityDto()
        {
            Username = name,
            Password = password
        });
        return Created();
    }
}