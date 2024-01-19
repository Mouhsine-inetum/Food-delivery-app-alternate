using FoodDeliveryClient.App.Models.Dto.Products;
using FoodDeliveryClient.App.Models.Inputs.Products;

namespace FoodDeliveryClient.App.Services.Interfaces
{
    public interface IProductService
    {
        Task<IList<GetProductResponseDto>> GetProductsAsync();
        Task<CreateProductRequestDto> PostProductAsync(CreateProductRequestDto storeDto);
    }
}