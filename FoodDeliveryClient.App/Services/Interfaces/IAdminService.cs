using FoodDeliveryClient.App.Models.Inputs.Users;

namespace FoodDeliveryClient.App.Services.Interfaces
{
    public interface IAdminService
    {
       Task<bool> PostAsync(string path, Admin resource);
    }
}
