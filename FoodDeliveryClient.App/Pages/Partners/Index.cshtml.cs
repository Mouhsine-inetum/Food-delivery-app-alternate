using FoodDeliveryClient.App.Models.Dto.Users;
using FoodDeliveryClient.App.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Web;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FoodDeliveryClient.App.Pages.Partners
{
    public class PartnersIndexModel : PageModel
    {
        private readonly IPartnerService _partnerService;
        public  IEnumerable<PartnersDto> partnersDto; 
        public PartnersIndexModel(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }
        public async Task OnGet()
        {
            partnersDto=await _partnerService.GetPartnersAsync();
        }
    }
}
