using System.Web.Mvc;
using System.Web.Routing;
using System;
using System.Web;
using System.Web.Http;
using DexCMS.ExampleSite.DAL;
using DexCMS.Core;
using DexCMS.Core.Repositories;
using DexCMS.Core.Mvc.Globals;
using DexCMS.Base.Mvc.Globals;

namespace DexCMS.ExampleSite
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //Initial and load site setings
            (new SiteSettingsBuilder(new SettingRepository(new CMSContext()))).Initialize();
            //initialize logger
            Logger.InitializeRepository(new LogRepository(new CMSContext()));
            AreaRegistration.RegisterAllAreas();
            ViewEngineConfig.RegisterViewEngines();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FiltersConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            MvcFiltersConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            DexCMSBeginRequest.ForceLowerCase(Request, Response);
        }
    }
}
