using System;
using System.Collections.Generic;

namespace LandManageMent.Models1;

public partial class LandTable
{
    public int LandId { get; set; }

    public string LandName { get; set; }

    public string Location { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Oner> Oners { get; } = new List<Oner>();

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
