using HungryUp.Common.Resources;
using HungryUp.Domain.Contracts.Services;
using HungryUp.Domain.Model;
using HungryUp.Mvc.ViewModel;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HungryUp.Mvc.Schedule;
using System.Configuration;
using Quartz;

namespace HungryUp.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IChoiceHistoryService _choiceService;
        private IVoteService _voteService;
        private IRestaurantService _restaurantService;
        private IScheduler _scheduler;

        public HomeController(IChoiceHistoryService choiceService, IVoteService voteService, IRestaurantService restaurantService, IScheduler scheduler)
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
                {
                    string message = model.ChoiceHistory.Draw ? CommonMessages.VoteFinishWithDraw : CommonMessages.VoteFinish;
                    throw new Exception(string.Format(message, model.ChoiceHistory.Restaurant.Name));
                }

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

        public ActionResult Vote(long id)
        {
            try
            {
                NotificationScheduler.Start();
                Vote vote = _voteService.RegisterVote(User.Identity.Name, id);
            }
            catch (Exception ex)
            {
                TempData["VoteMessage"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _choiceService.Dispose();
            _voteService.Dispose();
            _restaurantService.Dispose();
            base.Dispose(disposing);
        }
    }
}