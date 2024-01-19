using FoodDeliveryClient.App.Models.Dto.Orders;
using FoodDeliveryClient.App.Models.Dto.Products;
using FoodDeliveryClient.App.Models.Dto.Stores;
using FoodDeliveryClient.App.Models.Inputs.Orders;
using FoodDeliveryClient.App.Models.Inputs.Stores;
using FoodDeliveryClient.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodDeliveryClient.App.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;
        private List<OrderItemResponseDto> items;
        private IList<GetProductResponseDto> products;
        public StoreDto storeDto;
        public GetProductResponseDto product;
        private readonly Random random = new Random(1);
        private int quanityOrderedByItem;
        public CreateModel(IOrderService orderService,IProductService productService,IStoreService storeService)
        {
            items = new List<OrderItemResponseDto>();
            _orderService = orderService;
            _productService = productService;
            _storeService = storeService;
            quanityOrderedByItem=random.Next(100);
        }
        public async Task OnGet()
        {
            products = await _productService.GetProductsAsync();
            var stores =await _storeService.GetStoresAsync();
            await GetInfos(stores);
        }

        private Task GetInfos(IList<StoreDto> stores)
        {
            product = products[0];
            storeDto = stores.SingleOrDefault(t => t.id == product.storeId);
            return Task.CompletedTask;
        }

        private async Task FillItemList()
        {
            products = await _productService.GetProductsAsync();
            product = products[0];
            decimal priceTotal =await GetPriceAync();
            items.Add(new OrderItemResponseDto()
            {
                productId = product.id,
                productName = product.name,
                productPrice = product.price,
                quantity = quanityOrderedByItem,
                totalPrice = priceTotal

            });
        }

        public Task<decimal> GetPriceAync()
        {
            return Task.FromResult(quanityOrderedByItem * product.price);
        }

        public async Task OnPost(CreateOrderRequestDto createOrderRequest)
        {
            await FillItemList();
            createOrderRequest.items = items;
            createOrderRequest.coordinate = new CoordinateDto()
            {
                x = 12,
                y = 26
            };
            CreateOrderRequestDto result = await _orderService.PostOrderAsync(createOrderRequest);
        }
    }
}
