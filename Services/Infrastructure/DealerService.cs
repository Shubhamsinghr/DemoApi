using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using Services.DTO;
using Shared.CommonExceptions;
using Shared.Constants;
using Shared.GenericResponse;
using Shared.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infrastructure
{
    public class DealerService : IDealerService
    {
        private readonly ILogger _logger;

        public DealerService(ILogger<DealerService> logger)
        {
            _logger = logger;
        }

        public async Task<Response<string>> GetToken()
        {
            _logger.LogInformation("Getting token from api, Calling Token Handler");
            return TokenHandler.GetToken(_logger);
        }

        public Task<Response<List<AccountInfoResponse>>> GetDealers(DealerModelDTO model)
        {
            try
            {
                _logger.LogInformation("Getting Dealers from api...");

                Response<List<AccountInfoResponse>> response = new Response<List<AccountInfoResponse>>();
                RestClient restClient = new RestClient();
                RestRequest request = new RestRequest(ApiURLConstant.AccountInfoURL, Method.Post);

                request.AddHeader("Authorization", "Bearer " + model.AccessToken);
                request.AddHeader("Content-Type", "application/json");

                string requestJson = JsonConvert.SerializeObject(new
                {
                    name = model.SearchString
                });

                RestResponse result = restClient.Execute(request.AddJsonBody(requestJson));
                List<AccountInfoResponse> res = JsonConvert.DeserializeObject<List<AccountInfoResponse>>(result.Content);

                if (result.IsSuccessful)
                {
                    _logger.LogInformation("Got Dealers from api.");
                    response.data = res;
                    return Task.FromResult(response);
                }
                else
                {
                    _logger.LogInformation("Got issue in Dealer api.");
                    response.success = false;
                    return Task.FromResult(response);
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
