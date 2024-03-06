using Microsoft.EntityFrameworkCore;
using TrackLocationMVC.Data.Repositories;
using TrackLocationMVC.Services.Features.FollowFeature;
using TrackLocationMVC.Services.Features.IdentityFeature;
using TrackLocationMVC.Services.Features.LocationFeature;
using TrackLocationMVC.Services.Features.UserFeature;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
        "Server=localhost,8082;Database=track-location;User Id=SA;Password=Hash1234/;MultipleActiveResultSets=true;TrustServerCertificate=true"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
});
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IFollowService, FollowService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFollowRepository, FollowRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();