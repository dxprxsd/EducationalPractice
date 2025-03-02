using System;
using System.Collections.Generic;

namespace conferenceProgInfSecurity.Models;

public partial class Organizer
{
    public int Idorganizer { get; set; }

    public string Snameorganizer { get; set; } = null!;

    public string Nameorganizer { get; set; } = null!;

    public string Patronymicorganizer { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime Dob { get; set; }

    public int Countryid { get; set; }

    public string Phonenumber { get; set; } = null!;

    public string? Password { get; set; }

    public string Photo { get; set; } = null!;

    public int? Genderid { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual Gender? Gender { get; set; }
}
