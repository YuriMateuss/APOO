using AlugueldeTemas.Controllers;
using AlugueldeTemas.Services;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.Mvc5;

namespace AlugueldeTemas
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

 
            var container = new UnityContainer();
            container.RegisterType<ItemService>();
            container.RegisterType<ItemController>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
