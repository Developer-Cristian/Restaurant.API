﻿using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Dish : ModelBase
    {
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "DescriptionRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "DishTypeRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public DishType Type { get; set; }

        [Required(ErrorMessageResourceName = "PriceTypeRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        [Range(0.01, double.MaxValue, ErrorMessageResourceName = "PriceNotValid", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public decimal Price { get; set; }

        [Range(1, 5, ErrorMessageResourceName = "StarsNumberNotValid", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public int Star { get; set; }
    }
}