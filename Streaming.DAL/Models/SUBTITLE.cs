using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("SUBTITLES")]
public partial class SUBTITLE
{
    [Key]
    public int ID_SUBTITLES { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string PATH { get; set; } = null!;

    public int ID_LANGUAGE { get; set; }

    public int? ID_FILM { get; set; }

    public int? ID_SERIES_EPISODE { get; set; }

    [ForeignKey("ID_FILM")]
    [InverseProperty("SUBTITLEs")]
    public virtual FILM? ID_FILMNavigation { get; set; }

    [ForeignKey("ID_LANGUAGE")]
    [InverseProperty("SUBTITLEs")]
    public virtual LANGUAGE ID_LANGUAGENavigation { get; set; } = null!;

    [ForeignKey("ID_SERIES_EPISODE")]
    [InverseProperty("SUBTITLEs")]
    public virtual SERIES_EPISODE? ID_SERIES_EPISODENavigation { get; set; }
}
