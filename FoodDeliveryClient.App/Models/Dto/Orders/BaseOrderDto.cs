using FoodDeliveryClient.App.Models.Dto.Stores;

namespace FoodDeliveryClient.App.Models.Dto.Orders
{
    public class BaseOrderDto<T>
    {
        public long storeId { get; set; }
        public List<T> items { get; set; } = new List<T>();
        public string address { get; set; } = string.Empty;
        public CoordinateDto coordinate { get; set; } = default!;
        public string paymentIntentId { get; set; } = string.Empty;
    }
}
