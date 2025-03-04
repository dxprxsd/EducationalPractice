using System;
using System.Collections.Generic;

namespace conferenceProgInfSecurity.Models;

public partial class Direction
{
    public int Iddirections { get; set; }

    public string Directionname { get; set; } = null!;

    public virtual ICollection<Jury> Juries { get; set; } = new List<Jury>();

    public virtual ICollection<Meropriyatie> Meropriyaties { get; set; } = new List<Meropriyatie>();

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();
}
