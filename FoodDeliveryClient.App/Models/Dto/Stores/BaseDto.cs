namespace FoodDeliveryClient.App.Models.Dto.Stores
{
    public class BaseDto
    {
        public string name { get; set; } = string.Empty;
        public string? description { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string postalCode { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public int deliveryTimeInMinutes { get; set; }
        public decimal deliveryFee { get; set; } = decimal.Zero;
        public string category { get; set; } = string.Empty;
        public List<CoordinateDto> Coordinates { get; set; } = default!;
    }
}
