using System;
using System.Collections.Generic;

namespace conferenceProgInfSecurity.Models;

public partial class City
{
    public int Idcity { get; set; }

    public string Cityname { get; set; } = null!;

    public string Cityimage { get; set; } = null!;

    public virtual ICollection<Meropriyatie> Meropriyaties { get; set; } = new List<Meropriyatie>();
}
