using DatabaseFirst.Models.Dbo;

namespace DatabaseFirst.Models.ViewModel
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Pin { get; set; }

        public int? PhoneNumber { get; set; }

        public int? AddressId { get; set; }
        public virtual AddressViewModel? Address { get; set; }
    }
}
