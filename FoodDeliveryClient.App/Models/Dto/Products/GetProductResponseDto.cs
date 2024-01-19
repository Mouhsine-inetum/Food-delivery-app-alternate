namespace FoodDeliveryClient.App.Models.Dto.Products
{
    public class GetProductResponseDto:BaseProductDto
    {
        public long id { get; set; }
        public long storeId { get; set; }
        public string? image { get; set; }
    }
}
