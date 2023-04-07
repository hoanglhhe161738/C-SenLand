using System;
using System.Collections.Generic;

namespace LandManageMent.Models1;

public partial class Agency
{
    public int AgencyId { get; set; }

    public string AgencyName { get; set; }

    public string AgencyPhone { get; set; }

    public bool Gender { get; set; }

    public string Password { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
