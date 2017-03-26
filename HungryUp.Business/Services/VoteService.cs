using GameEndpoints.Common.Validations;
using HungryUp.Common.Resources;
using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Contracts.Services;
using HungryUp.Domain.Model;
using System;

namespace HungryUp.Business.Services
{
    public class VoteService : IVoteService
    {
        IVoteRepository _repository;
        IUserService _userService;
        IRestaurantService _restaurantService;
        public VoteService(IVoteRepository repository, IUserService userService, IRestaurantService restaurantService)
        {
            this._repository = repository;
            this._userService = userService;
            this._restaurantService = restaurantService;
        }

        public Vote GetTodayVote(string email)
        {
            User user = _userService.GetByEmail(email);
            AssertionConcern.AssertArgumentNotNull(user, ErrorMessages.UserNotFound);
            return _repository.GetVote(DateTime.Now, user);
        }

        public Vote RegisterVote(string email, long restaurantId)
        {
            User user = _userService.GetByEmail(email);
            
            Restaurant restaurant = _restaurantService.GetById(restaurantId);
            
            Vote vote = new Vote(user, restaurant);

            vote.Validate();

            return _repository.RegisterVote(vote);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
