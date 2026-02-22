using System;
using System.Collections.Generic;

namespace AvaloniaApplication10.Data;

public partial class Paymentandvending
{
    public int Id { get; set; }

    public int VendingId { get; set; }

    public int PaymentId { get; set; }

    public virtual Payment Payment { get; set; } = null!;

    public virtual Vending Vending { get; set; } = null!;
}
