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
    public virtual ICollection<FILM> FILMs { get; set; } = new List<FILM>();

    [InverseProperty("ID_CATEGORYNavigation")]
    public virtual ICollection<SERIES> SERIES { get; set; } = new List<SERIES>();
}
