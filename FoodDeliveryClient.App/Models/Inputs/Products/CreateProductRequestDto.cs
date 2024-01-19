using FoodDeliveryClient.App.Models.Dto.Products;

namespace FoodDeliveryClient.App.Models.Inputs.Products
{
    public class CreateProductRequestDto: BaseProductDto
    {
        public long storeId { get; set; }

    }
}
