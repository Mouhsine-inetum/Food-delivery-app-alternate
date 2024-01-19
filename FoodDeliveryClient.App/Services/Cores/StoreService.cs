using FoodDeliveryClient.App.Models.Dto.Stores;
using FoodDeliveryClient.App.Models.Inputs.Stores;
using FoodDeliveryClient.App.Services.Interfaces;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace FoodDeliveryClient.App.Services.Cores
{
    public class StoreService: IStoreService
    {
        private readonly HttpClient _httpClient;

        public StoreService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }


        public async Task<IList<StoreDto>> GetStoresAsync()
        {
            List<StoreDto> stores = new();
            var data = await _httpClient.GetAsync("");
            var rawdata = await data.Content.ReadAsStringAsync();
            stores = JsonSerializer.Deserialize<List<StoreDto>>(rawdata);
            return await Task.FromResult(stores);
        }

        public async Task<CreateStoreDto> PostStoreAsync(CreateStoreDto storeDto)
        {
            var JsonData = JsonSerializer.Serialize(storeDto);
            var data = await _httpClient.PostAsync("", new StringContent(JsonData, Encoding.Default, "application/json"));
            var rawdata = await data.Content.ReadAsStringAsync();
            CreateStoreDto store = JsonSerializer.Deserialize<CreateStoreDto>(rawdata);
            return store;
        }
    }
}
