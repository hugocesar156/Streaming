using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("CATALOG_CONTENT")]
public partial class CATALOG_CONTENT
{
    [Key]
    public int ID_CATALOG_CONTENT { get; set; }

    public int ID_CONTENT { get; set; }

    public int? ID_FILM { get; set; }

    public int? ID_SERIES_EPISODE { get; set; }

    [ForeignKey("ID_CONTENT")]
    [InverseProperty("CATALOG_CONTENTs")]
    public virtual CONTENT ID_CONTENTNavigation { get; set; } = null!;

    [ForeignKey("ID_FILM")]
    [InverseProperty("CATALOG_CONTENTs")]
    public virtual FILM? ID_FILMNavigation { get; set; }

    [ForeignKey("ID_SERIES_EPISODE")]
    [InverseProperty("CATALOG_CONTENTs")]
    public virtual SERIES_EPISODE? ID_SERIES_EPISODENavigation { get; set; }
}
