using static System.Formats.Asn1.AsnWriter;

namespace FoodDeliveryClient.App.Models.Dto.Users
{
    public class PartnersDto : UserDto
    {
        public PartnerStatus status { get; set; }
        //public List<StoreDto> Stores { get; set; } = new List<StoreDto>();
    }

    public enum PartnerStatus
    {
        Pending = 0,
        Rejected = 1,
        Accepted = 2,
        Suspended = 3,
    }
}
