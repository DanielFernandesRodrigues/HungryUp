using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HungryUp.Mvc.Startup))]
namespace HungryUp.Mvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}