using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using Shared.Constants;
using Shared.GenericResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Handler
{
    public static class TokenHandler
    {
        public static Response<string> GetToken(ILogger _logger)
        {
            try
            {
                _logger.LogInformation("Calling token api to get token...");

                // calling api using RestSharp
                Response<string> response = new Response<string>();
                RestClient restClient = new RestClient();
                RestRequest request = new RestRequest(ApiURLConstant.TokenURL, Method.Post);

                request.AlwaysMultipartFormData = true;
                request.AddParameter("grant_type", "password");
                request.AddParameter("client_id", ApiURLConstant.ClientId);
                request.AddParameter("client_secret", ApiURLConstant.ClientSecret);
                request.AddParameter("username", ApiURLConstant.Username);
                request.AddParameter("password", ApiURLConstant.Password);

                RestResponse result = restClient.Execute(request);

                var res = JsonConvert.DeserializeObject<TokenResponse>(result.Content);

                if (result.IsSuccessful)
                {
                    _logger.LogInformation("Got access token successfully.");
                    response.data = res.access_token;
                    return response;
                }
                else
                {
                    _logger.LogError(res.error_description);
                    response.success = false;
                    response.message = res.error_description;
                    return response;
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
