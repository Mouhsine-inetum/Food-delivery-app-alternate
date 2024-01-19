using Microsoft.AspNetCore.Authentication;
using System.Net;
using System.Net.Http.Headers;

namespace FoodDeliveryClient.App.Factory
{
    public class AuthorizationCookieHandler:HttpClientHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public AuthorizationCookieHandler(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            // Add the Authorization header to the outgoing request
            string scheme=_httpContextAccessor.HttpContext.Request.Scheme;
            string domain = "localhost";
            string port = "44320";

            this.CookieContainer.Add(new Uri($"{scheme}://{domain}:{port}/"), new Cookie()
            {
                Name = "access_token",
                Value = token,
                Domain = $"{domain}",
                Secure = true,
                HttpOnly = true,
                //Expires = DateTime.Now.AddMinutes(30),
            });
            // Continue with the request pipeline
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
