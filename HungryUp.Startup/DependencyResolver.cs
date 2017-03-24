using HungryUp.Business.Services;
using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Contracts.Services;
using HungryUp.Infrastructure.Data;
using HungryUp.Infrastructure.Repositories;
using Microsoft.Practices.Unity;

namespace GameEndpoints.Startup
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());            
        }
    }
}