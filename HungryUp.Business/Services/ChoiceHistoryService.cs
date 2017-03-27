using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Contracts.Services;
using HungryUp.Domain.Model;
using HungryUp.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Collections;

namespace HungryUp.Business.Services
{
    public class ChoiceHistoryService : IChoiceHistoryService
    {
        IChoiceHistoryRepository _repository;
        IVoteRepository _voteRepository;
        IRestaurantRepository _restaurantRepository;

        public ChoiceHistoryService(IChoiceHistoryRepository repository, IVoteRepository voteRepository, IRestaurantRepository restaurantRepository)
        {
            this._repository = repository;
            this._voteRepository = voteRepository;
            this._restaurantRepository = restaurantRepository;
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
        
        public ChoiceHistory RegisterChoiceHistory()
        {
            IList<ScoreBoard> votes = _voteRepository.GetAllVotesByDateGroupByRestaurantId(DateTime.Now);
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.SetMostVoted(votes);
            Restaurant restaurant = _restaurantRepository.GetById(scoreBoard.RestaurantId);
            ChoiceHistory choiceHistory = new ChoiceHistory(restaurant, scoreBoard.Draw);
            return _repository.Add(choiceHistory);
        }

        public void CleanChoiceHistoryVotesDay()
        {
            _repository.CleanChoiceDay();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
