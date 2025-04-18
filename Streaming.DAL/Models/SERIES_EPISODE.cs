using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("SERIES_EPISODE")]
public partial class SERIES_EPISODE
{
    [Key]
    public int ID_SERIES_EDIPOSE { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    public int SEASON { get; set; }

    public int EPISODE { get; set; }

    public int DURATION { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string SYNOPSIS { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string THUMBNAIL { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string MEDIA { get; set; } = null!;

    public int YEAR { get; set; }

    public int ID_SERIES { get; set; }

    public int ID_CONTENT { get; set; }

    [ForeignKey("ID_CONTENT")]
    [InverseProperty("SERIES_EPISODEs")]
    public virtual CONTENT ID_CONTENTNavigation { get; set; } = null!;

    [ForeignKey("ID_SERIES")]
    [InverseProperty("SERIES_EPISODEs")]
    public virtual SERIES ID_SERIESNavigation { get; set; } = null!;
}
