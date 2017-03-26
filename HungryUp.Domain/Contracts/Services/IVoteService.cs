using HungryUp.Domain.Model;
using System;

namespace HungryUp.Domain.Contracts.Services
{
    public interface IVoteService : IDisposable
    {
        Vote GetTodayVote(string email);
        Vote RegisterVote(string email, long restaurantId);
    }
}
