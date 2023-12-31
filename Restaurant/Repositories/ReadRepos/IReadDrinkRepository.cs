﻿using Restaurant.Models;

namespace Restaurant.Repositories.ReadRepos
{
    public interface IReadDrinkRepository : IReadGenericRepositoty<Drink>
    {
        Task<Drink> GetDrinkByNameAndMenuAsync(string name, Guid? menuId);
    }
}
