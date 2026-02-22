using System;
using System.Collections.Generic;

namespace AvaloniaApplication10.Data;

public partial class Vending
{
    public int Id { get; set; }

    public string Address { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime DateInstall { get; set; }

    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public int ModeId { get; set; }

    public int? ModelSlaveId { get; set; }

    public string? Width { get; set; }

    public string Num { get; set; } = null!;

    public string? TimeWork { get; set; }

    public int TimeZoneId { get; set; }

    public int MatrixId { get; set; }

    public int? PatternCritValueId { get; set; }

    public int? PatternNotificationsId { get; set; }

    public int? ClientId { get; set; }

    public int? ManagerId { get; set; }

    public int? EngineerId { get; set; }

    public int? TechnicianId { get; set; }

    public string? RfidServ { get; set; }

    public string? RfidIncas { get; set; }

    public string? RfidDownload { get; set; }

    public int? KitOnlineId { get; set; }

    public int ServPriorityId { get; set; }

    public string Modem { get; set; } = null!;

    public string? Longitude { get; set; }

    public virtual User? Client { get; set; }

    public virtual User? Engineer { get; set; }

    public virtual User? Manager { get; set; }

    public virtual Matrix Matrix { get; set; } = null!;

    public virtual Model Mode { get; set; } = null!;

    public virtual Model? ModelSlave { get; set; }

    public virtual Pattercritical? PatternCritValue { get; set; }

    public virtual Patternnotification? PatternNotifications { get; set; }

    public virtual ICollection<Paymentandvending> Paymentandvendings { get; set; } = new List<Paymentandvending>();

    public virtual ICollection<Productsinvending> Productsinvendings { get; set; } = new List<Productsinvending>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual Servicepriority ServPriority { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual Statusvending Status { get; set; } = null!;

    public virtual User? Technician { get; set; }

    public virtual Timezone TimeZone { get; set; } = null!;
}
