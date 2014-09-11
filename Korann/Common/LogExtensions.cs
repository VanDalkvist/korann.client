using System;
using System.Reflection;

using log4net;

namespace Korann.Common
{
    public static class LogExtensions
    {
        private const string ErrorFormat = "Error occurred during processing the request to: {0}";

        public static void RecursiveLogError(this ILog logger, Exception exception, Uri url = null)
        {
            if (logger == null) throw new ArgumentNullException("logger");
            if (exception == null) throw new ArgumentNullException("exception");

            var message = url != null ? url.ToString() : exception.Message;
            logger.Error(string.Format(ErrorFormat, message), exception);

            if (exception.InnerException != null)
            {
                RecursiveLogError(logger, exception.InnerException, url);
            }

            var typeLoadException = exception as ReflectionTypeLoadException;
            if (typeLoadException != null)
            {
                foreach (var innerException in typeLoadException.LoaderExceptions)
                {
                    RecursiveLogError(logger, innerException, url);
                }
            }

            var aggregateException = exception as AggregateException;
            if (aggregateException == null) return;

            foreach (var innerException in aggregateException.Flatten().InnerExceptions)
            {
                RecursiveLogError(logger, innerException, url);
            }
        }
    }
}