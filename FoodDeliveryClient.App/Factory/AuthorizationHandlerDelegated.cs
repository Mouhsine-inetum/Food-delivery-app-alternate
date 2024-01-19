using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace FoodDeliveryClient.App.Factory
{
    public class AuthorizationHandlerDelegated: DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthorizationHandlerDelegated(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token =await  _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            // Add the Authorization header to the outgoing request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // Continue with the request pipeline
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
