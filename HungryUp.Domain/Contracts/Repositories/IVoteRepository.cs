using HungryUp.Domain.Model;
using System;
using System.Collections.Generic;

namespace HungryUp.Domain.Contracts.Repositories
{
    public interface IVoteRepository : IDisposable
    {
        Vote GetVote(DateTime date, User user);
        IList<Vote> GetAllVotesByDate(DateTime date);
        Vote RegisterVote(Vote vote);
    }
}
