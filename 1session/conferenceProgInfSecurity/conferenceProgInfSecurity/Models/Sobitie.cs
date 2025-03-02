using System;
using System.Collections.Generic;

namespace conferenceProgInfSecurity.Models;

public partial class Sobitie
{
    public int Idsobitie { get; set; }

    public string Sobitiename { get; set; } = null!;

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();
}
