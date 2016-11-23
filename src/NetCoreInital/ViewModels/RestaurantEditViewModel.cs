using NetCoreInital.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreInital.ViewModels
{
    public class RestaurantEditViewModel
    {
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
