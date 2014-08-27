using System;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Korann.App_Start;
using Korann.Configuration;

using log4net;
using log4net.Config;

namespace Korann
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        private static ILog log;

        protected void Application_Start()
        {
            log = LogManager.GetLogger(typeof (MvcApplication));

            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            BasicConfigurator.Configure();

            log.InfoFormat("Initialize application");

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IoCConfig.RegisterDependencies();
            DTOConfig.RegisterMappings();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            var httpContext = ((MvcApplication)sender).Context;
            var url = httpContext.Request.Url;
            
            log.Error(string.Format("Error occurred during processing the request to: {0}", url), error);
        }
    }
}