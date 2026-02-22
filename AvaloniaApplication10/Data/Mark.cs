using System;
using System.Collections.Generic;

namespace AvaloniaApplication10.Data;

public partial class Mark
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
