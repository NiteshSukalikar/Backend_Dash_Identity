namespace IEH_Dashboard.Utility
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Primitives;
    using Newtonsoft.Json;
    using Serilog;
    using IEH_Dashboard.Common.StaticConstants;
    using IEH_Dashboard.ViewModel.Shared;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines The RequestTokenFilter
    /// </summary>
    public class RequestTokenFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Defines the _configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestTokenFilter"/> class.
        /// </summary>
        /// <param name="Configuration">The Configuration<see cref="IConfiguration"/></param>
        public RequestTokenFilter(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        /// <summary>
        /// The OnActionExecutionAsync
        /// <param name="requestContext">The requestContext<see cref="ActionExecutingContext"/></param>
        /// <param name="next">The next<see cref="ActionExecutionDelegate"/></param>
        /// </summary>
        /// <param name="requestContext">The requestContext<see cref="ActionExecutingContext"/></param>
        /// <param name="next">The next<see cref="ActionExecutionDelegate"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext requestContext, ActionExecutionDelegate next)
        {
            requestContext.HttpContext.Request.Headers.TryGetValue("access_token", out StringValues access_token);
            requestContext.HttpContext.Request.Headers.TryGetValue("refresh_token", out StringValues refresh_token);
            TokenResponseVM tokenResponseVM = new TokenResponseVM();
            try
            {
                if (access_token.ToString() != null && refresh_token.ToString() != null)
                {
                    HttpClient _httpClient = new HttpClient();


                    Dictionary<string, string> val = new Dictionary<string, string>
                        {
                            { "refresh_token", refresh_token},
                        };

                    // get access token

                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    _httpClient.DefaultRequestHeaders.Add("access_token", access_token.ToString());

                    FormUrlEncodedContent getAccessTokenContent = new FormUrlEncodedContent(val);

                    HttpResponseMessage getAccessTokenResponse = await _httpClient.PostAsync(_configuration["OsApi:OsApiCheckAccessToken"].ToString(), getAccessTokenContent);

                    string getAccessTokenResponseString = await getAccessTokenResponse.Content.ReadAsStringAsync();

                    TokenResponseVM getAccessTokendata = JsonConvert.DeserializeObject<TokenResponseVM>(getAccessTokenResponseString);

                    if (getAccessTokendata.Code.Equals(IEHMessages.Ok))
                    {
                        if (getAccessTokendata.Token is null)
                        {
                            tokenResponseVM.HasUpdatedToken = false;
                            tokenResponseVM.StatusCode = IEHMessages.Ok;
                        }
                        else
                        {
                            tokenResponseVM.HasUpdatedToken = true;
                            tokenResponseVM.Token = getAccessTokendata.Token;
                            tokenResponseVM.StatusCode = IEHMessages.Ok;
                        }
                    }
                    else
                    {
                        tokenResponseVM.StatusCode = IEHMessages.InvalidTokenCode;
                        tokenResponseVM.Message = IEHMessages.InvalidToken;
                    }
                }
                else
                {
                    tokenResponseVM.StatusCode = IEHMessages.InvalidTokenCode;
                    tokenResponseVM.Message = IEHMessages.InvalidToken;
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                tokenResponseVM.StatusCode = IEHMessages.ServerErrorCode;
                tokenResponseVM.Message = IEHMessages.InternalServerError;
            }

            requestContext.HttpContext.Items["responseVM"] = tokenResponseVM;
            requestContext.HttpContext.Items["Payload"] = JsonConvert.SerializeObject(requestContext.ActionArguments);
            //HttpContext.Items["CreatedBy"] = filterParams.CreatedBy;

            ActionExecutedContext resultContext = await next();
        }
    }
}
