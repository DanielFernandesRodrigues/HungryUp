using HungryUp.Domain.Contracts.Services;
using Quartz;

namespace HungryUp.Mvc.Schedule
{
    public class NotificationJob : IJob
    {
        IChoiceHistoryService _service;

        public NotificationJob(IChoiceHistoryService service)
        {
            this._service = service;
        }

        public void Execute(IJobExecutionContext context)
        {
            NotificationScheduler.RemoveJobs();
            _service.RegisterChoiceHistory();
            HungryUp.Mvc.Helpers.ScoreHub.Static_Send("voteEnding");
        }
    }
}