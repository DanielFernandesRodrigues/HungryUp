using System;

namespace HungryUp.Domain.Model
{
    public class ChoiceHistory
    {
        public long ChoiceHistoryId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public DateTime Date { get; set; }
        public bool Draw { get; set; }

        protected ChoiceHistory() { }

        public ChoiceHistory(Restaurant restaurant, bool draw)
        {
            this.Restaurant = restaurant;
            this.Date = DateTime.Now;
            this.Draw = draw;
        }
    }
}
