using HungryUp.Common.Extensions;
using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Contracts.Services;
using HungryUp.Domain.Model;
using System;
using System.Collections.Generic;

namespace HungryUp.Business.Services
{
    public class RestaurantService : IRestaurantService
    {
        IRestaurantRepository _repository;

        public RestaurantService(IRestaurantRepository repository)
        {
            this._repository = repository;
        }

        public IList<Restaurant> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<Restaurant> GetWeekAvaiable()
        {
            DateTime startWeek = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
            DateTime endWeek = startWeek.AddDays((int)DayOfWeek.Saturday);
            return _repository.GetWeekAvaiable(startWeek, endWeek);
        }
        
        public Restaurant GetById(long restaurantId)
        {
            return _repository.GetById(restaurantId);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
