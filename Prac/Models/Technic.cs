using System;
using System.Collections.Generic;

namespace Prac.Models;

public partial class Technic
{
    public int TechnicId { get; set; }

    public int? ManufactureYear { get; set; }

    public int? AvailabilityId { get; set; }

    public int TypeId { get; set; }

    public virtual Availability? Availability { get; set; }

    public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual TechnicType Type { get; set; } = null!;
}
