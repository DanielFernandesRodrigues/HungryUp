using System;

namespace HungryUp.Domain.Model
{
    public class Vote
    {
        public long VoteId { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
    }
}
