using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace HungryUp.Mvc
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            HungryUp.Startup.DependencyResolver.Resolve(container);
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}