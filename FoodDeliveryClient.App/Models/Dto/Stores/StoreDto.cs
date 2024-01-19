namespace FoodDeliveryClient.App.Models.Dto.Stores
{
    public class StoreDto :BaseDto
    {

        public long id { get; set; }
        public long partnerId { get; set; }
        public string? image { get; set; }

    }
}
