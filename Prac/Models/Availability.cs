using System;
using System.Collections.Generic;

namespace Prac.Models;

public partial class Availability
{
    public int AvailabilityId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Technic> Technics { get; set; } = new List<Technic>();
}
