using FoodDeliveryClient.App.Models.Inputs.Users;
using FoodDeliveryClient.App.Services.Interfaces;
using System.Net.Http;

namespace FoodDeliveryClient.App.Services.Cores
{
    public class AdminService : IAdminService
    {

        private HttpClient _httpClient;
        public AdminService(HttpClient httpClientFactory)
        {
            _httpClient = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<bool> PostAsync(string path, Admin resource)
        {
            var data = await _httpClient.PostAsJsonAsync(path, resource);
            var success = data.IsSuccessStatusCode;
            return await Task.FromResult(success);
        }
    }
}
