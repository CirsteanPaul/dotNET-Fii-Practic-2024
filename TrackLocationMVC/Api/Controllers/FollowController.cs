using Microsoft.AspNetCore.Mvc;
using TrackLocationMVC.Api.Mappers;
using TrackLocationMVC.Api.Models.FollowModels;
using TrackLocationMVC.Services.Features.FollowFeature;

namespace TrackLocationMVC.Api.Controllers;

// For each detail explained of the class look in LocationController.
// Jump at line 37 for some explanations.
[Route("api/follows")]
public class FollowController : AuthController
{
    private readonly IFollowService _followService;

    public FollowController(IFollowService followService)
    {
        _followService = followService;
    }

    [HttpGet]
    public ActionResult<FollowResponse> GetMyFollowers(string code, int page)
    {
        var followers = _followService.GetFollowers(page, UserId);

        return Ok(followers.Select(x => x.ToModel()));
    }
    
    [HttpGet("count")]
    public ActionResult<FollowResponse> GetMyFollowersCount(string code)
    {
        var count = _followService.GetFollowersCount(UserId);

        return Ok(count);
    }
    // So our controller route is http://localhost/api/follows
    // Because we added the "accept" in this decorator the http route will now be.
    // POST http://localhost/api/follows/accept
    [HttpPost("accept")]
    public ActionResult AcceptFollowRequest(string code, int followId)
    {
        _followService.AcceptFollow(UserId, followId);

        return Ok();
    }
}