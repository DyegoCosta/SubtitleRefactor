using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using SubRefactor.AutoMapper;
using SubRefactor.IoC;

namespace SubRefactor
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        private static void RegisterDependencyResolver(IUnityContainer container)
        {
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterDependencyResolver(DependencyContainer.GetUnityContainer());
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            AutoMapperConfigurator.Configure();
        }

        
    }
}