using HungryUp.Domain.Model;
using System;
using System.Collections.Generic;

namespace HungryUp.Domain.Contracts.Repositories
{
    public interface IChoiceHistoryRepository : IDisposable
    {
        IList<ChoiceHistory> GetFromCurrentWeek(DateTime startWeek, DateTime endWeek);
    }
}
