using System;
using System.Collections.Generic;

namespace LandManageMent.Models1;

public partial class Oner
{
    public int OnerId { get; set; }

    public string OnerName { get; set; }

    public DateTime? Dob { get; set; }

    public string Phone { get; set; }

    public int LandId { get; set; }

    public virtual LandTable Land { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
