using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Quartz.Unity;
using Quartz;
using Quartz.Impl;
using HungryUp.Mvc.Schedule;

namespace HungryUp.Mvc
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            HungryUp.Startup.DependencyResolver.Resolve(container);

            container.AddNewExtension<QuartzUnityExtension>();

            container.RegisterType<IScheduler>(new HierarchicalLifetimeManager());

            NotificationScheduler._scheduler = container.Resolve<IScheduler>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}