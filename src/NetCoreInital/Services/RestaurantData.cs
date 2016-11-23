using NetCoreInital.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreInital.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant restaurant);
        void Commit();
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private NetCoreInitialDbContext _context;

        public SqlRestaurantData(NetCoreInitialDbContext context)
        {
            _context = context;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);

            return restaurant;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants;
        }
    }
}
