using System;
using System.Collections.Generic;

namespace conferenceProgInfSecurity.Models;

public partial class Jury
{
    public int Juryid { get; set; }

    public string Snamejury { get; set; } = null!;

    public string Namejury { get; set; } = null!;

    public string Patronymicjury { get; set; } = null!;

    public int Genderid { get; set; }

    public string? Email { get; set; }

    public DateTime? Dob { get; set; }

    public int? Countryid { get; set; }

    public string Phonenumber { get; set; } = null!;

    public int? Directionsid { get; set; }

    public string Password { get; set; } = null!;

    public string? Photo { get; set; }

    public virtual Country? Country { get; set; }

    public virtual Direction? Directions { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<Meropriyatieandactivity> MeropriyatieandactivityFifthjuryNavigations { get; set; } = new List<Meropriyatieandactivity>();

    public virtual ICollection<Meropriyatieandactivity> MeropriyatieandactivityFirstjuryNavigations { get; set; } = new List<Meropriyatieandactivity>();

    public virtual ICollection<Meropriyatieandactivity> MeropriyatieandactivityFourthjuryNavigations { get; set; } = new List<Meropriyatieandactivity>();

    public virtual ICollection<Meropriyatieandactivity> MeropriyatieandactivitySecondjuryNavigations { get; set; } = new List<Meropriyatieandactivity>();

    public virtual ICollection<Meropriyatieandactivity> MeropriyatieandactivityThirdjuryNavigations { get; set; } = new List<Meropriyatieandactivity>();
}
