﻿using Restaurant.Models;
using Restaurant.Repositories.SaveRepos;
using Restaurant.Services.ReadServices.Impl;
using Restaurant.Services.SaveService;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Services.SaveServices.Impl
{
    public class SaveDrinkService : ISaveDrinkService
    {
        private ISaveDrinkRepository _repository;

        public SaveDrinkService(ISaveDrinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ValidationResult>> DelateAsync(Guid? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            var errors = Array.Empty<ValidationResult>().ToList();

            await _repository.DelateAsync(id);
            return errors;
        }

        public async Task<IEnumerable<ValidationResult>> SaveAsync(Drink entity)
        {
            var errors = Array.Empty<ValidationResult>().ToList();

            if (entity.CreationDate is null) entity.CreationDate = DateTime.Now;

            if (entity.Id is null)
            {
                var existing = await _repository.GetDrinkByNameAndMenuAsync(entity.Name, entity.MenuId);
                if (existing != null)
                {
                    errors.Add(new ValidationResult(string.Format(Common.Resources.Errors.AlreadyExisting, "Drink", existing.Id), new List<string> { nameof(Dish.Id) }));
                }
            }

            if (errors.Any())
                return errors;

            return await _repository.SaveAsync(entity);
        }
    }
}
