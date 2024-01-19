namespace FoodDeliveryClient.App.Models.Dto.Users
{
    public class CustomersDto : UserDto
    {
        public string address { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string postalCode { get; set; } = string.Empty;
    }
}
