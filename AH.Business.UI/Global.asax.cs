using AH.Core.Container;
using AH.Core.Orm;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace AH.Business.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            NHibernateManager.Configuration();
            NHibernateManager.UpdateSchema();

            AHSContainer.RegisterControllers(Assembly.GetExecutingAssembly());
            AHSContainer.SetResolver();

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}