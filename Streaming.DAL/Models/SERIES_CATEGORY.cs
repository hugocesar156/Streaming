using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("SERIES_CATEGORY")]
public partial class SERIES_CATEGORY
{
    [Key]
    public int ID_SERIES_CATEGORY { get; set; }

    public int ID_SERIES { get; set; }

    public int ID_CATEGORY { get; set; }

    [ForeignKey("ID_CATEGORY")]
    [InverseProperty("SERIES_CATEGORies")]
    public virtual CATEGORY ID_CATEGORYNavigation { get; set; } = null!;

    [ForeignKey("ID_SERIES")]
    [InverseProperty("SERIES_CATEGORies")]
    public virtual SERIES ID_SERIESNavigation { get; set; } = null!;
}
