using FoodDeliveryClient.App.Common.Policy.Config;
using Polly.Retry;
using Polly;

namespace FoodDeliveryClient.App.Common.Policy.RetryPolicy
{
    public static class HttpRetryPolicies
    {
        public static AsyncRetryPolicy<HttpResponseMessage> GetHttpRetryPolicy(IRetryPolicyConfig retryPolicyConfig)
        {
            return HttpPolicyBuilders.GetBaseBuilder()
                                          .WaitAndRetryAsync(retryPolicyConfig.RetryCount,
                                                             ComputeDuration,
                                                             (result, timeSpan, retryCount, context) =>
                                                             {
                                                                 OnHttpRetry(result, timeSpan, retryCount, context);
                                                             });
        }

        private static void OnHttpRetry(DelegateResult<HttpResponseMessage> result, TimeSpan timeSpan, int retryCount, Polly.Context context)
        {
            
        }

        private static TimeSpan ComputeDuration(int input)
        {
            return TimeSpan.FromSeconds(Math.Pow(2, input)) + TimeSpan.FromMilliseconds(new Random().Next(0, 100));
        }
    }
}
