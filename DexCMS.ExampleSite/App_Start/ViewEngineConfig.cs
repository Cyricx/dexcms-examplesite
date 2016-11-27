using System.Web.Mvc;
using DexCMS.Core.Mvc.Globals;

namespace DexCMS.ExampleSite
{
    public static class ViewEngineConfig
    {
        public static void RegisterViewEngines()
        {
            ViewEngines.Engines.Clear();
            var dexcmsViewEngine = new DexCMSViewEngine();
            ViewEngines.Engines.Add(dexcmsViewEngine);
        }
    }
}
