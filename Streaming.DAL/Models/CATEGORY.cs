using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("CATEGORY")]
public partial class CATEGORY
{
    [Key]
    public int ID_CATEGORY { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [InverseProperty("ID_CATEGORYNavigation")]
    public virtual ICollection<CATALOG_CATEGORY> CATALOG_CATEGORies { get; set; } = new List<CATALOG_CATEGORY>();
}
