using FoodDeliveryClient.App.Models.Dto.Stores;
using FoodDeliveryClient.App.Models.Inputs.Stores;

namespace FoodDeliveryClient.App.Services.Interfaces
{
    public interface IStoreService
    {
        Task<IList<StoreDto>> GetStoresAsync();
        Task<CreateStoreDto> PostStoreAsync(CreateStoreDto storeDto);

    }
}
