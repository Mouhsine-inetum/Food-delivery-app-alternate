namespace FoodDeliveryClient.App.Models.Dto.Products
{
    public class BaseProductDto
    {
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}
