using DexCMS.Core.Infrastructure.Models;
using DexCMS.ExampleSite.Migrations;
using System.Data.Entity;

namespace DexCMS.ExampleSite.DAL
{
    public class CMSInitializer : CreateDatabaseIfNotExists<CMSContext>
    {
        public override void InitializeDatabase(CMSContext context)
        {
            base.InitializeDatabase(context);
            (new Core.Infrastructure.Initializers.CoreInitializer(context)).Run();
            (new Base.Initializers.BaseInitializer(context)).Run();
            (new Calendars.Initializers.CalendarsInitializer(context)).Run();
            (new Calendars.Mvc.Initializers.CalendarsMvcInitializer(context)).Run();
            (new Faqs.Mvc.Initializers.FaqsMvcInitializer(context)).Run();
            (new Tickets.Mvc.Initializers.TicketsMvcInitializer(context)).Run();
            (new Alerts.Initializers.AlertsInitializer(context)).Run();
            (new Faqs.Initializers.FaqsInitializer(context)).Run();
        }
    }
}
