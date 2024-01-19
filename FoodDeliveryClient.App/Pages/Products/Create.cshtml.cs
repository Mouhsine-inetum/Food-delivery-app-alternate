using FoodDeliveryClient.App.Models.Dto.Stores;
using FoodDeliveryClient.App.Models.Inputs.Products;
using FoodDeliveryClient.App.Models.Inputs.Stores;
using FoodDeliveryClient.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodDeliveryClient.App.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        public CreateModel(IProductService productService)
        {
            _productService = productService;
        }
        public void OnGet()
        {

        }


        public async Task OnPost(CreateProductRequestDto createProductDto)
        {
            CreateProductRequestDto result = await _productService.PostProductAsync(createProductDto);
        }
    }
}
