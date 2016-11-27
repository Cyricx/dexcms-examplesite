using System.Web.Mvc;

namespace DexCMS.ExampleSite.Areas.ControlPanel
{
    public class ControlPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ControlPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ControlPanel_default",
                "ControlPanel/{*routes}",
                new { action = "Index", controller="Main", area = "ControlPanel" }
            );
        }
    }
}