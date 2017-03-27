using HungryUp.Domain.Model;
using System;
using System.Collections.Generic;

namespace HungryUp.Mvc.ViewModel
{
    public class HomeViewModel
    {
        public IList<Restaurant> Restaurants { get; set; }
        public Vote Vote { get; set; }
        public IList<ScoreBoard> ScoreBoard { get; set; }
        public ChoiceHistory ChoiceHistory { get; set; }
        public string TitleMessage { get; set; }
        public string HourComplete { get; set; }
        public string DateNow { get; set; }

        public void SetTimeInteval(int hour, int minute)
        {
            DateNow = DateTime.Now.ToString("HH:mm:ss");
            HourComplete = string.Format("{0}:{1}:00", hour.ToString().PadLeft(2, '0'), minute.ToString().PadLeft(2, '0'));
        }
    }
}