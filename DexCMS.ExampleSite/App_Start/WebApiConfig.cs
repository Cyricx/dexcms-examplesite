using DexCMS.Base.WebApi;
using DexCMS.Core.Models;
using DexCMS.Core.WebApi;
using System.Web.Http;

namespace DexCMS.ExampleSite
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration httpConfig)
        {
            DexCMSConfiguration apiConfig = new DexCMSConfiguration();

            httpConfig.Routes.MapHttpRoute(
                name: "RegistrationApi",
                routeTemplate: "api/registration/{segment}/{action}/{id}/{secondKey}",
                defaults: new { controller = "registration", id = RouteParameter.Optional, secondKey = RouteParameter.Optional }
            );

            httpConfig.Routes.MapHttpRoute(
                name: "CheckInsApi",
                routeTemplate: "api/checkins/{segment}/{id}/{secondKey}",
                defaults: new { controller = "checkins", id = RouteParameter.Optional, secondKey = RouteParameter.Optional }
            );

            CoreApiRoutes.Configure(httpConfig, apiConfig);
            WebApiRoutes.CreateDefaultRoutes(httpConfig, apiConfig);
            CoreApiRoutes.CreateDefaultRoutes(httpConfig, apiConfig);
            httpConfig.MapHttpAttributeRoutes();
        }
    }
}
