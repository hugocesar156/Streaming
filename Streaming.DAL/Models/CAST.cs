using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("CAST")]
public partial class CAST
{
    [Key]
    public int ID_CAST { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [InverseProperty("ID_CASTNavigation")]
    public virtual ICollection<FILM> FILMs { get; set; } = new List<FILM>();

    [InverseProperty("ID_CASTNavigation")]
    public virtual ICollection<SERIES> SERIES { get; set; } = new List<SERIES>();
}
