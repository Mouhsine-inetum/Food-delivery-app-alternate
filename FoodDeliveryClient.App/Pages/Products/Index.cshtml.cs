using FoodDeliveryClient.App.Models.Dto.Products;
using FoodDeliveryClient.App.Models.Dto.Stores;
using FoodDeliveryClient.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodDeliveryClient.App.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        public IEnumerable<GetProductResponseDto> productDtos;

        public IndexModel(IProductService productService)
        {
          _productService = productService;
        }
        public async Task OnGet()
        {
            productDtos = await _productService.GetProductsAsync();
        }

    }
}
