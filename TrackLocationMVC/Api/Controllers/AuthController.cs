using Microsoft.AspNetCore.Mvc;
using TrackLocationMVC.Services.Exceptions;

namespace TrackLocationMVC.Api.Controllers;

// All controllers are derived from ControllerBase. 
// By doing so we have access to all .NET functionalities to talk on HTTP.

// This is called a decorator. We specify that this route is an API controller. 
// .NET supports controllers which returns html, xml and many other formats.
// By using this decorator we tell him that we will use only JSON.


// This class will be the base class for our controllers. This class will just validate if the user is logged in or not.
[ApiController]
public class AuthController : ControllerBase
{
    // We have a PROTECTED variable which will be populated when we check the secret code. The user id will be stored in this variable.
    protected int UserId { get; private set; }

    protected void ValidateUser()
    {
        // All Http interaction are done via HttpContext.
        // This is a huge object which represents everything about the request which came to the server.
        if (HttpContext is null || HttpContext.User is null)
        {
            // IF for some reason this is null we throw and AuthorizationException.
            // For now this error will break our app, but we will handle these exceptions later.
            // This class can be found in Services/Exceptions
            throw new AuthorizationException();
        }

        // We take the query paramas
        var currentUser = HttpContext.Request.Query;
        // We try to find a variable called "code"
        if (!currentUser.TryGetValue("code", out var values))
        {
            // we we didn't found one we break the program.
            // That means the request is not authenticated whatsoever.
            throw new AuthorizationException();
        }
        
        // If the code was found we will have it in the variable values. Careful values is of type StringValues.
        // So we will make it a string.
        // An example for a secret code is: Secret code 1. For example this will be the secret code of user with id 1.
        var code = values.ToString();
        if (!code.StartsWith("Secret code "))
        {
            // we verify that the code starts with Secret code and if not we throw the exception
            throw new AuthorizationException();
        }
        
        // We split the spaces and take the last one. The last one should be an int (1,2,3,4...)
        var userIdString = code.Split(" ").Last();
        if (!int.TryParse(userIdString, out var userId))
        {
            // We try to parse it into a int. If something goes wrong throw.
            throw new AuthorizationException();
        }
        // Finally if we are here that means the secret code is correct and we just assign the id to our property for further use.
        UserId = userId;
    }
}