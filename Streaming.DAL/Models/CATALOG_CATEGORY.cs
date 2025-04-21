using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("CATALOG_CATEGORY")]
public partial class CATALOG_CATEGORY
{
    [Key]
    public int ID_CATALOG_CATEGORY { get; set; }

    public int ID_CATEGORY { get; set; }

    public int? ID_FILM { get; set; }

    public int? ID_SERIES { get; set; }

    [ForeignKey("ID_CATEGORY")]
    [InverseProperty("CATALOG_CATEGORies")]
    public virtual CATEGORY ID_CATEGORYNavigation { get; set; } = null!;

    [ForeignKey("ID_FILM")]
    [InverseProperty("CATALOG_CATEGORies")]
    public virtual FILM? ID_FILMNavigation { get; set; }

    [ForeignKey("ID_SERIES")]
    [InverseProperty("CATALOG_CATEGORies")]
    public virtual SERIES? ID_SERIESNavigation { get; set; }
}
