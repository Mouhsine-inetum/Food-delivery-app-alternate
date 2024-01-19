using FoodDeliveryClient.App.Models.Dto.Orders;
using FoodDeliveryClient.App.Models.Dto.Stores;
using FoodDeliveryClient.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodDeliveryClient.App.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        public IEnumerable<GetOrderResponseDto> orderDtos;
        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task OnGet()
        {
            orderDtos = new List<GetOrderResponseDto>();//await _orderService.GetOrdersAsync();
        }
    }
}
