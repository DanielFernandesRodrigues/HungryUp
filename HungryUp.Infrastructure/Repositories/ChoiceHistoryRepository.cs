using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Model;
using HungryUp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HungryUp.Infrastructure.Repositories
{
    public class ChoiceHistoryRepository : IChoiceHistoryRepository
    {
        AppDataContext _context;

        public ChoiceHistoryRepository(AppDataContext context)
        {
            this._context = context;
        }

        public IList<ChoiceHistory> GetFromCurrentWeek(DateTime startWeek, DateTime endWeek)
        {
            return _context.ChoiceHistories.Where(x => x.Date >= startWeek && x.Date <= endWeek).ToList();
        }

        public ChoiceHistory GetFromDate(DateTime date)
        {
            return _context.ChoiceHistories
                .Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(date))
                .Include(x => x.Restaurant)
                .FirstOrDefault();
        }

        public ChoiceHistory Add(ChoiceHistory choiceHistory)
        {
            _context.ChoiceHistories.Add(choiceHistory);
            _context.SaveChanges();
            return choiceHistory;
        }

        public void CleanChoiceDay()
        {
            var choice = _context.ChoiceHistories.Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(DateTime.Now)).FirstOrDefault();
            if (choice != null)
                _context.ChoiceHistories.Remove(choice);
            var votes = _context.Votes.Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(DateTime.Now)).ToList();
            if (votes != null && votes.Count() > 0)
                _context.Votes.RemoveRange(votes);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
