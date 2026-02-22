using System;
using System.Collections.Generic;

namespace AvaloniaApplication10.Data;

public partial class Productsinvending
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int VendingId { get; set; }

    public int MinValue { get; set; }

    public int Value { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Vending Vending { get; set; } = null!;
}
