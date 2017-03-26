using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Model;
using HungryUp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HungryUp.Infrastructure.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        AppDataContext _context;
        public RestaurantRepository(AppDataContext context)
        {
            this._context = context;
        }

        public IList<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public IList<Restaurant> GetWeekAvaiable(DateTime startWeek, DateTime endWeek)
        {
            IQueryable query = _context.Restaurants.
                Where(s => !_context.ChoiceHistories.
                    Where(x => x.Date >= startWeek && x.Date <= endWeek && x.Restaurant.RestaurantId == s.RestaurantId).Any());

            var queryString = query.ToString();

            return _context.Restaurants.
                Where(s => !_context.ChoiceHistories.
                    Where(x => x.Date >= startWeek && x.Date <= endWeek && x.Restaurant.RestaurantId == s.RestaurantId).Any()).ToList();
        }
        
        public Restaurant GetById(long restaurantId)
        {
            return _context.Restaurants.Where(x => x.RestaurantId == restaurantId).FirstOrDefault();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
