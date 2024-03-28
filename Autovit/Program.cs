using Data;
using Microsoft.EntityFrameworkCore;
using Services.Features.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddDbContext<AppDbContext>(
    o => o.UseInMemoryDatabase("data"));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Routes controller to specific HTTP link.
app.UseRouting();

// We use the controllers which were added at line 27.
app.MapControllers();

app.Run();

