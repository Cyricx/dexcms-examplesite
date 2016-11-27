[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DexCMS.ExampleSite.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DexCMS.ExampleSite.App_Start.NinjectWebCommon), "Stop")]

namespace DexCMS.ExampleSite.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using DAL;
    using Ninject.Web.Mvc.FilterBindingSyntax;
    using System.Web.Mvc;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //! Infrastructure
            kernel.Bind<Core.Infrastructure.Contexts.IDexCMSContext>().To<CMSContext>();

            //! Core
            Core.Infrastructure.Globals.CoreRegister<CMSContext>.RegisterServices(kernel);

            //! Alerts
            Alerts.Globals.AlertsRegister<CMSContext>.RegisterServices(kernel);

            //! Base
            Base.Globals.BaseRegister<CMSContext>.RegisterServices(kernel);

            //! Calendars   
            Calendars.Globals.CalendarsRegister<CMSContext>.RegisterServices(kernel);

            //! Faqs
            Faqs.Globals.FaqsRegister<CMSContext>.RegisterServices(kernel);

            //! Ticketing
            Tickets.Globals.TicketsRegister<CMSContext>.RegisterServices(kernel);

            //Global Filters
            //Can not abstract below due to issues with having multiple libraries consuming WebActivatorEx
            kernel.BindFilter<Base.Mvc.Filters.ResolvePageContent>(FilterScope.Global, 0);
           // kernel.BindFilter<Tickets.Mvc.Filters.GetPublicOpenEvents>(FilterScope.Global, 0);
        }        
    }
}
