using System.Web.Http.ExceptionHandling;

using log4net;

namespace Korann.Common
{
    public class WebApiUnhandledExceptionLogger : ExceptionLogger
    {
        private readonly ILog _log = LogManager.GetLogger("Global.Unhandled.WebApi");

        public override void Log(ExceptionLoggerContext context)
        {
            _log.ErrorFormat("Unhandled Web API exception when processing request {0}:\n\tRequest data:\n{1}\n\tException:\n{2}\n", context.Request.RequestUri, context.Request, context.Exception);
        }
    }
}