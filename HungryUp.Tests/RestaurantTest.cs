﻿using HungryUp.Business.Services;
using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Contracts.Services;
using HungryUp.Domain.Model;
using HungryUp.Infrastructure.Data;
using HungryUp.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HungryUp.Tests
{
    [TestClass]
    public class RestaurantTest
    {
        private IRestaurantService _service;

        [TestInitialize]
        public void InitializeTests()
        {
            AppDataContext _context = new AppDataContext();
            IRestaurantRepository _repository = new RestaurantRepository(_context);
            _service = new RestaurantService(_repository);
        }

        [TestCleanup]
        public void CleanDatabaseResources()
        {
            _service.Dispose();
        }

        [TestMethod]
        public void GetAllRestaurants()
        {
            IList<Restaurant> restaurants = _service.GetAll();
            Assert.IsTrue(restaurants.Any());
        }

        [TestMethod]
        public void GetRestaurantsAvaiableOnTheCurrentWeek()
        {
            IList<Restaurant> restaurants = _service.GetWeekAvaiable();
            Assert.IsTrue(restaurants.Any());
        }

        [TestMethod]
        public void GetRestaurantById()
        {
            try
            {
                IList<Restaurant> restaurants = _service.GetAll();
                Assert.IsTrue(restaurants.Any());
                Restaurant restaurant = _service.GetById(restaurants.FirstOrDefault().RestaurantId);
                Assert.IsNotNull(restaurant);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
