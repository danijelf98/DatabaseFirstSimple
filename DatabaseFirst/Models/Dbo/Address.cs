using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models.Dbo;

public partial class Address
{
    public int Id { get; set; }

    public string? HouseNumber { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
