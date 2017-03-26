using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Model;
using HungryUp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HungryUp.Infrastructure.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        AppDataContext _context;

        public VoteRepository(AppDataContext context)
        {
            this._context = context;
        }

        public Vote GetVote(DateTime date, User user)
        {
            var query = _context.Votes.Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(date) && x.User.UserId == user.UserId);
            var querstring = query.ToString();
            return _context.Votes
                .Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(date) && x.User.UserId == user.UserId)
                .Include(x => x.Restaurant)
                .FirstOrDefault();
        }
        
        public Vote RegisterVote(Vote vote)
        {
            _context.Votes.Add(vote);
            _context.SaveChanges();
            return vote;
        }

        public IList<Vote> GetAllVotesByDate(DateTime date)
        {
            return _context.Votes.Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(date))
                .Include(x => x.User)
                .Include(x => x.Restaurant)
                .ToList();
        }

        public IList<ScoreBoard> GetAllVotesByDateGroupByRestaurant(DateTime date)
        {
            return _context.Votes.Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(date))
                .Include(x => x.Restaurant)
                .GroupBy(x => x.Restaurant.Name)
                .Select(g => new ScoreBoard { Restaurant = g.Key, Votes = g.Count() }).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
