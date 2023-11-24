﻿using Restaurant.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Menu : ModelBase, IEntity
    {
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public string Name { get; set; }

        public List<Dish> Dishes { get; set; }

        public List<Drink> Drinks { get; set; }
    }
}
