using Newtonsoft.Json;

namespace FoodDeliveryClient.App.Models.Dto.Users
{
    public class UserDto
    {

        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int userType { get; set; }
        public object image { get; set; }
    }

    public enum UserType
    {
        Customer = 0,
        Partner = 1,
        Admin = 2
    }
}
