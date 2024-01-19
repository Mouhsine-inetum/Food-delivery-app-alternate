using FoodDeliveryClient.App.Models.Dto.Stores;
using FoodDeliveryClient.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodDeliveryClient.App.Pages.Stores
{
    public class IndexModel : PageModel
    {
        private readonly IStoreService _storeService;
        public IEnumerable<StoreDto> storeDtos;
        public IndexModel(IStoreService storeService)
        {
            _storeService = storeService;
        }
        public async Task OnGet()
        {
           storeDtos = await _storeService.GetStoresAsync();
        }
    }
}
