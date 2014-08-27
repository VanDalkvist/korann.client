using Autofac;

namespace Korann.Utils
{
    public static class IoCResolver
    {
        private static IContainer _container;

        public static void Initialize(IContainer container)
        {
            _container = container;
        }

        public static TObject Resolve<TObject>()
        {
            return _container.Resolve<TObject>();
        }
    }
}