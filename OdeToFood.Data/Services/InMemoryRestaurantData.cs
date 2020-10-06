using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData: IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Fredo", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Dal", Cuisine = CuisineType.Indian},
                new Restaurant { Id = 3, Name = "Bread", Cuisine = CuisineType.French}
            };
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        
    }
}
