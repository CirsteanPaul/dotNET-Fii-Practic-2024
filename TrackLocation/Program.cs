using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TrackLocation;
using TrackLocation.Response;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Database>(options =>
    options.UseSqlServer(
        "Server=localhost,8082;Database=track-location;User Id=SA;Password=Hash1234/;MultipleActiveResultSets=true;TrustServerCertificate=true"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/api/identity", (string? name, string? password, Database dbContext) =>
{
    const string loginFailed = "Username or password incorrect";
    if (name is null || password is null)
    {
        return Results.BadRequest(loginFailed);
    }

    var user = dbContext.Users.FirstOrDefault(x => x.Name == name);

    if (user is null)
    {
        return Results.BadRequest(loginFailed);
    }

    if (user.Password != password)
    {
        return Results.BadRequest(loginFailed);
    }

    return Results.Ok($"Secret code {user.Id}");
});

app.MapPost("/api/register", (string? name, string? password, Database dbContext) =>
{
    if (name is null || password is null)
    {
        return Results.BadRequest("Name or password field is not valid");
    }

    var isUsernameUsed = dbContext.Users.Any(x => x.Name == name);

    if (isUsernameUsed)
    {
        return Results.BadRequest("Username already used.");
    }

    var user = new User()
    {
        Name = name,
        Password = password,
        CreatedAt = DateTime.UtcNow
    };
    
    dbContext.Users.Add(user);
    dbContext.SaveChanges();
    
    return Results.Created();
});

app.MapPut("/api/user/password", (string? code, string? newPassword, Database dBContext) =>
{
    if (code is null || !code.StartsWith("Secret code "))
    {
        return Results.Unauthorized();
    }

    if (string.IsNullOrWhiteSpace(newPassword))
    {
        return Results.BadRequest("New password is invalid");
    }

    var userIdString = code.Split(" ").Last();
    if (!int.TryParse(userIdString, out var userId))
    {
        return Results.Unauthorized();
    }
    
    var user = dBContext.Users.FirstOrDefault(x => x.Id == userId);

    if (user is null)
    {
        return Results.NotFound();
    }

    user.Password = newPassword;

    dBContext.Users.Update(user);
    dBContext.SaveChanges();

    return Results.Ok();
});

app.MapGet("/api/user/friend-details", (string? code,[Required] int friendId, Database dbContext) =>
{
    if (code is null || !code.StartsWith("Secret code "))
    {
        return Results.Unauthorized();
    }
    
    var userIdString = code.Split(" ").Last();
    if (!int.TryParse(userIdString, out var userId))
    {
        return Results.Unauthorized();
    }
    var friendship = dbContext.Follows.Any(x => x.FollowerId == userId && x.FollowedId == friendId && x.IsAccepted == true);

    if (!friendship)
    {
        return Results.BadRequest("There is no relationship between you");
    }

    var friend = dbContext.Users.Include(u => u.Locations).FirstOrDefault(x => x.Id == friendId)!;
    var friendLocation = friend.Locations.OrderBy(x => x.CreatedAt).LastOrDefault();
    if (friendLocation is null)
    {
        return Results.Ok(new FriendDetailsResponse()
        {
            Name = friend.Name,
            Location = null,
        });
    }
    return Results.Ok(new FriendDetailsResponse()
    {
        Name = friend.Name,
        Location = new LocationResponse()
        {
            Latitude = friendLocation.Latitude,
            Longitude = friendLocation.Longitude,
            CreatedAt = friendLocation.CreatedAt
        }
    });
});

app.MapPost("/api/follows/new-follower", (string? code, int followedId, Database dbContext) =>
{
    if (code is null || !code.StartsWith("Secret code "))
    {
        return Results.Unauthorized();
    }
    
    var userIdString = code.Split(" ").Last();
    if (!int.TryParse(userIdString, out var userId))
    {
        return Results.Unauthorized();
    }
    var friendship = dbContext.Follows.Any(x => x.FollowerId == userId && x.FollowedId == followedId);

    if (friendship)
    {
        return Results.BadRequest("There is a relation between to already");
    }

    var newFriendship = new Follow()
    {
        FollowerId = userId,
        FollowedId = followedId,
        IsAccepted = false,
        CreatedAt = DateTime.UtcNow
    };

    dbContext.Follows.Add(newFriendship);
    dbContext.SaveChanges();

    return Results.Ok();
});

app.MapPost("/api/follows/accept", (string? code, int id, Database dbContext) =>
{
    if (code is null || !code.StartsWith("Secret code "))
    {
        return Results.Unauthorized();
    }
    
    var userIdString = code.Split(" ").Last();
    if (!int.TryParse(userIdString, out var userId))
    {
        return Results.Unauthorized();
    }
    var friendship = dbContext.Follows.FirstOrDefault(x => x.Id == id);

    if (friendship is null)
    {
        return Results.NotFound();
    }

    if (friendship.FollowedId != userId)
    {
        return Results.Unauthorized();
    }

    friendship.IsAccepted = true;
    dbContext.Follows.Update(friendship);
    
    dbContext.SaveChanges();
    return Results.Ok();
});

app.MapGet("/api/follows-count", (string? code, Database dbContext) =>
{
    if (code is null || !code.StartsWith("Secret code "))
    {
        return Results.Unauthorized();
    }

    var userIdString = code.Split(" ").Last();
    if (!int.TryParse(userIdString, out var userId))
    {
        return Results.Unauthorized();
    }

    var follows = dbContext.Follows.Count(x => x.FollowedId == userId);

    return Results.Ok(follows);
});

app.MapGet("/api/follows", (string? code, int page, Database dbContext) =>
{
    if (code is null || !code.StartsWith("Secret code "))
    {
        return Results.Unauthorized();
    }

    var userIdString = code.Split(" ").Last();
    if (!int.TryParse(userIdString, out var userId))
    {
        return Results.Unauthorized();
    }

    var follows = dbContext.Follows
        .Where(x => x.FollowedId == userId)
        .OrderBy(x => x.CreatedAt)
        .Skip((page - 1) * 10)
        .Take(10)
        .ToList();

    return Results.Ok(follows);
});

app.MapPost("/api/location", (string? code, double longitude, double latitude, Database dbContext) =>
{
    if (code is null || !code.StartsWith("Secret code "))
    {
        return Results.Unauthorized();
    }

    var userIdString = code.Split(" ").Last();
    if (!int.TryParse(userIdString, out var userId))
    {
        return Results.Unauthorized();
    }

    var newLocation = new Location()
    {
        Latitude = latitude,
        Longitude = longitude,
        UserId = userId,
        CreatedAt = DateTime.UtcNow
    };

    dbContext.Locations.Add(newLocation);
    dbContext.SaveChanges();

    return Results.Created();
});
app.UseHttpsRedirection();
app.UseRouting();


app.Run();