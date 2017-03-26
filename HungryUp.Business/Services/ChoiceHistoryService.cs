using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Contracts.Services;
using HungryUp.Domain.Model;
using HungryUp.Common.Extensions;
using System;
using System.Collections.Generic;

namespace HungryUp.Business.Services
{
    public class ChoiceHistoryService : IChoiceHistoryService
    {
        IChoiceHistoryRepository _repository;

        public ChoiceHistoryService(IChoiceHistoryRepository repository)
        {
            this._repository = repository;
        }

        public ChoiceHistory GetTodayChoiceHistory()
        {
            return _repository.GetFromDate(DateTime.Now);
        }

        public IList<ChoiceHistory> GetFromCurrentWeek()
        {
            DateTime dataAtual = DateTime.Now;
            DateTime startWeek = dataAtual.StartOfWeek(DayOfWeek.Sunday);
            DateTime endWeek = startWeek.AddDays((int)DayOfWeek.Saturday);
            return _repository.GetFromCurrentWeek(startWeek, endWeek);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
