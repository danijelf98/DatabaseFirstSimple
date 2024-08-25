using DatabaseFirst.Models.Dbo;

namespace DatabaseFirst.Models.Binding
{
    public class PersonBinding
    {

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Pin { get; set; }

        public int? PhoneNumber { get; set; }

        public virtual AddressBinding? Address { get; set; }
    }
    public class PersonUpdateBinding
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Pin { get; set; }

        public int? PhoneNumber { get; set; }

        public virtual AddressUpdateBinding? Address { get; set; }
    }
}
