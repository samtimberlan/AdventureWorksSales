using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AdventureWorksSales.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Security enhancement. Server cloaking.
            MvcHandler.DisableMvcResponseHeader = true;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PreSendRequestHeaders()
        {
            if (HttpContext.Current != null)
            {
                // Security enhancement. Server cloaking.
                HttpContext.Current.Response.Headers.Remove("Server");
            }
        }
    }
}
