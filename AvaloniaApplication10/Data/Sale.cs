using System;
using System.Collections.Generic;

namespace AvaloniaApplication10.Data;

public partial class Sale
{
    public int Id { get; set; }

    public int VenId { get; set; }

    public int ProductId { get; set; }

    public int Value { get; set; }

    public DateTime DatetimeSale { get; set; }

    public int PaymentId { get; set; }

    public virtual Payment Payment { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Vending Ven { get; set; } = null!;
}
