using System;
using System.Collections.Generic;

namespace AvaloniaApplication10.Data;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Cost { get; set; }

    public virtual ICollection<Productsinvending> Productsinvendings { get; set; } = new List<Productsinvending>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
