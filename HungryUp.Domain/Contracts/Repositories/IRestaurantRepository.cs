using HungryUp.Domain.Model;
using System;
using System.Collections.Generic;

namespace HungryUp.Domain.Contracts.Repositories
{
    public interface IRestaurantRepository : IDisposable
    {
        IList<Restaurant> GetAll();
        IList<Restaurant> GetWeekAvaiable(DateTime startWeek, DateTime endWeek);
        Restaurant GetById(long restaurantId);
    }
}
