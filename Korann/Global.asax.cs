using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Korann.App_Start;
using Korann.Common;
using Korann.Configuration;

using log4net;

namespace Korann
{
    public class KorannClientApp : HttpApplication
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(KorannClientApp));

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            _log.Info("Korann.Client application started");

            _log.Info("Configuring WebApi: registering api routes.");
            GlobalConfiguration.Configure(WebApiConfig.Register);

            _log.Info("Configuring MVC/WebApi: registering exception loggers.");
            FilterConfig.RegisterLoggerFilters(GlobalFilters.Filters, GlobalConfiguration.Configuration);

            _log.Info("Configuring MVC: registering routes.");
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            _log.Info("Configuring MVC/WebApi: registering bundles.");
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            _log.Info("Configuring dto mappings.");
            DTOConfig.RegisterMappings();

            _log.Info("Configuring IoC containers.");
            var builder = IoCConfig.RegisterDependencies(typeof(KorannClientApp).Assembly);

            _log.Info("Configuring Rest clients.");
            ApiConfig.RegisterRestClients(builder);

            builder.RegisterResolvers(GlobalConfiguration.Configuration);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            var httpContext = ((KorannClientApp)sender).Context;
            _log.RecursiveLogError(error, httpContext.Request.Url);
        }
    }
}