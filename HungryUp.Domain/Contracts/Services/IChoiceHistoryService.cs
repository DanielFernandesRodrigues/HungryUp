using HungryUp.Domain.Model;
using System;
using System.Collections.Generic;

namespace HungryUp.Domain.Contracts.Services
{
    public interface IChoiceHistoryService : IDisposable
    {
        ChoiceHistory GetTodayChoiceHistory();
        IList<ChoiceHistory> GetFromCurrentWeek();
    }
}
