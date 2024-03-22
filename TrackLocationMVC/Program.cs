using Microsoft.EntityFrameworkCore;
using TrackLocationMVC.Data.Repositories;
using TrackLocationMVC.Services.Features.FollowFeature;
using TrackLocationMVC.Services.Features.IdentityFeature;
using TrackLocationMVC.Services.Features.LocationFeature;
using TrackLocationMVC.Services.Features.UserFeature;

var builder = WebApplication.CreateBuilder(args); // we create a instance for our .NET application

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services is a list of all of the services our apllication will use.
// We will add DbContext(so a instance of our database). We specify it will be of class AppDbContext and add the connection string option.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
        "Server=localhost,8082;Database=track-location;User Id=SA;Password=Hash1234/;MultipleActiveResultSets=true;TrustServerCertificate=true"));
// The next 2 lines will add the SwaggerUi to our application.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// We will talk about this one later.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
});
// .NET adds all the classes which ends with suffix Controller.
builder.Services.AddControllers();
// We need to add by hand our services and give them the proper lifetime. In this case "Scoped" -> the instance will live per HTTP requests.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IFollowService, FollowService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFollowRepository, FollowRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

// We create our WebApplication so the building step is over.
var app = builder.Build();
// app is a variable bounded with the runtime-compilation. That being said
// we need to specify what our app will use.
// This step is necessary because maybe our app will behave different in a production environment compared to a dev env. 

// Configure the HTTP request pipeline.
// In this case we say that we want swagger only in development env.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// We redirect HTTP requests to HTTPS for security concerns.
app.UseHttpsRedirection();

// Routes controller to specific HTTP link.
app.UseRouting();

// We use the controllers which were added at line 27.
app.MapControllers();

// We start the app.
app.Run();