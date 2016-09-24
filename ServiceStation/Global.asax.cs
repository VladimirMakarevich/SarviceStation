using ServiceStation.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;

namespace ServiceStation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalFilters.Filters.Add(new WatchConfig());

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
