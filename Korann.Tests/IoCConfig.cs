using System.Reflection;
using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

using Korann.Configuration;
using Korann.Utils;

namespace Korann.Tests
{
    public class IoCConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            AppContext.RegisterDependencies(builder);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            IoCResolver.Initialize(container);
        }
    }
}