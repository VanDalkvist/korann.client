using Korann.Configuration;

namespace Korann.Tests.Services
{
    public class ServiceTestBase
    {
        public ServiceTestBase()
        {
            IoCConfig.RegisterDependencies();
            DTOConfig.RegisterMappings();
        }

        protected void Initialize()
        {
            
        }
    }
}