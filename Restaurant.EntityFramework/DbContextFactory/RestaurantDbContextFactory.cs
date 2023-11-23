﻿using Microsoft.Extensions.Configuration;
using Restaurant.EntityFramework.Contexts;

namespace Restaurant.EntityFramework.DbContextFactory;

public class RestaurantDbContextFactory : IDbContextFactory
{
    private IConfiguration _configuration;

    public RestaurantDbContextFactory(IConfiguration config)
    {
        _configuration = config;
    }

    public ApplicationDbContext GetDbContext()
    {
        return new ApplicationDbContext(_configuration);
    }
}