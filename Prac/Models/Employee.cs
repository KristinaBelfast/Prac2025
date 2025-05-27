using System;
using System.Collections.Generic;

namespace Prac.Models1;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int RoleId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

    public virtual RentalAgreement? RentalAgreement { get; set; }

    public virtual Role Role { get; set; } = null!;
}
