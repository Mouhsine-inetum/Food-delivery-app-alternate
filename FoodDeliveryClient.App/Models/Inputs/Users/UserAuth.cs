namespace FoodDeliveryClient.App.Models.Inputs.Users
{
    public class UserAuth
    {
        public int GrantType { get; set; }
        public int? UserType { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? RefreshToken { get; set; }
    }
}
