using FoodDeliveryClient.App.Models.Dto.Users;
using FoodDeliveryClient.App.Services.Interfaces;
using System.Net.Http;
using System.Text.Json;

namespace FoodDeliveryClient.App.Services.Cores
{
    public class CustomerService: ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }


        public async Task<IList<CustomersDto>> GetCustomersAsync()
        {
            List<CustomersDto> partners = new();
            var data = await _httpClient.GetAsync("");
            var rawdata = await data.Content.ReadAsStringAsync();
            partners = JsonSerializer.Deserialize<List<CustomersDto>>(rawdata);
            return await Task.FromResult(partners);
        }

    }
}
