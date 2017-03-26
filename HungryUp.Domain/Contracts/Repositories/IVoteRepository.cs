using HungryUp.Domain.Model;
using System;

namespace HungryUp.Domain.Contracts.Repositories
{
    public interface IVoteRepository : IDisposable
    {
        Vote GetVote(DateTime date, User user);
        Vote RegisterVote(Vote vote);
    }
}
