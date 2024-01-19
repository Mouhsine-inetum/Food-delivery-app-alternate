using FoodDeliveryClient.App.Common.Policy.Config;
using FoodDeliveryClient.App.Common.Policy.RetryPolicy;
using Polly.CircuitBreaker;
using Polly;

namespace FoodDeliveryClient.App.Common.Policy.CircuitBreaker
{
    public class HttpCircuitBreakerPolicies
    {
        public static AsyncCircuitBreakerPolicy<HttpResponseMessage> GetHttpCircuitBreakerPolicy(ICircuitBreakerPolicyConfig circuitBreakerPolicyConfig)
        {
            return HttpPolicyBuilders.GetBaseBuilder()
                                      .CircuitBreakerAsync(circuitBreakerPolicyConfig.RetryCount + 1,
                                                           TimeSpan.FromSeconds(circuitBreakerPolicyConfig.BreakDuration),
                                                           (result, breakDuration) =>
                                                           {
                                                               OnHttpBreak(result, breakDuration, circuitBreakerPolicyConfig.RetryCount);
                                                           },
                                                           () =>
                                                           {
                                                               OnHttpReset();
                                                           });
        }

        public static void OnHttpBreak(DelegateResult<HttpResponseMessage> result, TimeSpan breakDuration, int retryCount)
        {
            throw new BrokenCircuitException("Service inoperative. Please try again later");
        }

        public static void OnHttpReset()
        {
           
        }
    }
}
