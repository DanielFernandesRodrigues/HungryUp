using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Model;
using HungryUp.Infrastructure.Data;
using System;
using System.Collections.Generic;
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

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
