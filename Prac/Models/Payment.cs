using System;
using System.Collections.Generic;

namespace Prac.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public int? PaymentMethodId { get; set; }

    public DateOnly PaymentDate { get; set; }

    public int StatusId { get; set; }

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual StatusPayment Status { get; set; } = null!;
}
