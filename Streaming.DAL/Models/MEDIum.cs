using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("MEDIA")]
public partial class MEDIum
{
    [Key]
    public int ID_MEDIA { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string PATH { get; set; } = null!;

    public int ID_RESOLUTION { get; set; }

    public int? ID_FILM { get; set; }

    public int? ID_SERIES_EPISODE { get; set; }

    [ForeignKey("ID_FILM")]
    [InverseProperty("MEDIa")]
    public virtual FILM? ID_FILMNavigation { get; set; }

    [ForeignKey("ID_RESOLUTION")]
    [InverseProperty("MEDIa")]
    public virtual RESOLUTION ID_RESOLUTIONNavigation { get; set; } = null!;

    [ForeignKey("ID_SERIES_EPISODE")]
    [InverseProperty("MEDIa")]
    public virtual SERIES_EPISODE? ID_SERIES_EPISODENavigation { get; set; }
}
