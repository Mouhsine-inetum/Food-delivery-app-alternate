using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Primitives;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using System.Net.Http.Headers;
using static System.Formats.Asn1.AsnWriter;

namespace FoodDeliveryClient.App.Factory
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _scopeLists;

        public TokenMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if the current request is authenticated
            if (context.User.Identity.IsAuthenticated)
            {
                string accessToken = await context.GetTokenAsync("access_token");
                //context.Response.Cookies.Append("token", accessToken,new CookieOptions() { HttpOnly=true,Secure=true, SameSite=SameSiteMode.None});

                // Add the Authorization header to the HttpClient
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }

}
