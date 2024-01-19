using Auth0.AspNetCore.Authentication;
using FoodDeliveryClient.App.CustomMiddleware;
using FoodDeliveryClient.App.Factory;
using FoodDeliveryClient.App.Services;
using FoodDeliveryClient.App.Services.Cores;
using FoodDeliveryClient.App.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NuGet.Packaging;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDistributedMemoryCache();


//IEnumerable<string>? initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ');






//Cookie configuration for HTTPS
//builder.Services.Configure<CookiePolicyOptions>(options =>
//{
//    options.MinimumSameSitePolicy = SameSiteMode.None;
//    options.HttpOnly = HttpOnlyPolicy.Always;
//    options.Secure = CookieSecurePolicy.Always;
//});


//auth auth0
builder.Services.AddAuth0WebAppAuthentication(options =>
    {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
        options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
        options.Scope = "openid profile";
        options.LoginParameters = new Dictionary<string, string>() { { "screen_hint", "signup" } };
        options.CallbackPath = new PathString("/Callback");
        options.ResponseType = OpenIdConnectResponseType.Code;
    })
      .WithAccessToken(options =>
        {
            options.Audience = builder.Configuration["Auth0:Audience"];
            options.UseRefreshTokens = true;
            options.Events = new Auth0WebAppWithAccessTokenEvents()
            {
               
            };
        });



/////auth custom
//builder.Services.AddAuthentication(conf =>
//{
//    conf.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    conf.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    conf.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//})
//.AddCookie()
//.AddOpenIdConnect("Auth0", options =>
//{
//    options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
//    options.ClientId = builder.Configuration.GetSection("Auth0:ClientId").Value;
//    options.ClientSecret = builder.Configuration.GetSection("Auth0:ClientSecret").Value;
//    options.ResponseType = OpenIdConnectResponseType.Code;

//    options.Scope.Clear();
//    options.Scope.Add("openid");
//    options.Scope.Add("profile");
//    //options.Scope.AddRange(initialScopes);

//    options.CallbackPath = new PathString("/Callback");
//    options.ClaimsIssuer = "Auth0";
//    options.SaveTokens = true;

//    options.Events = new OpenIdConnectEvents
//    {
//        OnRedirectToIdentityProviderForSignOut = (context) =>
//        {
//            var logoutUri = $"https://{builder.Configuration["Auth0:Domain"]}/v2/logout?client_id={builder.Configuration.GetSection("Auth0:ClientId").Value}";
//            var postLogoutUri = context.Properties.RedirectUri;
//            if (!string.IsNullOrEmpty(postLogoutUri))
//            {
//                if (postLogoutUri.StartsWith("/"))
//                {
//                    var request = context.Request;
//                    postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;

//                }
//                logoutUri += $"&returnTo={Uri.EscapeDataString(postLogoutUri)}";
//            }
//            context.Response.Redirect(logoutUri);
//            context.HandleResponse();
//            return Task.CompletedTask;
//        },

//        OnRedirectToIdentityProvider = context =>
//        {
//            context.ProtocolMessage.SetParameter("audience", builder.Configuration["Auth0:Audience"]);
//            return Task.FromResult(0);
//        },
//        OnMessageReceived = context =>
//        {
//            if (context.ProtocolMessage.Error == "access denied")
//            {
//                context.HandleResponse();
//                context.Response.Redirect("/Account/AccessDenied");
//            }
//            return Task.FromResult(0);
//        }

//    };

//});


builder.Services.AddRazorPages();


builder.Services.ServicesInjection(builder.Configuration);


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCookiePolicy();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseTokenExpirationMiddleware();
app.UseAuthorization();

app.MapRazorPages();
app.Run();
