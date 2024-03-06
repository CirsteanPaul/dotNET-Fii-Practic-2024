using Microsoft.AspNetCore.Mvc;
using TrackLocationMVC.Api.Mappers;
using TrackLocationMVC.Api.Models.LocationModels;
using TrackLocationMVC.Services.Features.LocationFeature;

namespace TrackLocationMVC.Api.Controllers;

[Route("api/location")]
public class LocationController : AuthController
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpPost]
    public ActionResult SendLocation(string code, LocationModel model)
    {
        ValidateUser();
        
        _locationService.SendLocation(model.ToDto(UserId));

        return Created();
    }
}