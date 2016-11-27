using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Base.Contexts;
using DexCMS.Alerts.Contexts;
using DexCMS.Calendars.Contexts;
using DexCMS.Tickets.Contexts;
using DexCMS.Alerts.Models;
using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Models;
using DexCMS.Calendars.Models;
using DexCMS.Tickets.Events.Models;
using DexCMS.Tickets.Orders.Models;
using DexCMS.Tickets.Schedules.Models;
using DexCMS.Tickets.Tickets.Models;
using DexCMS.Tickets.Venues.Models;
using DexCMS.Faqs.Contexts;
using DexCMS.Faqs.Models;

namespace DexCMS.ExampleSite.DAL
{
    public class CMSContext : DbContext, IDexCMSContext, IDexCMSBaseContext, IDexCMSAlertsContext, IDexCMSCalendarsContext, IDexCMSFaqsContext, IDexCMSTicketsContext
    {
        //! CUSTOM

        //! ALERTS
        public DbSet<Alert> Alerts { get; set; }

        //! BASE
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<ContentArea> ContentAreas { get; set; }
        public DbSet<ContentBlock> ContentBlocks { get; set; }
        public DbSet<ContentCategory> ContentCategories { get; set; }
        public DbSet<ContentSubCategory> ContentSubCategories { get; set; }
        public DbSet<ContentScript> ContentScripts { get; set; }
        public DbSet<ContentStyle> ContentStyles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<PageContentImage> PageContentImages { get; set; }
        public DbSet<PageContent> PageContents { get; set; }
        public DbSet<PageType> PageTypes { get; set; }
        public DbSet<SettingDataType> SettingDataTypes { get; set; }
        public DbSet<SettingGroup> SettingGroups { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<VisitedPage> VisitedPages { get; set; }

        //! Calendars
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<CalendarEventStatus> CalendarEventStatuses { get; set; }
        public DbSet<CalendarEventType> CalendarEventTypes { get; set; }
        public DbSet<CalendarRepeatDay> CalendarRepeatDays { get; set; }
        public DbSet<CalendarRepeatType> CalendarRepeatTypes { get; set; }
        public DbSet<CalendarEventLocation> CalendarEventLocations { get; set; }

        //! Faqs
        public DbSet<FaqCategory> FaqCategories { get; set; }
        public DbSet<FaqItem> FaqItems { get; set; }

        //! Ticketing.Events
        public DbSet<Event> Events { get; set; }
        public DbSet<EventSeries> EventSeries { get; set; }
        public DbSet<EventAgeGroup> EventAgeGroups { get; set; }
        public DbSet<EventFaqCategory> EventFaqCategories { get; set; }
        public DbSet<EventFaqItem> EventFaqItems { get; set; }

        //! Ticketing.Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }

        //! Ticketing.Schedules
        public DbSet<ScheduleItem> ScheduleItems { get; set; }
        public DbSet<ScheduleStatus> ScheduleStatuses { get; set; }
        public DbSet<ScheduleType> ScheduleTypes { get; set; }

        //! Ticketing.Ticketing
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketAreaDiscount> TicketAreaDiscounts { get; set; }
        public DbSet<TicketArea> TicketAreas { get; set; }
        public DbSet<TicketDiscount> TicketDiscounts { get; set; }
        public DbSet<TicketOptionDiscount> TicketOptionDiscounts { get; set; }
        public DbSet<TicketOptionChoice> TicketOptionChoices { get; set; }
        public DbSet<TicketOption> TicketOptions { get; set; }
        public DbSet<TicketRow> TicketRows { get; set; }
        public DbSet<TicketSeat> TicketSeats { get; set; }
        public DbSet<TicketSection> TicketSections { get; set; }
        public DbSet<TicketPrice> TicketPrices { get; set; }
        public DbSet<TicketCutoff> TicketCutoffs { get; set; }

        //! Ticketing.Venues
        public DbSet<VenueArea> VenueAreas { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueRow> VenueRows { get; set; }
        public DbSet<VenueSection> VenueSections { get; set; }
        public DbSet<VenueScheduleLocation> VenueScheduleLocations { get; set; }

        //ctor
        public CMSContext() : base("ConnectionString") { }

        //Customize database table generation
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }

}
