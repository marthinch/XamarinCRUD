using SQLite;

namespace XamarinCRUD.Models
{
    public class Booking
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
