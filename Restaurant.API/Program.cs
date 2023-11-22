using Restaurant.EntityFramework;
using Restaurant.Repositories.SaveRepos;
using Restaurant.Services.ReadService;
using Restaurant.Services.ReadServices.Impl;
using Restaurant.Services.SaveServices;
using Team.Lunch.Core.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbContextFactory, RestaurantDbContextFactory>();

builder.Services.AddScoped<IReadDishService, ReadDishService>();

// add services and repos
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
