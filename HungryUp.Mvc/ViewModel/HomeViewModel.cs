using HungryUp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryUp.Mvc.ViewModel
{
    public class HomeViewModel
    {
        public IList<Restaurant> Restaurants { get; set; }
        public Vote Vote { get; set; }
        public IList<ScoreBoard> ScoreBoard { get; set; }
        public ChoiceHistory ChoiceHistory { get; set; }
        public string TitleMessage { get; set; }
    }
}