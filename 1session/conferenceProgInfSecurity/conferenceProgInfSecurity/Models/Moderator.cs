using System;
using System.Collections.Generic;

namespace conferenceProgInfSecurity.Models;

public partial class Moderator
{
    public int Moderatorid { get; set; }

    public string Snamemoderator { get; set; } = null!;

    public string Namemoderator { get; set; } = null!;

    public string Patronymicmoderator { get; set; } = null!;

    public int Genderid { get; set; }

    public string Email { get; set; } = null!;

    public DateTime Dob { get; set; }

    public int Countryid { get; set; }

    public string Phonenumber { get; set; } = null!;

    public int Directionsid { get; set; }

    public int Sobitieid { get; set; }

    public string Password { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual Direction Directions { get; set; } = null!;

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<Meropriyatieandactivity> Meropriyatieandactivities { get; set; } = new List<Meropriyatieandactivity>();

    public virtual Sobitie Sobitie { get; set; } = null!;
}
