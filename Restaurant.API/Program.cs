using Restaurant.Services.ReadService;
using Restaurant.Services.ReadServices.Impl;
using Restaurant.Repositories.ReadRepos;
using Restaurant.EntityFramework.Repositories.ReadRepos;
using Restaurant.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Restaurant.API;
using Restaurant.Services.SaveService;
using Restaurant.Services.SaveServices.Impl;
using Restaurant.Repositories.SaveRepos;
using Restaurant.EntityFramework.Repositories.SaveRepos;
using Restaurant.API.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var config = builder.Configuration.AddUserSecrets<string>().Build(); 
var dbSettings = config.GetSection("database").Get<DbConfig>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add db context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(dbSettings.ConnectionString));

#region Service

// Read

builder.Services.AddScoped<IReadDishService, ReadDishService>();
builder.Services.AddScoped<IReadDrinkService, ReadDrinkService>();
builder.Services.AddScoped<IReadMenuService, ReadMenuService>();

// Save

builder.Services.AddScoped<ISaveDishService, SaveDishService>();
builder.Services.AddScoped<ISaveDrinkService, SaveDrinkService>();
builder.Services.AddScoped<ISaveMenuService, SaveMenuService>();

#endregion

#region Repos

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(config.GetSection("database").Get<DbConfig>().ConnectionString,
        // migrations will be created in the EntityFramework project
        x => x.MigrationsAssembly(System.Reflection.Assembly.GetAssembly(typeof(ApplicationDbContext)).GetName().Name));
}, contextLifetime: ServiceLifetime.Scoped);

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
{
    options.UseSqlServer(config.GetSection("database").Get<DbConfig>().ConnectionString,
        // migrations will be created in the EntityFramework project
        x => x.MigrationsAssembly(System.Reflection.Assembly.GetAssembly(typeof(ApplicationDbContext)).GetName().Name));
}, ServiceLifetime.Scoped);

// Read

builder.Services.AddScoped<IReadDishRepository, ReadDishRepository>();
builder.Services.AddScoped<IReadDrinkRepository, ReadDrinkRepository>();
builder.Services.AddScoped<IReadMenuRepository, ReadMenuRepository>();

// Save

builder.Services.AddScoped<ISaveDishRepository, SaveDishRepository>();
builder.Services.AddScoped<ISaveDrinkRepository, SaveDrinkRepository>();
builder.Services.AddScoped<ISaveMenuRepository, SaveMenuRepository>();

#endregion

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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