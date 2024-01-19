using FoodDeliveryClient.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodDeliveryClient.App.Models.Inputs.Users;

namespace FoodDeliveryClient.App.Pages.Admins
{
    public class CreateModel : PageModel
    {
        private readonly IAdminService _adminService;
        public CreateModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public void OnGet()
        {
           
        }

        public async Task OnPostAsync(Admin admin)
        {
            await _adminService.PostAsync("admins", admin);
        }
    }
}
