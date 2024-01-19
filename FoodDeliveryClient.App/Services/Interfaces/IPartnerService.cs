using FoodDeliveryClient.App.Models.Dto.Users;
using FoodDeliveryClient.App.Models.Inputs.Users;

namespace FoodDeliveryClient.App.Services.Interfaces
{
    public interface IPartnerService
    {
        Task<IList<PartnersDto>> GetPartnersAsync();
        Task<PartnersDto> GetPartnerAsync(string id);
        Task<bool> PostPartnerAsync(string path,Partner resource);
        Task<bool> DeletePartnerAsync(string id);


    }
}
