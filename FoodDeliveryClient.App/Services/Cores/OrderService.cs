using FoodDeliveryClient.App.Models.Dto.Orders;
using FoodDeliveryClient.App.Models.Dto.Stores;
using FoodDeliveryClient.App.Models.Inputs.Orders;
using FoodDeliveryClient.App.Models.Inputs.Stores;
using FoodDeliveryClient.App.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace FoodDeliveryClient.App.Services.Cores
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }


        public async Task<IList<GetOrderResponseDto>> GetOrdersAsync()
        {
            List<GetOrderResponseDto> stores = new();
            var data = await _httpClient.GetAsync("");
            var rawdata = await data.Content.ReadAsStringAsync();
            stores = JsonSerializer.Deserialize<List<GetOrderResponseDto>>(rawdata);
            return await Task.FromResult(stores);
        }

        public async Task<CreateOrderRequestDto> PostOrderAsync(CreateOrderRequestDto storeDto)
        {
            var JsonData = JsonSerializer.Serialize(storeDto);
            var data = await _httpClient.PostAsync("", new StringContent(JsonData, Encoding.Default, "application/json"));
            var rawdata = await data.Content.ReadAsStringAsync();
            CreateOrderRequestDto store = JsonSerializer.Deserialize<CreateOrderRequestDto>(rawdata);
            return store;
        }

    }
}
