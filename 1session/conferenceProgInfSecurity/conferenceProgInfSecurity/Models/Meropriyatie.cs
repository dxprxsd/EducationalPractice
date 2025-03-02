using System;
using System.Collections.Generic;

namespace conferenceProgInfSecurity.Models;

public partial class Meropriyatie
{
    public int Meropriyatieid { get; set; }

    public string Meropriyatiename { get; set; } = null!;

    public DateTime Meropriyatiedate { get; set; }

    public int Cityid { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Meropriyatieandactivity> Meropriyatieandactivities { get; set; } = new List<Meropriyatieandactivity>();
}
