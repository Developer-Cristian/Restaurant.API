using Restaurant.EntityFramework;
using Restaurant.EntityFramework.Repositories.ReadRepos;
using Restaurant.EntityFramework.Repositories.SaveRepos;
using Restaurant.Repositories.ReadRepos;
using Restaurant.Repositories.SaveRepos;
using Restaurant.Services.ReadService;
using Restaurant.Services.ReadServices.Impl;
using Restaurant.Services.SaveService;
using Restaurant.Services.SaveServices.Impl;
using Team.Lunch.Core.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbContextFactory, RestaurantDbContextFactory>();

// Add services
builder.Services.AddScoped<IReadDishService, ReadDishService>();
builder.Services.AddScoped<ISaveDishService, SaveDishService>();

builder.Services.AddScoped<IReadDrinkService, ReadDrinkService>();
builder.Services.AddScoped<ISaveDrinkService, SaveDrinkService>();

builder.Services.AddScoped<IReadMenuService, ReadMenuService>();
builder.Services.AddScoped<ISaveMenuService, SaveMenuService>();

// Add repository
builder.Services.AddScoped<IReadDishRepository, ReadDishRepository>();
builder.Services.AddScoped<ISaveDishRepository, SaveDishRepository>();

builder.Services.AddScoped<IReadDrinkRepository, ReadDrinkRepository>();
builder.Services.AddScoped<ISaveDrinkRepository, SaveDrinkRepository>();

builder.Services.AddScoped<IReadMenuRepository, ReadMenuRepository>();
builder.Services.AddScoped<ISaveMenuRepository, SaveMenuRepository>();



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
