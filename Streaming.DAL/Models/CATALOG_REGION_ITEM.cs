using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("CATALOG_REGION_ITEM")]
public partial class CATALOG_REGION_ITEM
{
    [Key]
    public int ID_CATALOG_REGION_ITEM { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string CLASSIFICATION { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string SYNOPSIS { get; set; } = null!;

    public int ID_CATALOG_REGION { get; set; }

    public int ID_SERIES_EPISODE { get; set; }

    [ForeignKey("ID_CATALOG_REGION")]
    [InverseProperty("CATALOG_REGION_ITEMs")]
    public virtual CATALOG_REGION ID_CATALOG_REGIONNavigation { get; set; } = null!;

    [ForeignKey("ID_SERIES_EPISODE")]
    [InverseProperty("CATALOG_REGION_ITEMs")]
    public virtual SERIES_EPISODE ID_SERIES_EPISODENavigation { get; set; } = null!;
}
