using System.Text.Json;
using System.Text.Json.Serialization;

namespace FoodDeliveryClient.App.Factory
{
    public class FactoryCall<T> : IFactoryCall<T>
    {
        private HttpClient _httpClient;
        public FactoryCall(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }


        public async Task<IList<T>> GetAsync(string resource)
        {
            IList<T> result = new List<T>();
            var data = await _httpClient.GetAsync(resource);
            var rawData = await data.Content.ReadAsStringAsync() ?? throw new NullReferenceException();
            result = JsonSerializer.Deserialize<IList<T>>(rawData);
            return await Task.FromResult(result);
        }

        public async Task<T> GetIdAsync(string resource)
        {
            var data = await _httpClient.GetAsync(resource);
            var rawData = await data.Content.ReadAsStringAsync() ?? throw new NullReferenceException();
            T result = JsonSerializer.Deserialize<T>(rawData);
            return await Task.FromResult(result);
        }

        public async Task<bool> PostAsync(string path, T resource)
        {
            var data = await _httpClient.PostAsJsonAsync(path, resource);
            var success = data.IsSuccessStatusCode;
            return await Task.FromResult(success);
        }

        public async Task<bool> DeleteAsync(string resource)
        {
            var data = await _httpClient.DeleteAsync(resource);
            var success = data.IsSuccessStatusCode;
            return await Task.FromResult(success);
        }
    }
}
