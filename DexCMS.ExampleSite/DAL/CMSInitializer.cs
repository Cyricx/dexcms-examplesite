using DexCMS.Core.Globals;
using System.Data.Entity;

namespace DexCMS.ExampleSite.DAL
{
    public class CMSInitializer : CreateDatabaseIfNotExists<CMSContext>
    {
        public override void InitializeDatabase(CMSContext context)
        {
            base.InitializeDatabase(context);

            string[] mods = new string[] { "Core", "Base", "Calendars", "Faqs", "Alerts", "Tickets" };

            DexCMSApplicationInitializer.InitializeApplication(context, mods);
        }
    }
}
