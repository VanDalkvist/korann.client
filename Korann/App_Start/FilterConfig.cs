using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Mvc;
using Korann.Common;

namespace Korann.App_Start
{
    public class FilterConfig
    {
        public static void RegisterLoggerFilters(GlobalFilterCollection filters, HttpConfiguration config)
        {
            // For MVC
            filters.Add(new MvcUnhandledExceptionLogger());
            // For WebApi
            config.Services.Add(typeof(IExceptionLogger), new WebApiUnhandledExceptionLogger());
        }
    }
}