using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BookFinderAPI.Attributes
{
    //This is to mention at which places the attribute can be used
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string APIKEYNAME = "ApiKey";
        //API Call request happens and performs intercept
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Check whether the API request have a request header called 'ApiKey'
            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "BookFinderAPI - Unauthorized Access, Api Key was not provided to grant access to API Endpoint. Please write to XXXX@YYYY.ZZZZ to get your key."
                };
                return;
            }
            //If the ApiKey header is found in the API call request from the client
            //Read the appSettings.json file
            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            //Read the ApiKey setting which is found in the JSON file
            var apiKey = appSettings.GetValue<string>(APIKEYNAME);
            if (!apiKey.Equals(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "BookFinderAPI - Api Key sent is not valid, please send a valid key."
                };
                return;
            }
            await next();
        }
    }
}
