using Microsoft.AspNetCore.Mvc;
using TrackLocationMVC.Api.Mappers;
using TrackLocationMVC.Api.Models.LocationModels;
using TrackLocationMVC.Services.Features.LocationFeature;

namespace TrackLocationMVC.Api.Controllers;

// We specify the path for our controller. So all methods in .NET must be assigned to a different HTTP link.
// In this case we say that all methods in this class will have at least http://localhost/api/location.
[Route("api/location")]
// As you can see we inherit from AuthController, because we need the secret code.
public class LocationController : AuthController
{
    // We inject the location service for our business logic.
    private readonly ILocationService _locationService;

    // As I mentioned this ILocationService from the constructor comes directly from the DependencyInjection container.
    // More details: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection. If you want to understand more it's the best link.
    // We just need to populate a property for further use.
    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    // We say that this method will be POST. Because the route is already at least http://localhost/api/location we will have the route
    // POST http://localhost/api/location
    [HttpPost]
    // By default .NET will take the parameters provided by you and but them as needed for the request maker.
    // In this case the simple types like int,double, string... will be automatically added as Query params.
    // The custom objects created by you will be added as body params.
    public ActionResult SendLocation(string code, LocationModel model)
    {
        // We use validate user from AuthController.
        ValidateUser();
        
        // We call the logic to with the data provided.
        // In this case the logic will not have any return type.
        // For more details about model.ToDto(UserId) enter in Api/Mappers/LocationMapper.
        _locationService.SendLocation(model.ToDto(UserId));

        // If everything worked we return 201.
        // This flow works as expected because if something goes wrong we throw an exception.
        return Created();
    }
}