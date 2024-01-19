using FoodDeliveryClient.App.Models.Dto.Orders;
using FoodDeliveryClient.App.Models.Dto.Stores;
using FoodDeliveryClient.App.Models.Inputs.Orders;
using FoodDeliveryClient.App.Models.Inputs.Stores;

namespace FoodDeliveryClient.App.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IList<GetOrderResponseDto>> GetOrdersAsync();
        Task<CreateOrderRequestDto> PostOrderAsync(CreateOrderRequestDto storeDto);
    }
}