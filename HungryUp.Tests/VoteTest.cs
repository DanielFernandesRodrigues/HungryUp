using HungryUp.Business.Services;
using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Contracts.Services;
using HungryUp.Domain.Model;
using HungryUp.Infrastructure.Data;
using HungryUp.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HungryUp.Tests
{
    [TestClass]
    public class VoteTest
    {
        private IVoteService _service;
        private string email = "dbserver_test@dbserver.com";
        private long restaurantId = 1;

        [TestInitialize]
        public void InitializeTests()
        {
            AppDataContext _context = new AppDataContext();
            IVoteRepository _repository = new VoteRepository(_context);
            IUserRepository _userRepository = new UserRepository(_context);
            IUserService _userService = new UserService(_userRepository);
            IRestaurantRepository _restaurantRepository = new RestaurantRepository(_context);
            IRestaurantService _restaurantService = new RestaurantService(_restaurantRepository);
            _service = new VoteService(_repository, _userService, _restaurantService);
        }

        [TestCleanup]
        public void CleanDatabaseResources()
        {
            _service.Dispose();
        }

        [TestMethod]
        public void RegisterVote()
        {
            Vote vote = _service.RegisterVote(email, restaurantId);
            Assert.IsNotNull(vote);
        }

        [TestMethod]
        public void VerifyIfUserAlreadyVotedToday()
        {
            try
            {
                Vote vote = _service.GetTodayVote(email);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
