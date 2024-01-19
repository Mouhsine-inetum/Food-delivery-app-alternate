namespace FoodDeliveryClient.App.CustomMiddleware
{
    public class TokenCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if the user is authenticated
            if (context.User.Identity.IsAuthenticated)
            {
                var expirationClaim = context.User.FindFirst("exp");
                if (expirationClaim != null && long.TryParse(expirationClaim.Value, out long expirationTime))
                {
                    // Check if the token has expired
                    if (DateTime.UtcNow > DateTimeOffset.FromUnixTimeSeconds(expirationTime).UtcDateTime)
                    {
                        // Token has expired, perform logout
                        context.Response.Redirect("/Account/Logout"); // Redirect to your logout page
                        return;
                    }
                }
            }
            else
            {
                context.Response.Redirect("/Accounts/Login");
            }

            // Continue with the pipeline
            await _next(context);
        }
    }

    public static class TokenExpirationMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenExpirationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenCheckMiddleware>();
        }

    }
}
