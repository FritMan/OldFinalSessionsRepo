using System;
using System.Collections.Generic;

namespace AvaloniaApplication10.Data;

public partial class Service
{
    public int Id { get; set; }

    public int VendingId { get; set; }

    public DateTime DateTimeService { get; set; }

    public string Description { get; set; } = null!;

    public string DescriptionError { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual Vending Vending { get; set; } = null!;
}
