using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("SERIES_EPISODE_REGION")]
public partial class SERIES_EPISODE_REGION
{
    [Key]
    public int ID_SERIES_EPISODE_REGION { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string CLASSIFICATION { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string SYNOPSIS { get; set; } = null!;

    public int ID_SERIES_EPISODE { get; set; }

    public int ID_LANGUAGE { get; set; }

    [ForeignKey("ID_LANGUAGE")]
    [InverseProperty("SERIES_EPISODE_REGIONs")]
    public virtual LANGUAGE ID_LANGUAGENavigation { get; set; } = null!;

    [ForeignKey("ID_SERIES_EPISODE")]
    [InverseProperty("SERIES_EPISODE_REGIONs")]
    public virtual SERIES_EPISODE ID_SERIES_EPISODENavigation { get; set; } = null!;
}
