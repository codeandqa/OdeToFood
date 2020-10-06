using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Web.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant restaurant);

        void Update(Restaurant restaurant);
      
    }
}
