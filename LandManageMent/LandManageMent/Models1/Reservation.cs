using System;
using System.Collections.Generic;

namespace LandManageMent.Models1;

public partial class Reservation
{
    public int ResId { get; set; }

    public int OnerId { get; set; }

    public int AgencyId { get; set; }

    public int LandId { get; set; }

    public DateTime Date { get; set; }

    public virtual Agency Agency { get; set; }

    public virtual LandTable Land { get; set; }

    public virtual Oner Oner { get; set; }
}
