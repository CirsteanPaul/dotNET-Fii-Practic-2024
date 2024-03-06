using Microsoft.EntityFrameworkCore;
using RepositoryPattern;
using RepositoryPattern.Database.UnitOfWork;
using RepositoryPattern.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer("Server=localhost,8082;Database=track-location;User Id=SA;Password=Hash1234/;MultipleActiveResultSets=true;TrustServerCertificate=true"));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", (IUserRepository repository) =>
    {
        var user = repository.GetById(1);

        return user;
    })
    .WithOpenApi();
app.MapPost("/", (string name, IUserRepository repository, IUnitOfWork unitOfWork) =>
    {
        repository.Add(new User() { Name = "paul", Password = "abc"});
        
        unitOfWork.SaveChanges();
        
        return Results.Ok();
    })
    .WithOpenApi();

app.Run();

