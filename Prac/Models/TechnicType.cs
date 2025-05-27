using System;
using System.Collections.Generic;

namespace Prac.Models1;

public partial class TechnicType
{
    public int TypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Technic> Technics { get; set; } = new List<Technic>();
}
