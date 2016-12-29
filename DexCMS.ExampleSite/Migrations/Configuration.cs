namespace DexCMS.ExampleSite.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.CMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DexCMS.ExampleSite.DAL.CMSContext";
        }

        protected override void Seed(DAL.CMSContext context)
        {
            
            (new Core.Infrastructure.Initializers.CoreInitializer(context)).Run();
            (new Base.Initializers.BaseInitializer(context, context)).Run();
            (new Calendars.Initializers.CalendarsInitializer(context)).Run();
            (new Calendars.Mvc.Initializers.CalendarsMvcInitializer(context)).Run();
            (new Faqs.Mvc.Initializers.FaqsMvcInitializer(context)).Run();
            (new Tickets.Mvc.Initializers.TicketsMvcInitializer(context)).Run();
            (new Alerts.Initializers.AlertsInitializer(context)).Run();
            (new Faqs.Initializers.FaqsInitializer(context)).Run();
        }
    }
}
