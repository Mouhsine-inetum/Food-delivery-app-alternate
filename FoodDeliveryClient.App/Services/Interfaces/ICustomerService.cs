using FoodDeliveryClient.App.Models.Dto.Users;

namespace FoodDeliveryClient.App.Services.Interfaces
{
    public interface ICustomerService
    {
         Task<IList<CustomersDto>> GetCustomersAsync();
    }
}
