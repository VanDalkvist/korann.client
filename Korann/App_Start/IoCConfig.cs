using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

using Korann.Configuration;

namespace Korann.App_Start
{
    public class IoCConfig
    {
        public static void RegisterDependencies(IEnumerable<Assembly> assemblies)
        {
            var builder = new ContainerBuilder();

            AppContext.RegisterDependencies(builder);

            RegisterControllers(assemblies, builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        public static void RegisterDependencies(Assembly assembly)
        {
            RegisterDependencies(new[] { assembly });
        }

        private static void RegisterControllers(IEnumerable<Assembly> assemblies, ContainerBuilder builder)
        {
            var controllerAssemblies = assemblies.ToArray();
            builder.RegisterControllers(controllerAssemblies).PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterApiControllers(controllerAssemblies).PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
        }
    }
}