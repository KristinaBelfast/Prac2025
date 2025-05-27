using System;
using System.Collections.Generic;

namespace Prac.Models1;

public partial class RentalAgreement
{
    public int AgreementId { get; set; }

    public int? OrderId { get; set; }

    public int? ClientId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Order? Order { get; set; }
}
