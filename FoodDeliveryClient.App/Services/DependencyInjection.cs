using FoodDeliveryClient.App.Common.Policy;
using FoodDeliveryClient.App.Factory;
using FoodDeliveryClient.App.Services.Cores;
using FoodDeliveryClient.App.Services.Interfaces;
using Microsoft.DotNet.Scaffolding.Shared;
using System.Configuration;

namespace FoodDeliveryClient.App.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection ServicesInjection(this IServiceCollection services, IConfiguration configuration)
        {

            // admin services

            services.AddHttpContextAccessor();
            var policies = Policies.GetRetryPolicy();
            var circuit = Policies.GetCircuitBreakerPolicy();
            services.AddHttpClient<IAdminService, AdminService>(client =>
            {
                var path = "admins";
                var apiSet = configuration.GetSection("DownstreamApi");
                client.BaseAddress = new Uri(apiSet.GetValue<string>($"BaseUrl") + path);
            }).AddHttpMessageHandler(() => new AuthorizationHandlerDelegated(new HttpContextAccessor()))
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddPolicyHandlers("PolicyConfig", configuration);




            // partner services

            services.AddHttpClient<IPartnerService, PartnerService>(client =>
            {
                var path = "partners";
                var apiSet = configuration.GetSection("DownstreamApi");
                client.BaseAddress = new Uri(apiSet.GetValue<string>("BaseUrl") + path);
            }).AddHttpMessageHandler((provider)=>new AuthorizationHandlerDelegated(provider.GetRequiredService<IHttpContextAccessor>()))
            //.ConfigurePrimaryHttpMessageHandler((provider) =>new AuthorizationCookieHandler(provider.GetRequiredService<IHttpContextAccessor>(),provider.GetRequiredService<IConfiguration>()))
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddPolicyHandlers("PolicyConfig", configuration);



            // Customer services

            services.AddHttpClient<ICustomerService, CustomerService>(client =>
            {
                var path = "customers";
                var apiSet = configuration.GetSection("DownstreamApi");
                client.BaseAddress = new Uri(apiSet.GetValue<string>("BaseUrl") + path);
            }).AddHttpMessageHandler((provider) => new AuthorizationHandlerDelegated(provider.GetRequiredService<IHttpContextAccessor>()))
         //.ConfigurePrimaryHttpMessageHandler((provider) =>new AuthorizationCookieHandler(provider.GetRequiredService<IHttpContextAccessor>(),provider.GetRequiredService<IConfiguration>()))
         .SetHandlerLifetime(TimeSpan.FromMinutes(5))
         .AddPolicyHandlers("PolicyConfig", configuration);



            //Stores    
            services.AddHttpClient<IStoreService, StoreService>(client =>
            {
                var path = "stores";
                var apiSet = configuration.GetSection("DownstreamApi");
                client.BaseAddress = new Uri(apiSet.GetValue<string>("BaseUrl") + path);
            }).AddHttpMessageHandler((provider) => new AuthorizationHandlerDelegated(provider.GetRequiredService<IHttpContextAccessor>()))
       //.ConfigurePrimaryHttpMessageHandler((provider) =>new AuthorizationCookieHandler(provider.GetRequiredService<IHttpContextAccessor>(),provider.GetRequiredService<IConfiguration>()))
       .SetHandlerLifetime(TimeSpan.FromMinutes(5))
       .AddPolicyHandlers("PolicyConfig", configuration);



            services.AddHttpClient<IOrderService, OrderService>(client =>
            {
                var path = "orders";
                var apiSet = configuration.GetSection("DownstreamApi");
                client.BaseAddress = new Uri(apiSet.GetValue<string>("baseurl") + path);
            }).AddHttpMessageHandler((provider)=> new AuthorizationHandlerDelegated(provider.GetRequiredService<IHttpContextAccessor>()))
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddPolicyHandlers("PolicyConfig", configuration);




            // product services

            services.AddHttpClient<IProductService, ProductService>(client =>
            {
                var path = "products";
                var apiSet = configuration.GetSection("DownstreamApi");
                client.BaseAddress = new Uri(apiSet.GetValue<string>($"BaseUrl") + path);
            }).AddHttpMessageHandler(() => new AuthorizationHandlerDelegated(new HttpContextAccessor()))
            .AddPolicyHandlers("PolicyConfig", configuration);


            return services;

        }



    }
}
