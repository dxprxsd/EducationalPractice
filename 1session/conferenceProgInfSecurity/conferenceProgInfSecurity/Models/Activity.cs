using System;
using System.Collections.Generic;

namespace conferenceProgInfSecurity.Models;

public partial class Activity
{
    public int Activitiesid { get; set; }

    public string Activitiesname { get; set; } = null!;

    public virtual ICollection<Meropriyatieandactivity> Meropriyatieandactivities { get; set; } = new List<Meropriyatieandactivity>();
}
