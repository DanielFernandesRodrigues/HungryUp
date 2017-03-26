using HungryUp.Common.Resources;
using HungryUp.Domain.Contracts.Services;
using HungryUp.Domain.Model;
using HungryUp.Mvc.ViewModel;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HungryUp.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IChoiceHistoryService _choiceService;
        IVoteService _voteService;
        IRestaurantService _restaurantService;

        public HomeController(IChoiceHistoryService choiceService, IVoteService voteService, IRestaurantService restaurantService)
        {
            this._choiceService = choiceService;
            this._voteService = voteService;
            this._restaurantService = restaurantService;
        }

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            try
            {
                model.ChoiceHistory = _choiceService.GetTodayChoiceHistory();
                model.Vote = _voteService.GetTodayVote(User.Identity.Name);
                model.ScoreBoard = _voteService.GetAllTodayVotesGroupByRestaurant();

                if (model.ChoiceHistory != null)
                    throw new Exception(string.Format(CommonMessages.VoteFinish, model.ChoiceHistory.Restaurant.Name));

                if (model.ChoiceHistory != null || model.Vote != null)
                    throw new Exception(string.Format(CommonMessages.YouAlreadyVoteToday, model.Vote.Restaurant.Name));

                model.TitleMessage = CommonMessages.ChooseYourFavorite;
                model.Restaurants = _restaurantService.GetWeekAvaiable();
            }
            catch (Exception ex)
            {
                model.TitleMessage = ex.Message;
            }

            return View(model);
        }
    }
}