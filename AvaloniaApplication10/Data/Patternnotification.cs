using System;
using System.Collections.Generic;

namespace AvaloniaApplication10.Data;

public partial class Patternnotification
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Vending> Vendings { get; set; } = new List<Vending>();
}
