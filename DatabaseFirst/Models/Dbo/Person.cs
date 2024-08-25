using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models.Dbo;

public partial class Person
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Pin { get; set; }

    public int? PhoneNumber { get; set; }

    public int? AddressId { get; set; }

    public virtual Address? Address { get; set; }
}
