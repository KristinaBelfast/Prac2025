using System;
using System.Collections.Generic;

namespace Prac.Models1;

public partial class StatusPayment
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
