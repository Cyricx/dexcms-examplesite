using DexCMS.Base.Mvc;
using DexCMS.Core.Infrastructure.Models;
using DexCMS.ExampleSite.App_Start;
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
            DexCMSConfiguration config = new DexCMSConfiguration();

            BaseMvcRoutes.ControlPanelDefaultRoutes(context, config);
        }
    }
}