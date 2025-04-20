using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

public partial class SERIES
{
    [Key]
    public int ID_SERIES { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string THUMBNAIL { get; set; } = null!;

    public int ID_LANGUAGE { get; set; }

    public bool KIDS_CONTENT { get; set; }

    [InverseProperty("ID_SERIESNavigation")]
    public virtual ICollection<CAST> CASTs { get; set; } = new List<CAST>();

    [InverseProperty("ID_SERIESNavigation")]
    public virtual ICollection<CATALOG_CATEGORY> CATALOG_CATEGORies { get; set; } = new List<CATALOG_CATEGORY>();

    [ForeignKey("ID_LANGUAGE")]
    [InverseProperty("SERIES")]
    public virtual LANGUAGE ID_LANGUAGENavigation { get; set; } = null!;

    [InverseProperty("ID_SERIESNavigation")]
    public virtual ICollection<SERIES_EPISODE> SERIES_EPISODEs { get; set; } = new List<SERIES_EPISODE>();
}
