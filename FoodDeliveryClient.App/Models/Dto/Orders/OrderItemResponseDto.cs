namespace FoodDeliveryClient.App.Models.Dto.Orders
{
    public class BaseOrderItemDto
    {
        public long productId { get; set; }
        public int quantity { get; set; }
    }

    public class OrderItemRequestDto : BaseOrderItemDto
    {

    }

    public class OrderItemResponseDto : BaseOrderItemDto
    {
        public decimal totalPrice { get; set; }
        public long orderId { get; set; }
        public string productName { get; set; } = string.Empty;
        public decimal productPrice { get; set; }
    }
}
