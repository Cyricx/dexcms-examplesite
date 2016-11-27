using System.Web.Mvc;

namespace DexCMS.ExampleSite.Areas.Secure
{
    public class SecureAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Secure";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "process_payment",
                "Secure/Payment",
                new
                {
                    action = "ProcessPayment",
                    controller = "Checkout",
                    area = "Secure"
                });

            context.MapRoute(
                "cancel_payment",
                "Secure/Cancel/{orderID}",
                new
                {
                    action = "CancelPayment",
                    controller = "Checkout",
                    area = "Secure"
                });

            context.MapRoute(
                "print_order",
                "Secure/Print/{orderID}",
                new
                {
                    action = "Print",
                    controller = "Checkout",
                    area = "Secure",
                    category = "checkout",
                    urlSegment = "print"
                }
            );

            context.MapRoute(
                "Secure_default",
                "Secure/{*routes}",
                new { action = "Index", controller = "Secure", area = "Secure" }
            );

            
        }
    }
}