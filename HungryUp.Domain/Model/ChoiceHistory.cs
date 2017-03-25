using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryUp.Domain.Model
{
    public class ChoiceHistory
    {
        public long ChoiceHistoryId { get; set; }
        public Restaurant Restaurant { get; set; }
        public DateTime Date { get; set; }
    }
}
