using FoodDeliveryClient.App.Models.Dto.Users;
using FoodDeliveryClient.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodDeliveryClient.App.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _customerService;
        public IEnumerable<CustomersDto> customersDto;
        public IndexModel(ICustomerService partnerService)
        {
            _customerService = partnerService;
        }
        public async Task OnGet()
        {
            customersDto = await _customerService.GetCustomersAsync();
        }
    }
}
