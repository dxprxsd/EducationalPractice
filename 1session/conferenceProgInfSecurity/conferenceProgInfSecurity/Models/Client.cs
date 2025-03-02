using System;
using System.Collections.Generic;

namespace conferenceProgInfSecurity.Models;

public partial class Client
{
    public int Idclient { get; set; }

    public string Snameclient { get; set; } = null!;

    public string Nameclient { get; set; } = null!;

    public string Patronymicclient { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime Dob { get; set; }

    public int Countryid { get; set; }

    public string Phonenumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public int Genderid { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<Meropriyatieandactivity> Meropriyatieandactivities { get; set; } = new List<Meropriyatieandactivity>();
}
