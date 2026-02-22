using System;
using System.Collections.Generic;

namespace AvaloniaApplication10.Data;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronimic { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RoleId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<Vending> VendingClients { get; set; } = new List<Vending>();

    public virtual ICollection<Vending> VendingEngineers { get; set; } = new List<Vending>();

    public virtual ICollection<Vending> VendingManagers { get; set; } = new List<Vending>();

    public virtual ICollection<Vending> VendingTechnicians { get; set; } = new List<Vending>();
}
