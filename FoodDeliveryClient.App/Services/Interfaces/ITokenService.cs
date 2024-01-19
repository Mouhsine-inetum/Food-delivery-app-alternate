using FoodDeliveryClient.App.Models.Inputs;

namespace FoodDeliveryClient.App.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetToken();
    }
}
