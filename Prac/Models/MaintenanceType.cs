using System;
using System.Collections.Generic;

namespace Prac.Models;

public partial class MaintenanceType
{
    public int MaintenanceTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();
}
