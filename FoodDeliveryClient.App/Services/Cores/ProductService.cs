using FoodDeliveryClient.App.Models.Dto.Orders;
using FoodDeliveryClient.App.Models.Dto.Products;
using FoodDeliveryClient.App.Models.Inputs.Orders;
using FoodDeliveryClient.App.Models.Inputs.Products;
using FoodDeliveryClient.App.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace FoodDeliveryClient.App.Services.Cores
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }


        public async Task<IList<GetProductResponseDto>> GetProductsAsync()
        {
            List<GetProductResponseDto> stores = new();
            var data = await _httpClient.GetAsync("");
            var rawdata = await data.Content.ReadAsStringAsync();
            stores = JsonSerializer.Deserialize<List<GetProductResponseDto>>(rawdata);
            return await Task.FromResult(stores);
        }

        public async Task<CreateProductRequestDto> PostProductAsync(CreateProductRequestDto storeDto)
        {
            var JsonData = JsonSerializer.Serialize(storeDto);
            var data = await _httpClient.PostAsync("", new StringContent(JsonData, Encoding.Default, "application/json"));
            var rawdata = await data.Content.ReadAsStringAsync();
            CreateProductRequestDto store = JsonSerializer.Deserialize<CreateProductRequestDto>(rawdata);
            return store;
        }
    }
}
