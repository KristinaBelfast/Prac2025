using System;
using System.Collections.Generic;

namespace Prac.Models1;

public partial class MaintenanceRecord
{
    public int RecordId { get; set; }

    public int? TechnicId { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly DatePerformed { get; set; }

    public string? Notes { get; set; }

    public int? MaintenanceTypeId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual MaintenanceType? MaintenanceType { get; set; }

    public virtual Technic? Technic { get; set; }
}
