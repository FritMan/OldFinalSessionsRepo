using System;
using System.Collections.Generic;

namespace AvaloniaApplication10.Data;

public partial class Model
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int MarkId { get; set; }

    public virtual Mark Mark { get; set; } = null!;

    public virtual ICollection<Vending> VendingModelSlaves { get; set; } = new List<Vending>();

    public virtual ICollection<Vending> VendingModes { get; set; } = new List<Vending>();
}
