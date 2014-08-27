using Autofac;
using Autofac.Builder;
using Autofac.Extras.DynamicProxy2;

using Korann.DAL.Contracts;
using Korann.DAL.Repositories;
using Korann.Infrastructure.Contracts;
using Korann.Infrastructure.Services;
using Korann.Utils;

namespace Korann.Configuration
{
    public static class IoCRegistrator
    {
        public static void RegisterDependencies(this ContainerBuilder builder)
        {
            builder.Register(context => new LogInterceptor());

            builder.RegisterType<ProductRepository>().As<IProductRepository>().ConfigureRepository();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().ConfigureRepository();

            builder.RegisterType<ProductService>().As(typeof(IProductService));
            builder.RegisterType<CategoryService>().As(typeof(ICategoryService));
        }

        private static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> ConfigureRepository<TLimit, TActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> builder)
        {
            return builder.SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(LogInterceptor));
        }
    }
}