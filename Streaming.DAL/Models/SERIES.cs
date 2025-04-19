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

    [StringLength(5)]
    [Unicode(false)]
    public string CLASSIFICATION { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string SYNOPSIS { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string THUMBNAIL { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string PREVIEW { get; set; } = null!;

    public int ID_CATEGORY { get; set; }

    [InverseProperty("ID_SERIESNavigation")]
    public virtual ICollection<CAST> CASTs { get; set; } = new List<CAST>();

    [ForeignKey("ID_CATEGORY")]
    [InverseProperty("SERIES")]
    public virtual CATEGORY ID_CATEGORYNavigation { get; set; } = null!;

    [InverseProperty("ID_SERIESNavigation")]
    public virtual ICollection<SERIES_EPISODE> SERIES_EPISODEs { get; set; } = new List<SERIES_EPISODE>();
}
