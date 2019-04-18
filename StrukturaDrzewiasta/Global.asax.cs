using StrukturaDrzewiasta.App_Start;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace StrukturaDrzewiasta
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
        }
    }
}