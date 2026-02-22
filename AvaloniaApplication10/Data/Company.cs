using System;
using System.Collections.Generic;

namespace AvaloniaApplication10.Data;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string SiteAddress { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int UserId { get; set; }

    public string? Status { get; set; }

    public virtual User User { get; set; } = null!;
}
