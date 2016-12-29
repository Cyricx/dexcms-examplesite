using DexCMS.Base.Mvc;
using DexCMS.Core.Infrastructure.Models;
using System.Web.Mvc;
using System.Web.Routing;
using DexCMS.Core.Mvc;
using DexCMS.Faqs;
using DexCMS.Alerts.Mvc;
using DexCMS.Calendars.Mvc;
using DexCMS.Tickets.Mvc;

namespace DexCMS.ExampleSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            DexCMSConfiguration config = new DexCMSConfiguration();
            
            CoreMvcRoutes.Configure(routes, config);
            CoreMvcRoutes.CreateDefaltRoutes(routes, config);
            AlertsMvcRoutes.CreateDefaultRoutes(routes, config);
            CalendarsMvcRoutes.CreateDefaultRoutes(routes, config);
            TicketsMvcRoutes.CreateDefaultRoutes(routes, config);
            FaqsMvcRoutes.CreateDefaultRoutes(routes, config);
            BaseMvcRoutes.CreateDefaultRoutes(routes, config);
            CoreMvcRoutes.CreateFinalRoutes(routes, config);
        }
    }
}