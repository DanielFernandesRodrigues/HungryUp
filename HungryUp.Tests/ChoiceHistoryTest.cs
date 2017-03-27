using HungryUp.Business.Services;
using HungryUp.Common.Extensions;
using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Contracts.Services;
using HungryUp.Domain.Model;
using HungryUp.Infrastructure.Data;
using HungryUp.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HungryUp.Tests
{
    [TestClass]
    public class ChoiceHistoryTest
    {
        IChoiceHistoryService _service;

        [TestInitialize]
        public void InitializeTests()
        {
            AppDataContext _context = new AppDataContext();
            IChoiceHistoryRepository _repository = new ChoiceHistoryRepository(_context);
            IVoteRepository _voteRepository = new VoteRepository(_context);
            IRestaurantRepository _restaurantRepository = new RestaurantRepository(_context);
            _service = new ChoiceHistoryService(_repository, _voteRepository, _restaurantRepository);
        }

        [TestCleanup]
        public void CleanDatabaseResources()
        {
            _service.Dispose();
        }

        [TestMethod]
        public void GetHistoryFromCurrentWeek()
        {            
            IList<ChoiceHistory> choiceHistory = _service.GetFromCurrentWeek();
        }

        [TestMethod]
        public void TodaySessionIsOpen()
        {
            ChoiceHistory choiceHistory = _service.GetTodayChoiceHistory();
        }
        
        [TestMethod]
        public void RegisterChoiceHistory()
        {
            ChoiceHistory choiceHistory = _service.RegisterChoiceHistory();
        }

        [TestMethod]
        public void ClearChoiceHistoryVotesDay()
        {
            _service.CleanChoiceHistoryVotesDay();
        }
    }
}
