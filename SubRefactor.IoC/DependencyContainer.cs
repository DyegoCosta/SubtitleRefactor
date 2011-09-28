using Microsoft.Practices.Unity;
using SubRefactor.IRepository;
using SubRefactor.IRepository.Infrastructure;
using SubRefactor.Repository.Infrastructure;
using SubRefactor.Repository.Repositories;

namespace SubRefactor.IoC
{
    public class DependencyContainer
    {
        public static IUnityContainer GetUnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new HttpContextLifetimeManager<IDatabaseFactory>());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HttpContextLifetimeManager<IUnitOfWork>());
            container.RegisterType<IUserRepository, UserRepository>(new HttpContextLifetimeManager<IUserRepository>());            
            
            return container;
        }
    }
}
