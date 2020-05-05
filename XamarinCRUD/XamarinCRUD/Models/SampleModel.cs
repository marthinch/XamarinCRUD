using SQLite;

namespace XamarinCRUD.Models
{
    public class SampleModel
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
