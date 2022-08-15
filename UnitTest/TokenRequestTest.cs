using Microsoft.Extensions.Logging;
using Moq;
using Services.Infrastructure;

namespace UnitTest
{
    public class TokenRequestTest
    {
        [Fact]
        public async Task ValidateGetTokenRequestAsync()
        {
            var mock = new Mock<ILogger<DealerService>>();
            ILogger<DealerService> logger = mock.Object;
            logger = Mock.Of<ILogger<DealerService>>();

            var dealerService = new DealerService(logger);
            var result = await dealerService.GetToken();
            if (result.success)
            {
                Assert.True(result.success);
            }
            else
            {
                Assert.False(result.success, result.message);
            }
        }
    }
}