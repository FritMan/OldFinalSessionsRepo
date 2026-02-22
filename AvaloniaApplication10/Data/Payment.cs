using System;
using System.Collections.Generic;

namespace AvaloniaApplication10.Data;

public partial class Payment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Paymentandvending> Paymentandvendings { get; set; } = new List<Paymentandvending>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
