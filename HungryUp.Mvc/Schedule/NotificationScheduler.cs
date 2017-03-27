using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;
using System.Configuration;
using System.Linq;

namespace HungryUp.Mvc.Schedule
{
    public static class NotificationScheduler
    {
        public static IScheduler _scheduler;

        public static void Start()
        {
            if (TriggerAlreadySchedule())
                return;

            int hour = Convert.ToInt32(ConfigurationManager.AppSettings["HourEnd"]);
            int minute = Convert.ToInt32(ConfigurationManager.AppSettings["MinuteEnd"]);
            bool isTest = Convert.ToBoolean(ConfigurationManager.AppSettings["ScheduleTest"]);

            
            var job = JobBuilder.Create<NotificationJob>()
            .Build();
            
            if (isTest)
            {
                var dataAtual = DateTime.Now.AddMinutes(3);
                hour = dataAtual.Hour;
                minute = dataAtual.Minute;
            }

            var triggerName = "trigger";
            var triggerGroup = "group1";

            var _trigger = TriggerBuilder.Create()
                    .WithIdentity(triggerName, triggerGroup)
                    .WithDailyTimeIntervalSchedule(
                        x => x.StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(hour, minute))//Define a hora em que inicia a trigger
                        .EndingDailyAt(TimeOfDay.HourAndMinuteOfDay(hour, minute + 1))//Define a hora em que a trigger é finalizada
                        .OnDaysOfTheWeek(DateTime.Now.DayOfWeek)//Define o dia da semana em que a trigger é disparada
                        .WithIntervalInMinutes(5))//Define de quanto em quanto tempo a trigger será executada
                        .Build();

            _scheduler.ScheduleJob(job, _trigger);
            _scheduler.Start();
        }

        private static bool TriggerAlreadySchedule()
        {
            var sc = _scheduler.GetTriggerKeys(GroupMatcher<TriggerKey>.AnyGroup()).FirstOrDefault();
            return sc != null;
        }

        public static void RemoveJobs()
        {
            var scheduler = _scheduler;
            
            var allTriggerKeys = scheduler.GetTriggerKeys(GroupMatcher<TriggerKey>.AnyGroup());

            foreach (var triggerKey in allTriggerKeys)
            {
                ITrigger trigger = scheduler.GetTrigger(triggerKey);
                var allJobKeys = scheduler.GetJobDetail(trigger.JobKey);
                scheduler.UnscheduleJob(trigger.Key);
            }
        }
    }
}