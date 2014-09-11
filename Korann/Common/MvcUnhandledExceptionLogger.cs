using System.Web.Mvc;
using log4net;

namespace Korann.Common
{
    public class MvcUnhandledExceptionLogger : HandleErrorAttribute
    {
        private readonly ILog _log = LogManager.GetLogger("Global.Unhandled.Mvc");

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var request = context.HttpContext.Request;
            var requestData = string.Format("Http method:{0}", request.HttpMethod);

            _log.ErrorFormat("Unhandled MVC exception when processing request {0}:\n\tRequest data:\n{1}\n\tException:\n{2}\n", context.HttpContext.Request.RawUrl, requestData, context.Exception);
        }
    }
}