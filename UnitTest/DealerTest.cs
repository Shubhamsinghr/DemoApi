using Microsoft.Extensions.Logging;
using Moq;
using Services.DTO;
using Services.Infrastructure;

namespace UnitTest
{
    public class DealerTest
    {

        [Fact]
        public async Task ValidateGetDealerRequestAsync()
        {
            var mock = new Mock<ILogger<DealerService>>();
            ILogger<DealerService> logger = mock.Object;
            logger = Mock.Of<ILogger<DealerService>>();

            var dealerService = new DealerService(logger);
            var tokenResponse = await dealerService.GetToken();
            if (tokenResponse.success)
            {
                var result = await dealerService.GetDealers(new DealerModelDTO { AccessToken = tokenResponse.data, SearchString = "Test Account" });
                if (result.success)
                {
                    Assert.True(result.success);

                }
                else
                {
                    Assert.False(result.success);
                }
            }
            else
            {
                Assert.False(tokenResponse.success, tokenResponse.message);
            }
        }
    }
}
