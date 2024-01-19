namespace FoodDeliveryClient.App.Models.Inputs.Users
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        public string? ImagePublicId { get; set; } = string.Empty;
    }
}
