using GameEndpoints.Common.Validations;
using HungryUp.Common.Resources;
using System;

namespace HungryUp.Domain.Model
{
    public class Vote
    {
        public long VoteId { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Restaurant Restaurant { get; set; }

        protected Vote() { }

        public Vote(User user, Restaurant restaurant)
        {
            this.Date = DateTime.Now;
            this.User = user;
            this.Restaurant = restaurant;
        }
    }
}
