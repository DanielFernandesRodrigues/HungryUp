using HungryUp.Domain.Model;
using System;
using System.Collections.Generic;

namespace HungryUp.Domain.Contracts.Services
{
    public interface IRestaurantService : IDisposable
    {
        IList<Restaurant> GetAll();
        IList<Restaurant> GetWeekAvaiable();
    }
}
