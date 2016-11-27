using DexCMS.Core.Mvc.Models;
using DexCMS.Core.Mvc.Startup;
using Owin;

namespace DexCMS.ExampleSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Authentication.ConfigureAuth(app, new AuthenticationConfig());
        }
    }
}
