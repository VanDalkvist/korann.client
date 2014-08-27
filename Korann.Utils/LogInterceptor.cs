using System.Diagnostics;
using System.Linq;

using Castle.DynamicProxy;

using log4net;

namespace Korann.Utils
{
    public class LogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var log = LogManager.GetLogger(invocation.TargetType);

            if (log.IsDebugEnabled)
            {
                var args = string.Join(", ", invocation.Arguments.Select(a => (a ?? string.Empty).ToString()));

                log.DebugFormat("Starting [{0}]: {1}", invocation.Method.Name, args);

                var timer = Stopwatch.StartNew();

                invocation.Proceed();

                timer.Stop();

                log.DebugFormat("Finished [{0}]: {1}. - {2}", invocation.Method.Name, invocation.ReturnValue, timer.ElapsedMilliseconds);
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}