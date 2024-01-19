using Polly.Extensions.Http;
using Polly;

namespace FoodDeliveryClient.App.Common.Policy.RetryPolicy
{

    public static class HttpPolicyBuilders
    {
        public static PolicyBuilder<HttpResponseMessage> GetBaseBuilder()
        {
            return HttpPolicyExtensions.HandleTransientHttpError();
        }
    }
}
