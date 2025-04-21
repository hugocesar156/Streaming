using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("CATALOG_REGION")]
public partial class CATALOG_REGION
{
    [Key]
    public int ID_CATALOG_REGION { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string? CLASSIFICATION { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string SYNOPSIS { get; set; } = null!;

    public int? ID_FILM { get; set; }

    public int ID_LANGUAGE { get; set; }

    public int? ID_SERIES { get; set; }

    [InverseProperty("ID_CATALOG_REGIONNavigation")]
    public virtual ICollection<CATALOG_REGION_ITEM> CATALOG_REGION_ITEMs { get; set; } = new List<CATALOG_REGION_ITEM>();

    [ForeignKey("ID_FILM")]
    [InverseProperty("CATALOG_REGIONs")]
    public virtual FILM? ID_FILMNavigation { get; set; }

    [ForeignKey("ID_LANGUAGE")]
    [InverseProperty("CATALOG_REGIONs")]
    public virtual LANGUAGE ID_LANGUAGENavigation { get; set; } = null!;

    [ForeignKey("ID_SERIES")]
    [InverseProperty("CATALOG_REGIONs")]
    public virtual SERIES? ID_SERIESNavigation { get; set; }
}
