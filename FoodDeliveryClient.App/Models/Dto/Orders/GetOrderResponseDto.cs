using FoodDeliveryClient.App.Models.Dto.Stores;

namespace FoodDeliveryClient.App.Models.Dto.Orders
{
    public class GetOrderResponseDto:BaseOrderDto<GetOrderItemResponseDto>
    {
        public long id { get; set; }
        public DateTime createdAt { get; set; } = default!;
        public long customerId { get; set; }
        public decimal itemsPrice { get; set; }
        public decimal deliveryFee { get; set; }
        public decimal totalPrice { get; set; }
        public StoreDto store { get; set; } = default!;
        public OrderStatus orderStatus { get; set; }
    }
    public enum OrderStatus
    {
        Pending = 0,
        Canceled = 1,
        Completed = 2,
    }
}
