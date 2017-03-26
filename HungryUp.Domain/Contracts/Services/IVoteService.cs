using HungryUp.Domain.Model;
using System;
using System.Collections.Generic;

namespace HungryUp.Domain.Contracts.Services
{
    public interface IVoteService : IDisposable
    {
        Vote GetTodayVote(string email);
        IList<Vote> GetAllTodayVotes();
        IList<ScoreBoard> GetAllTodayVotesGroupByRestaurant();
        Vote RegisterVote(string email, long restaurantId);
    }
}
