using HungryUp.Common.Extensions;
using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Model;
using HungryUp.Infrastructure.Data;
using HungryUp.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HungryUp.Tests
{
    [TestClass]
    public class ChoiceHistoryTest
    {
        IChoiceHistoryRepository _repository;

        [TestInitialize]
        public void InitializeTests()
        {
            AppDataContext _context = new AppDataContext();
            _repository = new ChoiceHistoryRepository(_context);
        }

        [TestCleanup]
        public void CleanDatabaseResources()
        {
            _repository.Dispose();
        }

        [TestMethod]
        public void GetHistoryFromCurrentWeek()
        {
            DateTime dataAtual = DateTime.Now;
            DateTime startWeek = dataAtual.StartOfWeek(DayOfWeek.Sunday);
            DateTime endWeek = startWeek.AddDays(6);
            IList<ChoiceHistory> choiceHistory = _repository.GetFromCurrentWeek(startWeek, endWeek);
            Assert.IsNotNull(choiceHistory);
        }
    }
}
