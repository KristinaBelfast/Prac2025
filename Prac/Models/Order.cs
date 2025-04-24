using System;
using System.Collections.Generic;

namespace Prac.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int ClientId { get; set; }

    public int TechnicId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal TotalCost { get; set; }

    public int StatusId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual Technic Technic { get; set; } = null!;
}
