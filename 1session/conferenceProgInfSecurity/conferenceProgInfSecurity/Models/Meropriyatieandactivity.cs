using System;
using System.Collections.Generic;

namespace conferenceProgInfSecurity.Models;

public partial class Meropriyatieandactivity
{
    public int Meropriyatieandactivitiesid { get; set; }

    public int Idmeropriyatie { get; set; }

    public DateTime Startdate { get; set; }

    public int Dayscount { get; set; }

    public int Idactivities { get; set; }

    public int Numberday { get; set; }

    public TimeOnly Timestart { get; set; }

    public int Idmoderator { get; set; }

    public int? Firstjury { get; set; }

    public int? Secondjury { get; set; }

    public int? Thirdjury { get; set; }

    public int? Fourthjury { get; set; }

    public int? Fifthjury { get; set; }

    public int Winnerid { get; set; }

    public virtual Jury? FifthjuryNavigation { get; set; }

    public virtual Jury? FirstjuryNavigation { get; set; }

    public virtual Jury? FourthjuryNavigation { get; set; }

    public virtual Activity IdactivitiesNavigation { get; set; } = null!;

    public virtual Meropriyatie IdmeropriyatieNavigation { get; set; } = null!;

    public virtual Moderator IdmoderatorNavigation { get; set; } = null!;

    public virtual Jury? SecondjuryNavigation { get; set; }

    public virtual Jury? ThirdjuryNavigation { get; set; }

    public virtual Client Winner { get; set; } = null!;
}
