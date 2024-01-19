using FoodDeliveryClient.App.Common.Policy.CircuitBreaker;
using FoodDeliveryClient.App.Common.Policy.Config;
using FoodDeliveryClient.App.Common.Policy.RetryPolicy;

namespace FoodDeliveryClient.App.Common.Policy
{
    public static class HttpClientBuilderExtensions
    {
        public static IHttpClientBuilder AddPolicyHandlers(this IHttpClientBuilder httpClientBuilder, string policySectionName, IConfiguration configuration)
        {


            var policyConfig = new PolicyConfig();
            configuration.Bind(policySectionName, policyConfig);

            var circuitBreakerPolicyConfig = (ICircuitBreakerPolicyConfig)policyConfig;
            var retryPolicyConfig = (IRetryPolicyConfig)policyConfig;

            return httpClientBuilder.AddRetryPolicyHandler(retryPolicyConfig)
                                    .AddCircuitBreakerHandler( circuitBreakerPolicyConfig);
        }

        public static IHttpClientBuilder AddRetryPolicyHandler(this IHttpClientBuilder httpClientBuilder, IRetryPolicyConfig retryPolicyConfig)
        {
            return httpClientBuilder.AddPolicyHandler(HttpRetryPolicies.GetHttpRetryPolicy(retryPolicyConfig));
        }

        public static IHttpClientBuilder AddCircuitBreakerHandler(this IHttpClientBuilder httpClientBuilder, ICircuitBreakerPolicyConfig circuitBreakerPolicyConfig)
        {
            return httpClientBuilder.AddPolicyHandler(HttpCircuitBreakerPolicies.GetHttpCircuitBreakerPolicy(circuitBreakerPolicyConfig));
        }
    }
}
