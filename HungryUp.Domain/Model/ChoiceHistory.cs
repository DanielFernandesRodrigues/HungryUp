using System;

namespace HungryUp.Domain.Model
{
    public class ChoiceHistory
    {
        public long ChoiceHistoryId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public DateTime Date { get; set; }
    }
}
