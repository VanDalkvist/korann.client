using Korann.Configuration;
using Korann.Infrastructure;

using Moq;

namespace Korann.Tests.Services
{
    public class ServiceTestBase
    {
        protected Mock<IApiClient> ApiClientMock;

        public ServiceTestBase()
        {
            IoCConfig.RegisterDependencies();
            DTOConfig.RegisterMappings();

            ApiClientMock = new Mock<IApiClient>();
        }

        protected void Initialize()
        {
            
        }
    }
}